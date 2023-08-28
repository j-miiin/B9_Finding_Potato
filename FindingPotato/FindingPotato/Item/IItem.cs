using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    enum ItemType
    {
        HealthPotion,
        StrengthPotion,
        Weapon,
        Armor
    }
    interface IItem
    {

        string Name { get; set; }
        ItemType Type { get; set; }
        int Effect { get; set; }
        string Desc { get; set; }

        void Use(Player player);

    }
}