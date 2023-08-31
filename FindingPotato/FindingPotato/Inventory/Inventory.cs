using FindingPotato.Character;
using FindingPotato.Item;
using FindingPotato.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindingPotato.Inventory
{
    internal class InventoryClass
    {
        private static readonly Dictionary<ItemType, string> EffectDictionary = new Dictionary<ItemType, string>
        {
            { ItemType.StrengthPotion, "공격력 (1회)" },
            { ItemType.HealthPotion, "체력 회복" },
            { ItemType.Weapon, "공격력" },
            { ItemType.Armor, "방어력" }
        };


        public List<IItem> InventoryItems;
        public InventoryClass()
        {
             InventoryItems = new List<IItem>();
        }

        // isManagement는 GameManager의 ItemManagement에서 호출되었을 때  true  전달 
        public static void PrintTitle(bool isManagement)
        { 
            if (isManagement)
            {
                Console.SetCursorPosition(0, 7);
                Extension.CenterAlign(" - 아이템 장착 및 소모 -", ConsoleColor.Black, ConsoleColor.DarkGray);
            }
            Console.SetCursorPosition(0, 3);

            Extension.CenterAlign("▣==============▣  ", ConsoleColor.Black, ConsoleColor.Cyan);
            Extension.CenterAlign("||   인벤토리   ||", ConsoleColor.Black, ConsoleColor.Cyan);
            Extension.CenterAlign("▣==============▣  ", ConsoleColor.Black, ConsoleColor.Cyan);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n\n");
            Extension.CenterAlign("보유 중인 아이템을 관리할 수 있습니다.");
            Console.ResetColor();
        }

        public void ShowOptions(bool isManagement)       
        {
            Console.SetCursorPosition(52, 27);

            if (!isManagement)
            {
                Extension.ColorWriteLine("1. 아이템 장착 및 소모");
            }
            else
            { 
                Extension.ColorWriteLine("1. 해당 아이템 장착 및 소모");
            }

            Console.SetCursorPosition(52, 29);
            Extension.ColorWriteLine("0. 나가기");
        }

        public int PrintItemList(bool isManagement)
        {
            int input;
            Console.SetCursorPosition(0, 14);
            Extension.CenterAlign("------------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇------------      ");
            Console.WriteLine("\n");
            if (InventoryItems == null || InventoryItems.Count == 0)
            {
                Console.WriteLine("\n");
                Extension.CenterAlign("보유 중인 아이템이 없습니다.", ConsoleColor.Black, ConsoleColor.DarkGray);
                Console.WriteLine("\n\n");
                Extension.CenterAlign("------------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇------------      ");
                PrintBoarder();
                input = 0;
                
            }
            else
            {
                Console.SetCursorPosition(9, 20 + InventoryItems.Count);
                Extension.CenterAlign("------------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇----------◇------------      ");
                PrintBoarder();

                if (!isManagement)
                {
                    Console.SetCursorPosition(0, 17);
                    foreach (IItem item in InventoryItems)
                    {
                        Extension.CenterAlign(PrintItemInfo(item));
                    }
                    input = 1;
                }
                else
                {
                    string[] items = new string[InventoryItems.Count + 2];

                    for (int i = 0; i < InventoryItems.Count; i++)
                    {
                        items[i] = PrintItemInfo(InventoryItems[i]);
                    }

                    string star = new string('*',  50);
                    string exit = string.Format($"    {star}    나가기    {star}");
                    items[InventoryItems.Count + 1] = exit;//.PadRight(items[0].Length + items[0].Count(c => c >= '\uAC00' && c <= '\uD7AF') - exit.Count(c => c >= '\uAC00' && c <= '\uD7AF')); 
                    items[InventoryItems.Count] = "";
                    int x = 15; int y = 17; 

                    input = UIExtension.GetPlayerSelectFromUI(x, y, 1, items, true);
                }
                
            }
            return input;
        }


        private static string PrintItemInfo(IItem item)
        {
            //리스트 출력 내용 하나도 합치기
            string equipMark = (item is IEquipable equipable && equipable.IsEquipped) ? "[E] " : "    ";
            string itemName = item.Name.PadRight(13 - item.Name.Count(c => c >= '\uAC00' && c <= '\uD7AF'));
            string itemType = item.Type.ToString().PadRight(18);
            string itemEffect = "";
            string effect;
            if (EffectDictionary.TryGetValue(item.Type , out effect)) { itemEffect = effect.PadRight(12 - effect.Count(c => c >= '\uAC00' && c <= '\uD7AF')) + string.Format($" + {item.Effect}").PadRight(6); }
            string itemDesc = item.Desc.PadRight(38 - item.Desc.Count(c => c >= '\uAC00' && c <= '\uD7AF'));
            string itemCount = item is IConsumable consumable ? string.Format($"보유 중 : {consumable.Quantity.ToString()} 개") : " ";
            string endPart = itemCount.PadRight(18 - itemCount.Count(c => c >= '\uAC00' && c <= '\uD7AF'));

            string itemInfo = string.Format($"{equipMark}{itemName}|  {itemType}|  {itemEffect}|  {itemDesc}|  {endPart}");
            return itemInfo;
        }

        private static void WriteAtPosition(string text, int position, int line)
        {
            Console.SetCursorPosition(position, line);
            Console.Write(text);
        }

        public static void PrintBoarder()
        {
            Console.SetCursorPosition(10, 1);
            string horizontal = new string('─', 128);
            Console.WriteLine($"◈{horizontal}◈");
            for (int i = 0; i < 42; i++)
            {
                Console.SetCursorPosition(10, Console.CursorTop);
                Console.Write("│");
                Console.SetCursorPosition(140, Console.CursorTop);
                Console.WriteLine("│");
            }
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.WriteLine($"◈{horizontal}◈");
        }

        public static void PrintWarningBox()
        {
            Console.SetCursorPosition(0, 28);
            Extension.CenterAlign("┌──────────────────────────────────────────────────────────────────────────┐");
            Extension.CenterAlign("│                                                                          │");
            Extension.CenterAlign("│                                                                          │");
            Extension.CenterAlign("│                                                                          │");
            Extension.CenterAlign("│                                                                          │");
            Extension.CenterAlign("│                                                                          │");
            Extension.CenterAlign("└──────────────────────────────────────────────────────────────────────────┘");

        }
       
    }
}
