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

        private static readonly Dictionary<ItemType, string> EffectDictionary = new Dictionary<ItemType, string>
        {
            { ItemType.StrengthPotion, "공격력" },
            { ItemType.HealthPotion, "체력 회복" },
            { ItemType.Weapon, "공격력" },
            { ItemType.Armor, "방어력" }
        };

        private static void WriteAtPosition(string text, int position)
        {
            Console.SetCursorPosition(position, Console.CursorTop);
            Console.Write(text);
        }

        private static void ItemInfo(IItem item)
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


        public static void ListingItems(List<IItem> list, bool isManagement)
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

        public static void ItemManager(IItem item)
        {
            // 장착에 따른 효과 적용 구현 예정
        }
    }
}
