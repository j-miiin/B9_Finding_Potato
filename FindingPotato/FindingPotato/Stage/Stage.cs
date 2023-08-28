﻿using FindingPotato.Character;
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
        private ICharacter player; // 플레이어
        //private ICharacter monster; // 몬스터
        private List<IItem> rewards; // 보상 아이템들

        private List<ICharacter> monsters;

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        public StageClass(ICharacter player, List<ICharacter> monsters, List<IItem> rewards)
        {
            this.player = player;
            this.monsters = monsters;
            this.rewards = rewards;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출
        }

        // 스테이지 시작 메서드
        public void Start()
        {
            //플레이어가 공격모드 전환
            bool bPlayerAttackMode = false;

            while (true)
            {
                Console.Clear();

                //Character 생사 확인
                if (player.IsDead) 
                    break;
                else if (monsters.All(x => x.IsDead))
                    break;

                // 안내 문자열 
                string guideStr = (bPlayerAttackMode ? "대상을 선택해주세요." : "원하시는 행동을 입력해주세요.");
                //선택 문자열
                string selectStr = (bPlayerAttackMode ? "0.취소" : "1.공격");

                Console.WriteLine("Battle!!!\n");

                // 몬스터 정보
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($"{(bPlayerAttackMode ? i + 1 + "." : "")}{monsters[i].Name}  {(monsters[i].IsDead ? "Dead" : "HP " + monsters[i].Health)}");
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]");
                Console.WriteLine($"Lv.player.level {player.Name}");
                Console.WriteLine($"HP {player.Health}/player.MaxHealth");
                Console.WriteLine();
                Console.WriteLine(selectStr);
                Console.WriteLine();
                Console.WriteLine(guideStr);
                Console.Write(">> ");

                string? input = Console.ReadLine();

                bool isValid = int.TryParse(input, out int select);

                if (isValid)
                {
                    if (bPlayerAttackMode == false) //플레이어가 공격모드가 아닐 때  
                    {
                        if (select == 1)
                        {
                            bPlayerAttackMode = true;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Thread.Sleep(500);
                        }
                    }
                    else if (bPlayerAttackMode)// 플레이어가 공격모드일 때 
                    {
                        if (select >= 1 && select <= 3)
                        {
                            if (monsters[select-1].IsDead) // 죽은 몬스터는 선택 X
                            {
                                Console.WriteLine($"{monsters[select - 1].Name}은(는) 이미 죽었습니다.");
                                Thread.Sleep(500);
                            }
                            else
                            {
                                PlayerAttackScreen(monsters[select - 1]); //플레이어 공격 화면 
                                EnenyPhase(); //몬스터 공격화면 
                                bPlayerAttackMode = false;
                            }
                        }
                        else if (select == 0)
                            bPlayerAttackMode = false;
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
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }

        //플레이어 공격 화면
        void PlayerAttackScreen(ICharacter monster)
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
                Console.WriteLine($"HP {previousHP} -> {monster.Health}\n");

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

                    if (isValid && select == 0)
                        break;
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

                if (isValid && select == 0)
                    break;
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(500);
                }
            }
        }
    }
}   
