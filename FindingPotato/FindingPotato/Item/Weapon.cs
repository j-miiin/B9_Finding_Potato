using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal class Weapon : IEquipable
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public int Effect { get; set; }
        public string Desc { get; set; }
        public bool IsEquipped { get; set; }

        internal Weapon(string name, int effect, string desc)
        {
            Name = name;
            Effect = effect;
            Desc = desc;
            IsEquipped = false;
            Type = ItemType.Weapon;
        }

        public void Use(Player player)
        {
            if (!this.IsEquipped) player.AddAtk += this.Effect;
            else player.AddAtk -= this.Effect;

            this.IsEquipped = !this.IsEquipped;

            UseMessage(player);
        }

        public void UseMessage(Player player)
        {
            Console.SetCursorPosition(15, 24); // 메시지 위치 잡기
            if (IsEquipped)
            {
                Extension.ColorWriteLine($" {Name} 을/를 장착했습니다.           ", ConsoleColor.Black, ConsoleColor.Green);
                Console.SetCursorPosition(15, Console.CursorTop);
                Extension.ColorWriteLine($" 공격력이 + {Effect} 증가합니다.", ConsoleColor.Black, ConsoleColor.Green);
            }
            else
            {
                Extension.ColorWriteLine($" {Name}을/를 장착 해제 했습니다.           ", ConsoleColor.Black, ConsoleColor.Green);
                Console.WriteLine("                                         ");
            }
            Console.WriteLine("                                         ");
            Thread.Sleep(2000);
        }
    }
}
