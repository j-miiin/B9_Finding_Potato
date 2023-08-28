using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal class HealthPotion : IItem
    {
        public string Name => "체력 포션";

        public void Use(Player player)
        {
            Console.WriteLine("체력 포션을 사용합니다. 체력이 50 증가합니다.");
            player.Health += 50;
            if (player.Health > 100) player.Health = 100;
        }

    }
}
