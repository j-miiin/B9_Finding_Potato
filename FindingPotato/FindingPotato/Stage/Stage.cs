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

        //전투 정보 표시
        void InfoScreen(bool bNum, string str)
        {
            Console.WriteLine("Battle!!!\n");

            for (int i = 0; i < monsters.Count(); i++)
            {
                Console.WriteLine($"{(bNum ? (i + 1)+".": "")}{monsters[i].Name}  {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].Health)}");
            }

            Console.WriteLine();
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.player.level {player.Name}");
            Console.WriteLine($"HP {player.Health}/player.MaxHealth");
            Console.WriteLine($"MP {player.MP}/50");
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
        void PlayerTurnScreen(ICharacter monster)
        {
            while (true)
            {
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
                Console.WriteLine($"HP {previousHP} -> {monster.Health}\n");

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
                    int previousHP = player.Health;

                    Console.WriteLine("Battle!!\n");
                    Console.WriteLine($"{monsters[i].Name}의 공격!");
                    player.TakeDamage(damage);
                    Console.WriteLine();

                    Console.WriteLine($"Lv.() {player.Name}");
                    Console.WriteLine($"HP {previousHP} -> {player.Health}");

                    Console.WriteLine();

                    Console.WriteLine("0.다음");

                    int input = Extension.GetInput(0, 0); 
                    
                    if(input == 0)
                    {
                        //플레이어 생사 확인
                        if (player.IsDead)
                        {
                            OnCharacterDeath?.Invoke(player);
                        }
                        break; 
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

                string str = "1. 알파 스트라이크 - MP 10\n   공격력 * 2 로 하나의 적을 공격합니다.\n" +
                    "2. 더블 스트라이크 - MP 15\n   공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.\n0. 취소";

                InfoScreen(false, str);

                int input = Extension.GetInput(0, 2);

                if (input == 1)
                {
                    if (player.MP < (int)Player.MPAttackType.ALPHA) Console.WriteLine("MP가 부족합니다!");
                    else
                    {
                        Console.Clear();
                        InfoScreen(true, "");
                        int monsterIdx = Extension.GetInput(1, monsters.Count) - 1;
                        AlphaStrikeAttack(monsterIdx);
                    }
                }
                else if (input == 2)
                {
                    if (player.MP < (int)Player.MPAttackType.DOUBLE) Console.WriteLine("MP가 부족합니다!");
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

            Monster curMonster = (Monster)monsters[monsterIdx];
            int monsterPrevHP = curMonster.Health;

            curMonster.TakeDamage(player.Attack * 2);  // 공격력 * 2 로 하나의 적 공격
            player.AttackWithMP(Player.MPAttackType.ALPHA);

            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.Name}의 알파 스트라이크 공격!");
            Console.WriteLine();

            Console.WriteLine($"Lv.() {curMonster.Name}");
            Console.WriteLine($"HP {monsterPrevHP} -> {curMonster.Health}\n");

            Console.WriteLine("0.다음");

            int input = Extension.GetInput(0, 0);
        }

        // 스킬 - 더블 스트라이크
        private void DoubleStrikeAttack()
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player.Name}의 더블 스트라이크 공격!");
            Console.WriteLine();

            List<int> randomIdx = GetRandomIdx(2, 0, monsters.Count);

            List<int> monsterPrevHPList = new List<int>();

            foreach (int idx in randomIdx)
            {
                monsterPrevHPList.Add(monsters[idx].Health);
                monsters[idx].TakeDamage((int)(player.Attack * 1.5));   // 공격력 * 1.5 로 2명의 적을 랜덤 공격
            }
            player.AttackWithMP(Player.MPAttackType.DOUBLE);

            Console.WriteLine();

            int prevHPidx = 0;
            foreach (int idx in randomIdx)
            {
                Console.WriteLine($"Lv.() {monsters[idx].Name}");
                Console.WriteLine($"HP {monsterPrevHPList[prevHPidx++]} -> {monsters[idx].Health}\n");
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
                if (randomIdx.Contains(currentNum))
                {
                    currentNum = new Random().Next(min, max);
                }
                randomIdx.Add(currentNum);
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

                int input = Extension.GetInput(0, 0);

                if (input == 0)
                {
                    break; 
                }
            }
        }



    }
}   
