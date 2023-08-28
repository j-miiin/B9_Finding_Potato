using FindingPotato.Character.Monster;
using FindingPotato.Character;
using FindingPotato.Item;
using FindingPotato.Stage;
using System;
using System.Security.Cryptography;
using FindingPotato.Inventory;

namespace FindingPotato
{
    internal class Program
    {
        static void Main()
        {
            GameManager GM = new GameManager();
            GM.InitialCharacter();
            GM.GameMain();
        }
    }
}

public class GameManager
{
    private Player player;

    Paprika paprika;
    Onion onion;
    Banana banana;

    List<IItem> stageRewards;

    //전체 몬스터 리스트
    List<ICharacter> monsters = new List<ICharacter>();

    //스테이지 입장할 몬스터 리스트
    List<ICharacter> RandomMonster = new List<ICharacter>();

    StageClass stage;

    public GameManager()
    {
        paprika = new Paprika("파프리카");
        onion = new Onion("양파");
        banana = new Banana("바나나");

        monsters.Add(onion);
        monsters.Add(paprika);
        monsters.Add(banana);

        // 각 스테이지의 보상 아이템들
        //stageRewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };

        // 스테이지
    }

    static void ShuffleList(List<ICharacter> list)
    {
        Random random = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }

    // 캐릭터 생성 - 이름, 직업
    public void InitialCharacter()
    {
        // 이름 설정 - string
        Extension.TypeWriting("이름 ?\n");
        Console.Write(">> ");
        string playerName = Console.ReadLine();

        // 직업 설정 - enum(int)
        Extension.TypeWriting("\n정체\n");

        Extension.ColorWriteLine("1. 감자");
        Extension.ColorWriteLine("2. 고구마");
        Extension.ColorWriteLine("3. 당근");

        int playerType = Extension.GetInput(1, 3);
        player = new Player(playerName, (VegetableType)playerType);
    }

    // 메인 화면
    public void GameMain()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Extension.TypeWriting($"어서오세요. {player.Name} 님");
            Extension.TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            Extension.ColorWriteLine("1. 상태 보기");
            Extension.ColorWriteLine("2. 인벤토리");
            Extension.ColorWriteLine("3. 전투 시작");
            Extension.ColorWriteLine("\n0. 게임 종료");

            int input = Extension.GetInput(0, 3);

            if (input == 1) { ShowStatus(); }
            else if (input == 2) { ShowInventory(); }
            else if(input == 3)
            {
                ShuffleList(monsters);
                //스테이지 입장할 몬스터리스트에 기존 몬스터 3마리 추가 
                for (int i = 0; i < 3; i++)
                {
                    RandomMonster.Add(monsters[i]);
                }
                stage = new StageClass(player, RandomMonster, stageRewards);
                stage.Start(); 
            }
            else return;
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
        Console.WriteLine($"| 체  력 : {player.Health}");
        Console.WriteLine($"| 공격력 : {player.AttackPower}");
        Console.WriteLine($"| 방어력 : {player.Defense}");
        Console.WriteLine($"◇----------◇----------◇----------");

        Extension.ColorWriteLine("\n0. 나가기");

        _ = Extension.GetInput(0, 0);
    }

    public void ShowInventory()
    {
        Console.Clear();

        Inventory.PrintTitle();
        Inventory.ListingItems(player.Inventory, false);
        Inventory.ShowOptions();

        int input = Extension.GetInput(0, 1);

        if (input == 0) return;
        else { ItemManagement(); }
    }

    public void ItemManagement()
    {
        Inventory.PrintTitle();
        Inventory.ListingItems(player.Inventory, true);
        Inventory.ShowOptions();

        int input = Extension.GetInput(0, player.Inventory.Count);

        if (input == 0) { ShowInventory(); }
        else { Inventory.ItemManager(player.Inventory[input - 1]); }
    }
}