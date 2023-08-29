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
            player.CurrentHealth += this.Effect;
            if (player.CurrentHealth > player.MaxHealth) player.CurrentHealth = player.MaxHealth;

            --this.Quantity;
            if (this.Quantity == 0) player.Inventory.Remove(this);
        }
    }
}
