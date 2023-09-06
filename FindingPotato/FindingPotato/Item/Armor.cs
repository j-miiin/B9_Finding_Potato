using FindingPotato.Character;
using FindingPotato.Inventory;
using FindingPotato.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FindingPotato.Item
{
    internal class Armor : IEquipable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Effect { get; set; }
        public string Desc { get; set; }
        public bool IsEquipped { get; set; }

        internal Armor(string name, int effect, string desc)
        {
            Name = name;
            Effect = effect;
            Desc = desc;
            IsEquipped = false;
            Type = ItemType.Armor;
        }

        public void Use(Player player)
        {
            IEquipable foundItem = player.PlayerInventory.InventoryItems
               .OfType<IEquipable>()
               .FirstOrDefault(i => i.IsEquipped && i.Type == Type && i.Name != Name);

            InventoryClass.PrintWarningBox();

            if (foundItem != null)
            {
                Console.SetCursorPosition(0, 30);
                Extension.CenterAlign($"현재 {foundItem.Name}을/를 장착 중입니다. {Name}으로 교체하시겠습니까?");

                string[] options = { "  1. 교체하기     ", "  0. 취소         " };

                int input = UIExtension.GetPlayerSelectFromUI(63, 36, 3, options, true);

                if (input == 0) { return; }
                else { foundItem.IsEquipped = false; }
            }

            if (!this.IsEquipped) player.AddDef += this.Effect;
            else player.AddDef -= this.Effect;

            this.IsEquipped = !this.IsEquipped;

            UseMessage(player);
        }

        public void UseMessage(Player player)
        {
            InventoryClass.PrintWarningBox();

            Console.SetCursorPosition(0, 30);
            if (IsEquipped)
            {
                Extension.CenterAlign($"                      {Name} 을/를 장착했습니다.                    ", ConsoleColor.Black, ConsoleColor.Green);
                Extension.CenterAlign($"방어력이 + {Effect} 증가합니다.", ConsoleColor.Black, ConsoleColor.Green);
            }
            else
            {
                Extension.CenterAlign($"                    {Name}을/를 장착 해제 했습니다.                     ", ConsoleColor.Black, ConsoleColor.Green);
                Extension.CenterAlign("                                         ");
            }
            Extension.CenterAlign("                                           ");
            Thread.Sleep(2000);
        }
    }
}
