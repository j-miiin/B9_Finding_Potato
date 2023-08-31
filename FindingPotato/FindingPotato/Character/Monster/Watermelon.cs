using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Watermelon : Monster
    {
        static string image = "   \r\n  \r\n  \r\n   \r\n      .____&____.\r\n     /   //    // \\\r\n    /    o    o    \\\r\n  /│  \\\\  Д  \\\\   │\\\r\n /  \\   //     //  / \\\r\n     \\_\\\\__ ._\\\\_/\r\n        /      \\";
        public Watermelon(string name) : base(name, 60,20, 2, image) { }

        public override string AttackMessage()
        {
            return "몸통 박치기!";
        }
    }
}
