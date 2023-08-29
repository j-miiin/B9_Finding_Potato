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
            player.AddAtk += this.Effect;
        }

    }
}
