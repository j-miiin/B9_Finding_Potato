using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Item
{
    internal interface IItem
    {
        string Name { get; }
        void Use(Player player); // 전사에게 아이템을 사용하는 메서드
    }
}
