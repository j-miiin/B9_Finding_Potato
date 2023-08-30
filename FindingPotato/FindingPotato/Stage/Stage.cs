using FindingPotato.Character;
using FindingPotato.Character.Monster;
using FindingPotato.Item;
using FindingPotato.Skill;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindingPotato.Stage
{
    enum StageDifficulty
    {
        Easy = 1, Normal,Hard
    }

    internal class StageClass
    {
        public StageDifficulty Difficulty;

        private Player player; // 플레이어
        private List<Monster> monsters; // 몬스터 리스트
        private List<IItem> rewards; // 보상 아이템 리스트

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(bool isPlayerWin);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트
        public StageClass(Player player, List<Monster> monsters, List<IItem> rewards, StageDifficulty difficulty)
        {
            this.player = player;
            this.monsters = monsters;
            this.rewards = rewards;
            Difficulty = difficulty;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출

            //스테이지가 생성되면 몬스터 체력 회복
            foreach (Monster monster in monsters)
                monster.CurrentHealth = monster.MaxHealth;

        }

        //전투 정보 표시
        void InfoScreen(bool bNum, string str)
        {
            Console.WriteLine("Battle!!!\n");

            for (int i = 0; i < monsters.Count(); i++)
            {
                if (monsters[i].IsDead)
                    Extension.ColorWriteLine($"{(bNum ? (i + 1) + "." : "")} Lv.{monsters[i].Level} {monsters[i].Name}  {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].CurrentHealth)}", ConsoleColor.Black, ConsoleColor.DarkGray);

                else
                    Console.WriteLine($"{(bNum ? (i + 1) + "." : "")} Lv.{monsters[i].Level} {monsters[i].Name}  {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].CurrentHealth)}");

            }

            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {player.CurrentHealth}/{player.MaxHealth}");
            Console.WriteLine($"MP {player.CurrentMP}/{player.MaxMP}");
            Console.WriteLine();
            Console.WriteLine(str);
            Console.WriteLine();
        }

        // 스테이지 시작 
        public void Start()
        {
            while (true)
            {
                Console.Clear();

                //Character 생사 확인
                if (player.IsDead)
                    break;
                else if (monsters.All(x => x.IsDead))
                    break;

                InfoScreen(false, "0.도망가기 1.공격 2.스킬");

                int input = Extension.GetInput(0, 2);

                if (input == 1)
                {
                    //공격
                    InitiatePlayerAttackAction();
                }
                else if (input == 2)
                {
                    //스킬
                    UsePlayerSkill();
                }
                else if (input == 0)
                {
                    //도망가기
                    if (RunAway()) break;                    
                }
            }
        }

        //플레이어 공격 시작 화면 
        void InitiatePlayerAttackAction()
        {
            while (true)
            {
                Console.Clear();

                InfoScreen(true, "0.취소");

                int input = Extension.GetInput(0, monsters.Count);

                if (input > 0 && input <= monsters.Count())
                {
                    if (monsters[input - 1].IsDead) // 죽은 몬스터는 선택 X
                    {
                        Console.WriteLine($"{monsters[input-1].Name}은(는) 이미 죽었습니다.");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        PlayerTurnScreen(monsters[input-1]);
                        EnemyPhase();
                        break;
                    }
                }
                else if (input == 0)
                {
                    break;
                }
                else return; 
            }
        }

        //플레이어 공격 화면 
        void PlayerTurnScreen(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                //플레이어의 데미지
                int damage = player.Attack;

                //몬스터의 이전 체력
                int previousHP = monster.CurrentHealth;

                Console.WriteLine("Battle!!\n");
                Extension.TypeWriting($"{player.Name}의 공격!");

                // 10% 의 확률로 플레이어의 공격을 회피
                if (IsOccur(10)) monster.Avoid();
                else
                {
                    Console.Write($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다.");
                    // 15% 의 확률로 치명타 공격
                    if (IsOccur(15))
                    {
                        damage = (int)(damage * 1.6);
                        Console.WriteLine($" [ 데미지 : {damage} ] - 치명타 공격!!");
                    }
                    else Console.WriteLine($" [ 데미지 : {damage} ]");
                    Console.WriteLine();

                    monster.TakeDamage(damage);
                    Console.WriteLine();
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                    Console.WriteLine($"HP {previousHP} -> {monster.CurrentHealth}\n");
                }

                Console.WriteLine();
                Console.WriteLine("0.다음");

                int input = Extension.GetInput(0, 0);

                if(input == 0)
                {
                    if (monsters.All(x => x.IsDead)) //몬스터가 전부 죽으면 승리 
                    {
                        OnCharacterDeath?.Invoke(true);
                    }
                    break; 
                }
            }
        }

        // prob 확률의 이벤트가 발생한다면 true, 아니면 false 리턴
        // 15% 확률로 일어나는 이벤트 -> IsOccur(15)
        private bool IsOccur(int prob)
        {
            int isOccur = new Random().Next(0, 100);
            if (isOccur < prob) return true;
            else return false;
        }

        //몬스터 공격 페이즈
        void EnemyPhase()
        {
            for(int i = 0; i<monsters.Count; i++) // 배열에 있는 몬스터들이 공격
            {
                Console.Clear(); 
                if (!monsters[i].IsDead) //죽은 몬스터는 공격 X
                {
                    //몬스터 데미지
                    int damage = monsters[i].Attack - (player.Defense+player.AddDef);
                    damage = Math.Max(damage,0); 

                    //플레이어 이전 체력
                    int previousHP = player.CurrentHealth;

                    Console.WriteLine("Battle!!\n");
                    Console.Write($"Lv.{monsters[i].Level} {monsters[i].Name}의 ");
                    Extension.TypeWriting(monsters[i].AttackMessage());
                    player.TakeDamage(damage);
                    Console.WriteLine();

                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {previousHP} -> {player.CurrentHealth}");

                    Console.WriteLine();

                    Console.WriteLine("0.다음");

                    int input = Extension.GetInput(0, 0); 
                    
                    if(input == 0)
                    {
                        //플레이어 생사 확인
                        if (player.IsDead)
                        {
                            OnCharacterDeath?.Invoke(false);
                            break;
                        }
                    }
                }
            }
        }

        // 스킬을 사용한 공격
        void UsePlayerSkill()
        {
            while (true)
            {
                Console.Clear();

                // Player가 죽으면 스테이지 클리어 실패(false)
                if (player.IsDead)
                {
                    OnCharacterDeath?.Invoke(false);
                    break;
                }
                // 공격할 몬스터가 없으면 스테이지 클리어 성공(true)
                else if (monsters.All(x => x.IsDead))
                {
                    OnCharacterDeath?.Invoke(true);
                    break;
                } 

                string str = "1. 알파 스트라이크 - MP 10\n   공격력 * 2 로 하나의 적을 공격합니다.\n\n" +
                    "2. 더블 스트라이크 - MP 15\n   공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.\n\n0. 취소";

                InfoScreen(false, str);

                int input = Extension.GetInput(0, 2);

                if (input == 1)
                {
                    AlphaStrikeAttack();
                }
                else if (input == 2)
                {
                    DoubleStrikeAttack();
                }
                else break;

                EnemyPhase();
            }
        }

        void AlphaStrikeAttack()
        {
            if (player.CurrentMP < (int)SkillType.ALPHA)
            {
                Console.WriteLine("MP가 부족합니다!");
                Thread.Sleep(1000);
            }
            else
            {
                int monsterIdx = 0;
                while (true)
                {
                    Console.Clear();
                    InfoScreen(true, "");
                    monsterIdx = Extension.GetInput(1, monsters.Count) - 1;
                    if (monsters[monsterIdx].IsDead)
                    {
                        Console.WriteLine($"{monsters[monsterIdx].Name} 은(는) 이미 죽었습니다.");
                        Thread.Sleep(1000);
                    }
                    else break;
                }
                player.UseSkill(SkillType.ALPHA, new List<ICharacter> { monsters[monsterIdx] });
            }

            Console.WriteLine("0.다음\n");

            int input = Extension.GetInput(0, 0);
        }

        void DoubleStrikeAttack()
        {
            if (player.CurrentMP < (int)SkillType.DOUBLE)
            {
                Console.WriteLine("MP가 부족합니다!");
                Thread.Sleep(1000);
            }
            else
            {
                List<ICharacter> monsterList = new List<ICharacter>();
                foreach (ICharacter monster in monsters) monsterList.Add(monster);
                player.UseSkill(SkillType.DOUBLE, monsterList);
            }

            Console.WriteLine("0.다음\n");

            int input = Extension.GetInput(0, 0);
        }

        // 도망가기
        bool RunAway()
        {
            bool isSuccess = IsOccur(30);

            if (!isSuccess)     // 도망가기 실패시 문구 출력
            {
                Random random = new Random();
                string[] messages = {"앗! 카트에 치여버렸다! 도망가기 실패.",
                                 "앗! 자동문이 열리지 않는다...! 도망가기 실패.",
                                 "앗! 직원이 다시 돌려놓았다! 도망가기 실패."};
                string message = messages[random.Next(3)];
                Console.SetCursorPosition(0, Console.CursorTop - 2);
                Console.WriteLine(message);
                Console.WriteLine("                                ");
                Thread.Sleep(2000);
            }
            
            return isSuccess;
        }
        
        //스테이지 클리어 
        void StageClear(bool isPlayerWin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!! - Result\n");
                if (isPlayerWin) //플레이어 승리 
                {
                    Extension.TypeWriting("VICTORY");
                    switch(Difficulty)
                    {
                        case StageDifficulty.Easy:
                            Extension.TypeWriting($"나를 막던 과일들이 포장 되었다!\n");
                            Extension.TypeWriting($"과일 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Normal:
                            Extension.TypeWriting($"나를 막던 채소들이 판매 되었다!\n");
                            Extension.TypeWriting($"채소 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Hard:
                             EndingScreen(); 
                             break;
                    }
                    player.CurrentStage = player.CurrentStage == (int)Difficulty ? player.CurrentStage+1 : player.CurrentStage;
                    Console.WriteLine();
                    GiveRewards();
                }
                else //몬스터 승리 
                {
                    Console.WriteLine("YOU DIED\n");
                    Extension.TypeWriting("직원의 손에 이끌려 포장되었다...\n"); 
                    Console.WriteLine("아무키나 눌러서 종료."); 
                    Console.ReadKey(); 
                    Environment.Exit(0);
                }

                // 스테이지 종료 후 MP 회복
                player.CurrentMP = player.MaxMP;

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {player.MaxHealth}-> {player.CurrentHealth}\n");
                Console.WriteLine("0.다음\n");
                
                int input = Extension.GetInput(0, 0);

                if (input == 0)
                {
                    break; 
                }
            }
        }

        private void GiveRewards()
        {
            // 보상 아이템
            // 소모 가능한 보상 아이템
            int consumableItemIdx = GetRandomIdx(1, 0, rewards.Count / 2)[0];
            IItem consumableItemReward = rewards[consumableItemIdx];
            player.PlayerInventory.InventoryItems.Add(consumableItemReward);
            rewards.Remove(consumableItemReward);

            // 착용 가능한 보상 아이템
            int equipableItemIdx = GetRandomIdx(1, rewards.Count / 2, rewards.Count)[0];
            IItem equipableItemReward = rewards[equipableItemIdx];
            player.PlayerInventory.InventoryItems.Add(equipableItemReward);
            rewards.Remove(equipableItemReward);

            Console.WriteLine("[ 획득 아이템 ]");
            Console.WriteLine($"{consumableItemReward.Name} - 1");
            Console.WriteLine($"{equipableItemReward.Name} - 1");
            Console.WriteLine();
        }

        // min 이상 max 미만 사이에서 n개의 랜덤한 숫자를 뽑아서 list에 담아 반환
        private List<int> GetRandomIdx(int n, int min, int max)
        {
            List<int> randomIdx = new List<int>();

            while (randomIdx.Count < n)
            {
                int currentNum = new Random().Next(min, max);
                if (!randomIdx.Contains(currentNum))
                {
                    randomIdx.Add(currentNum);
                }
            }

            return randomIdx;
        }

        void EndingScreen()
        {
            Console.Clear();
            Console.WriteLine("-The End-\n");
            Extension.TypeWriting($"내 친구 감자를 구했다!!\n");
            Console.WriteLine("아무키나 눌러서 종료.\n");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}   
