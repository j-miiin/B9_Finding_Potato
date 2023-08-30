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
                Console.SetCursorPosition(15, 24); // 메시지 위치 잡기
                Extension.ColorWriteLine("현재 체력이 최대입니다.           ", ConsoleColor.Black, ConsoleColor.Red);
                Console.WriteLine("                                   ");
                Console.WriteLine("                                   ");
                Thread.Sleep(2000);
            }
            else
            {
                player.CurrentHealth += this.Effect;
                if (player.CurrentHealth > player.MaxHealth) player.CurrentHealth = player.MaxHealth;

                --this.Quantity;
                if (this.Quantity == 0) player.PlayerInventory.InventoryItems.Remove(this);
                UseMessage(player);
            }
        }

        public void UseMessage(Player player)
        {
            Console.SetCursorPosition(15, 24); // 메시지 위치 잡기
            Extension.ColorWriteLine($"체력을 + {Effect} 회복했습니다.           ", ConsoleColor.Black, ConsoleColor.Green);
            Console.WriteLine("                                           ");
            Console.WriteLine("                                         ");
            Thread.Sleep(2000);
        }
    }
}
