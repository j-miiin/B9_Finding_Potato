﻿using FindingPotato.Character.Monster;
using FindingPotato.Character;
using FindingPotato.Item;
using FindingPotato.Stage;
using System;
using System.Security.Cryptography;
using System.Dynamic;
using System.ComponentModel.Design;
using FindingPotato.Inventory;
using FindingPotato.UI;

namespace FindingPotato
{
    internal class Program
    {
        static void Main()
        {
            Console.WindowHeight = 50;
            Console.WindowWidth = 150;
            GameManager GM = new GameManager();
            GM.InitialCharacter();
            GM.GameMain();
        }
    }
}

public class GameManager
{
    Random random = new Random();

    private Player player;

    //몬스터 생성
    Banana banana;
    Durian durian;
    Rambutan rambutan;
    Watermelon watermelon;
    Beet beet; 
    Paprika paprika;
    Onion onion;
    Customer customer;

    // 아이템 생성
    // 소모 아이템
    // stage 1
    static IItem water = new HealthPotion("물", 20, "웅덩이에 고여 있던 물.");
    static IItem firtilizer = new StrengthPotion("비료", 10, "밭에서 챙긴 비료.");
    // stage 2
    static IItem nutrient = new HealthPotion("식물 영양제", 50, "오는 길에 훔친 영양제.");
    static IItem pesticide = new StrengthPotion("농약", 20, "각성.");
  
    //장착 아이템
    // stage 1
    static IItem toothpick = new Weapon("이쑤시개", 10, "뾰족하다.");
    static IItem plastic = new Armor("비닐", 5, "얇지만 유용하다.");
    // stage 2
    static IItem peeler = new Weapon("감자 필러", 15, "날카롭다.");
    static IItem styrofoam = new Armor("스티로폼", 10, "충격 완화.");
  
    static List<IItem> ConsumableItemList = new List<IItem>() { water, firtilizer, nutrient,  pesticide };
    static List<IItem> EquipableItemList = new List<IItem>() {  toothpick, plastic, peeler, styrofoam };

    // 몬스터 리스트
    List<Monster> EasyMonsters = new List<Monster>();
    List<Monster> NormalMonsters = new List<Monster>();
    List<Monster> HardMonsters = new List<Monster>();
    
    //전투 스테이지
    StageClass stage1;
    StageClass stage2;
    StageClass stage3;

    public GameManager()
    {
        //몬스터 초기화 
        banana = new Banana("바나나");
        durian = new Durian("두리안");
        rambutan = new Rambutan("람부탄");
        watermelon = new Watermelon("수박");

        beet = new Beet("비트"); 
        paprika = new Paprika("파프리카");
        onion = new Onion("양파");
     
        customer = new Customer("굶주린 자취생");

        EasyMonsters = new List<Monster> { banana, durian, rambutan, watermelon };
        NormalMonsters = new List<Monster> { beet, paprika, onion };
        HardMonsters = new List<Monster> { customer };

        //UI
        Console.SetWindowSize(150, 50);
    }

    //몬스터 목록에서 랜덤하게 선택된 몬스터 리스트 반환 (중복X) 
    List<Monster> CreateRandomMonsterLineup(List<Monster> monsters, int numberOfMonsters)
    {
        Random random = new Random();

        //사용가능한 몬스터 (중복 방지를 피하기 위해 초기에 몬스터 리스트 복사)
        List<Monster> availableMonsters = new List<Monster>(monsters);

        //선택된 몬스터 
        List<Monster> selectedMonsters = new List<Monster>();

        // 1~numberOfMonsters 사이에서 랜덤한 값 저장
        numberOfMonsters = random.Next(2, numberOfMonsters+1);

        for (int i = 0; i < numberOfMonsters; i++)
        {
            //사용가능한 몬스터가 없을 경우 종료
            if (availableMonsters.Count == 0)
            {
                break;
            }

            //사용가능한 몬스터 리스트에서 랜덤한 인덱스 선택 
            int randomIndex = random.Next(availableMonsters.Count);

            //선택된 몬스터를 선택된 몬스터 리스트에 추가하고 사용가능한 몬스터 리스트에서는 삭제 
            Monster selectedMonster = availableMonsters[randomIndex];
            selectedMonsters.Add(selectedMonster);
            availableMonsters.RemoveAt(randomIndex);
        }
       
        return selectedMonsters;
    }

    // 캐릭터 생성 - 이름, 직업
    public void InitialCharacter()
    {
        StartSceneUI.PrintGameTitleUI();
        string playerName = StartSceneUI.GetUserName();

        // 직업 설정 - enum(int)
        Console.Clear();
        StartSceneUI.PrintGameTitleUI();
        int playerType = StartSceneUI.GetPlayerType();

        player = new Player(playerName, (VegetableType)playerType);
    }

    // 메인 화면
    public void GameMain()
    {
        while (true)
        {
            Console.Clear();

            int input = SelectActivitySceneUI.GetPlayerActivity(player.Name);
            
            if (input == 1) { ShowStatus(); }
            else if (input == 2) { ShowInventory(); }
            else if(input == 3)

            { 
                ShowStageSelection();
            }
            else return;
        }
    }
    //스테이지 선택 화면 
    public void ShowStageSelection()
    {
        while(true)
        {
            Console.Clear();
            int input = SelectStageScene.GetStageSelect(player.CurrentStage);

            if (input == 1)
            {
                List<IItem> itemRewards = GetStageRewards(input);
                stage1 = new StageClass(player, CreateRandomMonsterLineup(EasyMonsters, 3), itemRewards, StageDifficulty.Easy);
                stage1.Start();
                player.PotionEffectReset();
                break;
            }
            else if (input == 2)
            {
                if (player.CurrentStage >= (int)StageDifficulty.Normal)
                {
                    List<Monster> monsters = CreateRandomMonsterLineup(NormalMonsters, 3);
                    monsters.AddRange(CreateRandomMonsterLineup(EasyMonsters, 2));
                    List<IItem> itemRewards = GetStageRewards(input);
                    stage2 = new StageClass(player, monsters, itemRewards, StageDifficulty.Normal);
                    stage2.Start();
                    player.PotionEffectReset();
                    break;
                }

            }
            else if (input == 3)
            {
                if (player.CurrentStage >= (int)StageDifficulty.Hard)
                {
                    List<IItem> itemRewards = new List<IItem>();
                    stage3 = new StageClass(player, HardMonsters, itemRewards, StageDifficulty.Hard);
                    stage3.Start();
                    player.PotionEffectReset();
                }
                else
                {
                    Console.WriteLine("아직 감자 진열대는 보이지 않는다.");
                    Thread.Sleep(500);
                }
            }
            else break;
        }
    }

    // 상태 보기
    public void ShowStatus()
    {
        Console.Clear();
        Console.WriteLine($"◇----------◇----------◇----------");
        Console.WriteLine($"| {player.Name}      ({player.Type})");
        Console.WriteLine($"| Lv. {player.Level}");
        Console.WriteLine("|");
        Console.WriteLine($"| 체  력 : {player.CurrentHealth}/{player.MaxHealth}");
        Console.Write($"| 공격력 : {player.AttackPower}");
        if (player.AddAtk != 0) { Extension.ColorWriteLine($"  + {player.AddAtk}", ConsoleColor.Black, ConsoleColor.Green); }
        else { Console.WriteLine(); }
        Console.Write($"| 방어력 : {player.Defense}");
        if (player.AddDef != 0) { Extension.ColorWriteLine($"  + {player.AddDef}", ConsoleColor.Black, ConsoleColor.Green); }
        else { Console.WriteLine(); }
        Console.WriteLine($"| 마  력 : {player.CurrentMP}/{player.MaxMP}");
        Console.WriteLine($"◇----------◇----------◇----------");

        Extension.ColorWriteLine("\n0. 나가기");

        _ = Extension.GetInput(0, 0);
    }

    public void ShowInventory()
    {
        while( true)
        {
            Console.Clear();

            InventoryClass.PrintTitle(false);
            player.PlayerInventory.PrintItemList(false);

            string[] options = { " 1. 아이템 장착 및 소모 ", " 0. 나가기              " };

            int x = 63; int y = 33;

            int input = UIExtension.GetPlayerSelectFromUI(x, y, 4, options, true);

            if (input == 0) break;
            else { ItemManagement(); }
        }
    }

    public void ItemManagement()
    {
        while (true)
        {
            Console.Clear();

            UIExtension.DrawCharacter(durian.Image, 10, 10);
            UIExtension.DrawCharacter(onion.Image, 28, 10);
            UIExtension.DrawCharacter(beet.Image, 46, 10);
            UIExtension.DrawCharacter(banana.Image, 64, 10);
            UIExtension.DrawCharacter(paprika.Image, 82, 10);
            UIExtension.DrawCharacter(rambutan.Image, 100, 10);
            UIExtension.DrawCharacter(watermelon.Image, 118, 10);
            UIExtension.DrawCharacter(player.Image, 50, 23);








            int input = Extension.GetInput(0, player.PlayerInventory.InventoryItems.Count);

            if (input == 0) { break; }
            else
            {
                player.PlayerInventory.InventoryItems[input - 1].Use(player);
                ItemManagement();
                return;
            }
        }
    }

    private List<IItem> GetStageRewards(int curStageNum)
    {
        // 각 스테이지의 보상 아이템들
        List<IItem> stageRewards = new List<IItem>();
        // 리스트 앞부분 절반에는 소모 가능한 아이템, 뒷부분 절반에는 착용 가능한 아이템을 담음
        int startIdx = (curStageNum == 1) ? 0 : 2;
        for (int i = startIdx; i < startIdx + 2; i++) stageRewards.Add(ConsumableItemList[i]);
        for (int i = startIdx; i < startIdx + 2; i++) stageRewards.Add(EquipableItemList[i]);
        return stageRewards;
    }
}