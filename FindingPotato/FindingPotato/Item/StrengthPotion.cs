using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal class StrengthPotion : IItem
    {
        public string Name => "공격력 포션";

        public void Use(Player player)
        {
            Console.WriteLine("공격력 포션을 사용합니다. 공격력이 10 증가합니다.");
            player.AttackPower += 10;
        }
    }
}
