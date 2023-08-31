using FindingPotato.Character;
using FindingPotato.Character.Monster;
using FindingPotato.Item;
using FindingPotato.Skill;
using FindingPotato.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        //전투화면
        void BattleScreen()
        {
            Console.SetCursorPosition(15, 4);
            Console.WriteLine("=========================================================================================================================");//

            Console.SetCursorPosition(15, 33);
            Console.WriteLine($"Lv.{player.Level} {player.Name} HP {player.CurrentHealth}/{player.MaxHealth} MP {player.CurrentMP}/{player.MaxMP}");

            UIExtension.DrawCharacter(player.Image, 16, 35);

            for (int i = 0; i < monsters.Count(); i++)
            {
                Console.SetCursorPosition(30 + (i * 25), 6);
                if (monsters[i].IsDead)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"Lv.{monsters[i].Level} {monsters[i].Name} {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].CurrentHealth)}");
                    Console.ResetColor();
                }
                else
                    Console.Write($"Lv.{monsters[i].Level} {monsters[i].Name} HP {monsters[i].CurrentHealth}");

                UIExtension.DrawCharacter(monsters[i].Image, 28 + (i * 24), 8);
            }
            for (int i = 0; i < 15; i++)
            {
                Console.SetCursorPosition(48, 31+i);
                Console.WriteLine("|"); 
            }



            Console.SetCursorPosition(15, 31);
            Console.WriteLine("=========================================================================================================================\n");//
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

                BattleScreen(); 

                int input = BattleSceneUI.GetPlayerSelect(1); 

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

                BattleScreen();

           
                string[] monsterName = new string[monsters.Count+1];

                bool[] isLimited = new bool[monsterName.Count() + 1];

                for (int i = 0; i < monsters.Count(); i++)
                {
                    monsterName[i] = $"{i + 1}." + monsters[i].Name;
                    if (monsters[i].IsDead) isLimited[i+1] = true;
                }
                monsterName[monsters.Count] = "0.취소";

               
                //for(int i = 1;  i<monsterName.Count()-1;i++)
                //{
                   
                //}

                int input = UIExtension.GetPlayerSelectFromUI(125, 30 - monsters.Count, 1, monsterName, true , isLimited);

                if (input > 0 && input <= monsters.Count())
                {
                    PlayerTurnScreen(monsters[input - 1]);
                    EnemyPhase();
                    break;
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

                BattleScreen();

                //플레이어의 데미지
                int damage = player.Attack + player.AddAtk;

                //몬스터의 이전 체력
                int previousHP = monster.CurrentHealth;


                Console.SetCursorPosition(53,Console.CursorTop); 
                Extension.TypeWriting($"{player.Name}의 공격!");

                // 10% 의 확률로 플레이어의 공격을 회피
                if (IsOccur(10)) monster.Avoid();
                else
                {
                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.Write($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다.");
                    // 15% 의 확률로 치명타 공격
                    if (IsOccur(53))
                    {
                        damage = (int)(damage * 1.6);
                      
                        Console.WriteLine($" [ 데미지 : {damage} ] - 치명타 공격!!");
                    }
                    else 
                    {
                       
                        Console.WriteLine($" [ 데미지 : {damage} ]"); 
                    }
                    Console.WriteLine();

                    Console.SetCursorPosition(53, Console.CursorTop);
                    monster.TakeDamage(damage);
                    Console.WriteLine();
                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.WriteLine($"HP {previousHP} -> {monster.CurrentHealth}\n");
                }


                int input = BattleSceneUI.GetPlayerSelect(2); 

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
                BattleScreen();
                if (!monsters[i].IsDead) //죽은 몬스터는 공격 X
                {
                    //몬스터 데미지
                    int damage = monsters[i].Attack - (player.Defense+player.AddDef);
                    damage = Math.Max(damage,0); 

                    //플레이어 이전 체력
                    int previousHP = player.CurrentHealth;

                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.Write($"Lv.{monsters[i].Level} {monsters[i].Name}의 ");
                    Extension.TypeWriting(monsters[i].AttackMessage());

                    Console.SetCursorPosition(53, Console.CursorTop);
                    player.TakeDamage(damage);
                    Console.WriteLine();
                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");

                    Console.SetCursorPosition(53, Console.CursorTop);
                    Console.WriteLine($"HP {previousHP} -> {player.CurrentHealth}");

                    Console.WriteLine();

                    int input = BattleSceneUI.GetPlayerSelect(2); 
                    
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
            Console.Clear();


            BattleScreen();
            

            string[] skillName = new string[player.SkillList.Count+1];
            for(int i = 0; i<player.SkillList.Count; i++)
            {
                skillName[i] = $"{i+1}."+player.SkillList[i].Description; 
            }
            skillName[player.SkillList.Count] = "0.취소"; 
            
            int input = UIExtension.GetPlayerSelectFromUI(75, 28,1,skillName, true);

            if (input == 1)
            {
                bool isAttackSuccess = AlphaStrikeAttack();
                if (isAttackSuccess) EnemyPhase();
            }
            else if (input == 2)
            {
                bool isAttackSuccess = DoubleStrikeAttack();
                if (isAttackSuccess) EnemyPhase();
            }

            // 공격할 몬스터가 없으면 스테이지 클리어 성공(true)
            if (monsters.All(x => x.IsDead))
            {
                OnCharacterDeath?.Invoke(true);
                return;
            }
        }

        bool AlphaStrikeAttack()
        {
            if (player.CurrentMP < (int)SkillType.ALPHA)
            {
                Console.SetCursorPosition(53, 32);
                Console.WriteLine("MP가 부족합니다!");
                Thread.Sleep(1000);
                return false;
            }
            else
            {
                int monsterIdx = 0;
                while (true)
                {
                    Console.Clear();
                   
                    BattleScreen();

                    string[] monsterName = new string[monsters.Count+1];
                    bool[] isLimited = new bool[monsterName.Count() + 1];

                    for (int i = 0; i< monsters.Count; i++)
                    {
                        monsterName[i] = $"{i+1}." + monsters[i].Name;
                        if (monsters[i].IsDead) isLimited[i + 1] = true;
                    }
                    monsterName[monsters.Count] = "0.취소"; 

                    monsterIdx = UIExtension.GetPlayerSelectFromUI(128, 30-monsters.Count, 1, monsterName, true, isLimited)-1;


                    if (monsterIdx == -1)
                    {
                        return false;
                    }
                    else break;

                }
                player.UseSkill(SkillType.ALPHA, new List<ICharacter> { monsters[monsterIdx] });
            }

            
            int input = BattleSceneUI.GetPlayerSelect(2); 
            return true;
        }

        bool DoubleStrikeAttack()
        {
            if (player.CurrentMP < (int)SkillType.DOUBLE)
            {
                Console.SetCursorPosition(53, 32);
                Console.WriteLine("MP가 부족합니다!");
                Thread.Sleep(1000);
                return false;
            }
            else
            {
                List<ICharacter> monsterList = new List<ICharacter>();
                foreach (ICharacter monster in monsters) monsterList.Add(monster);
                player.UseSkill(SkillType.DOUBLE, monsterList);
            }

           
            string[] next = { "0.다음" };

            int input = UIExtension.GetPlayerSelectFromUI(53, Console.CursorTop, 1, next, true);
            return true;
        }

        // 도망가기
        bool RunAway()
        {
            bool isSuccess = IsOccur(53);

            if (!isSuccess)     // 도망가기 실패시 문구 출력
            {
                Random random = new Random();
                string[] messages = {"앗! 카트에 치여버렸다! 도망가기 실패.",
                                 "앗! 자동문이 열리지 않는다...! 도망가기 실패.",
                                 "앗! 직원이 다시 돌려놓았다! 도망가기 실패."};
                string message = messages[random.Next(3)];
               
                Console.SetCursorPosition(53,33);
                Console.WriteLine(message);
               
                Thread.Sleep(1500);
            }
            
            return isSuccess;
        }
        
        //스테이지 클리어 
        void StageClear(bool isPlayerWin)
        {
            while (true)
            {
                Console.Clear();
               
               
                if (isPlayerWin) //플레이어 승리 
                {
           
                    BattleSceneUI.GetResultBox();
                    Console.SetCursorPosition(48,7); 
                    Extension.TypeWriting("VICTORY");
                    switch(Difficulty)
                    {
                        case StageDifficulty.Easy:
                            Console.SetCursorPosition(48, 9);
                            Extension.TypeWriting($"나를 막던 과일들이 포장 되었다!\n");
                            Console.SetCursorPosition(48, Console.CursorTop);
                            Extension.TypeWriting($"과일 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Normal:
                            Console.SetCursorPosition(48, 9);
                            Extension.TypeWriting($"나를 막던 채소들이 판매 되었다!\n");
                            Console.SetCursorPosition(48, Console.CursorTop);
                            Extension.TypeWriting($"채소 코너를 지나갔다!");
                            break;

                        case StageDifficulty.Hard:
                            Thread.Sleep(1000);
                            EndingScene.VictoryScene(player);  
                             break;
                    }
                    player.CurrentStage = player.CurrentStage == (int)Difficulty ?player.CurrentStage+1 : player.CurrentStage;
                    Console.WriteLine();
                    if (Difficulty != StageDifficulty.Hard) GiveRewards();
                    CalculationExp(monsters); // 경험치 계산 호출
                }
                else //몬스터 승리 
                {
                    Console.WriteLine("YOU DIED\n");
                    EndingScene.DeadScene(player); 
                    
                }

                // 스테이지 종료 후 MP 회복
                player.CurrentMP = player.MaxMP;
                Console.SetCursorPosition(48, Console.CursorTop);
                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.SetCursorPosition(48, Console.CursorTop);
                Console.WriteLine($"HP {player.MaxHealth}-> {player.CurrentHealth}\n");
                Console.WriteLine($"EXP {player.CurrentExp}-> {player.CurrentExp}\n");
                //Console.WriteLine("0.다음\n");

                string[] next = { "0.다음" };

                int input = UIExtension.GetPlayerSelectFromUI(48, Console.CursorTop,1, next, true);

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
            player.GetReward(consumableItemReward);
            rewards.Remove(consumableItemReward);

            // 착용 가능한 보상 아이템
            int equipableItemIdx = GetRandomIdx(1, rewards.Count / 2, rewards.Count)[0];
            IItem equipableItemReward = rewards[equipableItemIdx];
            player.GetReward(equipableItemReward);
            rewards.Remove(equipableItemReward);

            Console.SetCursorPosition(48, Console.CursorTop);
            Console.WriteLine("[ 획득 아이템 ]");

            Console.SetCursorPosition(48, Console.CursorTop);
            Console.WriteLine($"{consumableItemReward.Name} - 1");

            Console.SetCursorPosition(48, Console.CursorTop);
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

        // 경험치 계산, 몬스터 레벨 * 몬스터 마리수(1), 레벨값만 추가
        void CalculationExp(List<Monster> monsters)
        {
            int totalExp = 0;
            foreach (Monster monster in monsters)
            {
                totalExp += monster.Level;
            }
            player.ExpUpdate(totalExp); 
        }
    }
}   
