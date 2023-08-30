using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
     class HealthPotion : IConsumable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Effect { get; set; }
        public string Desc { get; set; }
        public int Quantity { get; set; }

        internal HealthPotion(string name, int effect, string desc)
        {
            Name = name;
            Effect = effect;
            Desc = desc;
            Quantity = 1;
            Type = ItemType.HealthPotion;
        }

        public void Use(Player player)
        {
            if (player.CurrentHealth == player.MaxHealth)
            {
                // HealthPotion 체력 최대치일 때 섭취 불가
                Console.SetCursorPosition(0, player.PlayerInventory.InventoryItems.Count + 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" 현재 체력이 최대입니다.           ");
                Console.WriteLine("                                   ");
                Console.WriteLine("                                   ");
                Thread.Sleep(2000);
                Console.ResetColor();
            }
            else
            {
                player.CurrentHealth += this.Effect;
                if (player.CurrentHealth > player.MaxHealth) player.CurrentHealth = player.MaxHealth;

                --this.Quantity;
                if (this.Quantity == 0) player.PlayerInventory.InventoryItems.Remove(this);
            }
        }
    }
}
