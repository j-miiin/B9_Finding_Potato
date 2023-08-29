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
            player.AddAtk += this.Effect;
        }

    }
}
