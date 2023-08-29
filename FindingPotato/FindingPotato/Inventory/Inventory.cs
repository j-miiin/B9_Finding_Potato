using FindingPotato.Character;
using FindingPotato.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Inventory
{
    internal class Inventory
    {
        private static readonly Dictionary<ItemType, string> EffectDictionary = new Dictionary<ItemType, string>
        {
            { ItemType.StrengthPotion, "공격력" },
            { ItemType.HealthPotion, "체력 회복" },
            { ItemType.Weapon, "공격력" },
            { ItemType.Armor, "방어력" }
        };

        public static void PrintTitle()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        }

        public static void ShowOptions()       // 수정하기
        {

            Console.WriteLine("");
            Console.WriteLine("\n0. 나가기");
        }

        public static void PrintItemList(List<IItem> list, bool isManagement)
        {

            Console.SetCursorPosition(0, 4);

            if (list == null || list.Count == 0)
            {
                Console.WriteLine("\n보유 중인 아이템이 없습니다.\n");
                return; // 리스트가 비어있으면 메서드를 종료
            }

            Console.WriteLine("          [이름]              [종류]              [효과]                         [설명]");

            foreach (IItem item in list)
            {
                Inventory.PrintItemInfo(item);
            }

            // 리스트 앞 기호 출력
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(isManagement ? $"{i}." : "-");
            }

        }


        private static void PrintItemInfo(IItem item)
        {
            Console.Write("                     |                    |                    |                                        |                    "); // 간격 20 | 20 | 20 | 40 | 20


            if (item is IEquipable equipable) // 장착 중인 아이템의 경우 장착 표시
            {
                if (equipable.IsEquipped) { WriteAtPosition("[E]", 3); }
            }

            WriteAtPosition(item.Name, 6);
            WriteAtPosition(item.Type.ToString(), 26);

            if (EffectDictionary.TryGetValue(item.Type, out var effect))
            {
                WriteAtPosition($"{effect} + {item.Effect}", 46);
            }

            WriteAtPosition(item.Desc, 66);

            if (item is IConsumable consumable) // 소모품 개수 표시
            {
                WriteAtPosition($"보유 중: {consumable.Quantity} 개", 106);
            }

            Console.WriteLine();
        }


        private static void WriteAtPosition(string text, int position)
        {
            Console.SetCursorPosition(position, Console.CursorTop);
            Console.Write(text);
        }

       

        

        public static void ItemManager(IItem item, Player player)
        {
            item.Use(player);
            //소모품일 경우
            //장착템일 경우
        }
    }
}
