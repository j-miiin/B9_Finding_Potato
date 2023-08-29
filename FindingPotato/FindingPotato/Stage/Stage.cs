using FindingPotato.Character;
using FindingPotato.Character.Monster;
using FindingPotato.Item;
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
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트
        public StageClass(Player player, List<Monster> monsters, , List<IItem> rewards, StageDifficulty difficulty)
        {
            this.player = player;
            this.monsters = monsters;
            this.rewards = rewards;
            Difficulty = difficulty;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출
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
                    break;
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

                int input = Extension.GetInput(0, 3);

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
                        EnenyPhase();
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

                //플레이어의 이전 체력
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
                        OnCharacterDeath?.Invoke(monster);
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
        void EnenyPhase()
        {
            for(int i = 0; i<monsters.Count; i++) // 배열에 있는 몬스터들이 공격
            {
                Console.Clear(); 
                if (!monsters[i].IsDead) //죽은 몬스터는 공격 X
                {
                    //몬스터 데미지
                    int damage = monsters[i].Attack;

                    //몬스터 이전 체력
                    int previousHP = player.CurrentHealth;

                    Console.WriteLine("Battle!!\n");
                    Console.Write($"Lv.{monsters[i].Level} {monsters[i].Name}의 ");
                    monsters[i].AttackMessage();
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
                            OnCharacterDeath?.Invoke(player);
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

                string str = "1. 알파 스트라이크 - MP 10\n   공격력 * 2 로 하나의 적을 공격합니다.\n\n" +
                    "2. 더블 스트라이크 - MP 15\n   공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.\n0. 취소";

                InfoScreen(false, str);

                int input = Extension.GetInput(0, 2);

                if (input == 1)
                {
                    if (monsters.All(x => x.IsDead))
                    {
                        Console.WriteLine("공격할 수 있는 적이 없습니다!");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (player.CurrentMP < (int)Player.MPAttackType.ALPHA)
                    {
                        Console.WriteLine("MP가 부족합니다!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.Clear();
                        InfoScreen(true, "");
                        int monsterIdx = Extension.GetInput(1, monsters.Count) - 1;
                        if (monsters[monsterIdx].IsDead)
                        {
                            Console.WriteLine($"{monsters[monsterIdx].Name} 은(는) 이미 죽었습니다.");
                            Thread.Sleep(1000);
                        }
                        else AlphaStrikeAttack(monsterIdx);
                    }
                }
                else if (input == 2)
                {
                    if (monsters.All(x => x.IsDead))
                    {
                        Console.WriteLine("공격할 수 있는 적이 없습니다!");
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (player.CurrentMP < (int)Player.MPAttackType.DOUBLE)
                    {
                        Console.WriteLine("MP가 부족합니다!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        DoubleStrikeAttack();
                    }
                }
                else break;
            }
        }

        // 스킬 - 알파 스트라이크
        private void AlphaStrikeAttack(int monsterIdx)
        {
            Console.Clear();

            Extension.TypeWriting("Battle!!\n");
            Extension.TypeWriting($"{player.Name}의 알파 스트라이크 공격!");
            Console.WriteLine();

            Monster curMonster = (Monster)monsters[monsterIdx];
            int monsterPrevHP = curMonster.CurrentHealth;

            curMonster.TakeDamage(player.Attack * 2);  // 공격력 * 2 로 하나의 적 공격
            player.AttackWithMP(Player.MPAttackType.ALPHA);

            // 알파 스트라이크 결과 출력
            Console.WriteLine($"Lv.{curMonster.Level} {curMonster.Name}");
            Console.WriteLine($"HP {monsterPrevHP} -> {curMonster.CurrentHealth}\n");

            Console.WriteLine("0.다음");

            int input = Extension.GetInput(0, 0);
        }

        // 스킬 - 더블 스트라이크
        private void DoubleStrikeAttack()
        {
            Console.Clear();

            Extension.TypeWriting("Battle!!\n");
            Extension.TypeWriting($"{player.Name}의 더블 스트라이크 공격!");
            Console.WriteLine();

            // 살아있는 몬스터의 수
            int aliveMonster = monsters.Where(m => !m.IsDead).Count();

            // 살아있는 몬스터가 2마리 미만이면 1마리만 공격, 2마리 이상이면 2마리 공격
            int num = (aliveMonster < 2) ? 1 : 2;
            List<int> randomIdx = GetRandomIdx(num, 0, monsters.Count);

            // 공격 당하기 전 몬스터 체력을 저장해놓을 배열
            List<int> monsterPrevHPList = new List<int>();

            foreach (int idx in randomIdx)
            {
                if (monsters[idx].IsDead) continue;
                monsterPrevHPList.Add(monsters[idx].CurrentHealth); // 공격 당하기 전 몬스터 체력 저장
                monsters[idx].TakeDamage((int)(player.Attack * 1.5));   // 공격력 * 1.5 로 2명의 적을 랜덤 공격
            }
            player.AttackWithMP(Player.MPAttackType.DOUBLE);

            Console.WriteLine();

            // 더블 스트라이크 결과 출력
            int prevHPidx = 0;
            foreach (int idx in randomIdx)
            {
                Console.WriteLine($"Lv.{monsters[idx].Level} {monsters[idx].Name}");
                Console.WriteLine($"HP {monsterPrevHPList[prevHPidx++]} -> {monsters[idx].CurrentHealth}\n");
            }
           
            Console.WriteLine("0.다음");

            int input = Extension.GetInput(0, 0);
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

        //스테이지 클리어 
        void StageClear(ICharacter character)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!! - Result\n");
                if (character is Monster) //플레이어 승리 
                {
                    Extension.TypeWriting("VICTORY");
                    switch(Difficulty)
                    {
                        case StageDifficulty.Easy:
                            Extension.TypeWriting($"과일 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Normal:
                            Extension.TypeWriting($"채소 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Hard:
                            Extension.TypeWriting($"내친구 감자를 구했다!!");
                            break;
                    }
                    player.CurrentStage = player.CurrentStage == (int)Difficulty ? player.CurrentStage+1 : player.CurrentStage;
                    GiveRewards();
                    Console.WriteLine();
                }
                else //몬스터 승리 
                {
                    Console.WriteLine("YOU DIED");
                }

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
            rewards.Remove(consumableItemReward);

            // 착용 가능한 보상 아이템
            int equipableItemIdx = GetRandomIdx(1, rewards.Count / 2, rewards.Count)[0];
            IItem equipableItemReward = rewards[equipableItemIdx];
            rewards.Remove(equipableItemReward);

            Console.WriteLine("[ 획득 아이템 ]");
            Console.WriteLine($"{consumableItemReward.Name} - 1");
            Console.WriteLine($"{equipableItemReward.Name} - 1");
            Console.WriteLine();
        }
    }
}   
