using FindingPotato.Character;
using FindingPotato.Character.Monster;
using FindingPotato.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Stage
{
    internal class StageClass
    {
        private Player player; // 플레이어
        //private List<IItem> rewards; // 보상 아이템들

        private List<ICharacter> monsters;

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        public StageClass(Player player, List<ICharacter> monsters)
        {
            this.player = player;
            this.monsters = monsters;
            //this.rewards = rewards;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출
        }

        void InfoScreen(bool bNum , string str)
        {
            Console.WriteLine("Battle!!!\n");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{(bNum ? i+1:"")}{monsters[i].Name}  {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].Health)}");
            }

            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.player.level {player.Name}");
            Console.WriteLine($"HP {player.Health}/player.MaxHealth");
            Console.WriteLine();
            Console.WriteLine(str);
            Console.WriteLine();
        }

        // 스테이지 시작 메서드
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

                if(input == 1)
                {
                    PlayerAttackSelect(); 
                }
                else if(input == 2)
                {

                }
                else if(input == 0)
                {
                    break; 
                }
            }
        }

        //플레이어 공격 선택 화면 
        void PlayerAttackSelect()
        {
            while(true)
            {
                Console.Clear();

                InfoScreen(true, "0.취소");

                int input = Extension.GetInput(0, 3);

                if (input > 0 && input < monsters.Count())
                {
                    if (monsters[input - 1].IsDead) // 죽은 몬스터는 선택 X
                    {
                        Console.WriteLine($"{monsters[input - 1].Name}은(는) 이미 죽었습니다.");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        PlayerTurnScreen(monsters[input - 1]);
                        EnenyPhase();
                        break;
                    }
                }
                else if (input == 0)
                {
                    break;
                }
            }
        }

        //플레이어 공격 화면
        void PlayerTurnScreen(ICharacter monster)
        {
            while (true)
            {
                //플레이어 생사 확인
                if (player.IsDead)
                {
                    break;
                }
                
                Console.Clear();
                //플레이어의 데미지
                int damage = player.Attack;
                //플레이어의 이전 체력
                int previousHP = monster.Health; 

                Console.WriteLine("Battle!!\n");
                Console.WriteLine($"{player.Name}의 공격!");
                monster.TakeDamage(damage);
                Console.WriteLine();

                Console.WriteLine($"Lv.() {monster.Name}");
                Console.WriteLine($"HP {previousHP} -> {monster.Health}");
              
                Console.WriteLine();

                Console.WriteLine("0.다음");

                string? input = Console.ReadLine();

                bool isValid = int.TryParse(input, out int select);

                if (isValid)
                {
                    if (select == 0)
                    {
                        if (monsters.All(x => x.IsDead)) //몬스터가 전부 죽으면 승리 
                        {
                            OnCharacterDeath?.Invoke(monster);
                            break;
                        }
                        else
                            break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }

        //몬스터 공격 화면 
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
                    int previousHP = player.Health;

                    Console.WriteLine("Battle!!\n");
                    Console.WriteLine($"{monsters[i].Name}의 공격!");
                    player.TakeDamage(damage);
                    Console.WriteLine();

                    Console.WriteLine($"Lv.() {player.Name}");
                    Console.WriteLine($"HP {previousHP} -> {player.Health}");

                    Console.WriteLine();

                    Console.WriteLine("0.다음");

                    string? input = Console.ReadLine();

                    bool isValid = int.TryParse(input, out int select);

                    if (isValid)
                    {
                        if (select == 0)
                        {
                            
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                    }

                    //플레이어 생사 확인
                    if (player.IsDead)
                    {
                        OnCharacterDeath?.Invoke(player);
                        break;
                    }
                }
            }
        }

        //스테이지 클리어 메서드
        void StageClear(ICharacter character)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Battle!! - Result\n");
                if (character is Monster) //플레이어 승리 
                {
                    Console.WriteLine("VICTORY");
                    Console.WriteLine($"던전에서 몬스터 {monsters.Count()}마리를 잡았습니다.");
                }
                else //몬스터 승리 
                {
                    Console.WriteLine("YOU DIED");
                }

                Console.WriteLine($"Lv.player.level {player.Name}");
                Console.WriteLine($"HP player.MaxHealth-> {player.Health}\n");
                Console.WriteLine("0.다음");
                Console.Write(">> ");

                string? input = Console.ReadLine();

                bool isValid = int.TryParse(input, out int select);

                if (isValid)
                {
                    if (select == 0)
                    {
                        break; 
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }
    }
}   
