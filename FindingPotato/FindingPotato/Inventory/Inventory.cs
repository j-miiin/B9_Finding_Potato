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

        public static void ItemInfo(IItem item)
        {
            Console.Write("                     |                    |                    |                                        |                    "); // 간격 20 | 20 | 20 | 40 | 20

            Console.SetCursorPosition(6, Console.CursorTop);
            Console.Write(item.Name);

            Console.SetCursorPosition(26, Console.CursorTop);
            Console.Write(item.Type);

            Console.SetCursorPosition(46, Console.CursorTop);       // 아이템 효과 표시
            string effect = "";
            switch (item.Type)
            {
                case ItemType.StrengthPotion:
                    effect = "공격력";
                    break;
                case ItemType.HealthPotion:
                    effect = "체력 회복";
                    break;
                case ItemType.Weapon:
                    effect = "공격력";
                    break;
                case ItemType.Armor:
                    effect = "방어력";
                    break;
            }
            Console.Write($"{effect} + {item.Effect}");

            Console.SetCursorPosition(66, Console.CursorTop);
            Console.Write(item.Desc);

            Console.SetCursorPosition(106, Console.CursorTop);      // (소모품일 경우) 아이템 보유 개수
            string quantity = "";
                
            if (item.GetType().GetProperty("Quantity") != null)
            {
                var consumable = item as IConsumable;
                quantity = string.Format($"보유 중: {consumable.Quantity} 개");
            }
            Console.WriteLine(quantity);
            
        }

        public static void ListingItems(List<IItem> list, bool isManagement)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                return; // 리스트가 null이거나 비어있으면 메서드를 종료
            }

            Console.WriteLine("          [이름]              [종류]              [효과]                         [설명]");

            foreach (IItem item in list)
            {
                Inventory.ItemInfo(item);
            }

            PrintItemPrefixes(list.Count, isManagement);
        }

        private static void PrintItemPrefixes(int count, bool isManagement) // 리스트 앞 기호
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(isManagement ? $"{i}." : "-");
            }
        }

    }
}
