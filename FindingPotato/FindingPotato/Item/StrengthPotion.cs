using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal class StrengthPotion : IConsumable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Effect { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }

        internal StrengthPotion(string name, int effect, string desc)
        {
            Name = name;
            Effect = effect;
            Desc = desc;
            Quantity = 1;
            Type = ItemType.StrengthPotion;
        }

        public void Use(Player player)
        {
            player.potionEffect = this.Effect;

            player.AddAtk += this.Effect;
            --this.Quantity;
            if (this.Quantity == 0) player.PlayerInventory.InventoryItems.Remove(this);
            UseMessage(player);
        }

        public void UseMessage(Player player)
        {
            Console.SetCursorPosition(52, 27);
            Extension.ColorWriteLine($"공격력 + {Effect}이 전투 1회동안 지속됩니다.           ", ConsoleColor.Black, ConsoleColor.Green);
            Console.SetCursorPosition(52, Console.CursorTop);
            Console.WriteLine("                                           ");
            Console.SetCursorPosition(52, Console.CursorTop);
            Console.WriteLine("                                         ");
            Thread.Sleep(2000);
        }
    }
}
