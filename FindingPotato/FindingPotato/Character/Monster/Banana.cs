using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Banana : Monster
    {
        static string image = "         _\r\n        / \\   \r\n       /   \\\r\n      |     |\r\n      |⊙x⊙|  \r\n      |     | \r\n     /_     _\\\r\n    /  \\   /  \\\r\n   / |  \\ / |\\ \\\r\n   \\ \\      // /\r\n    \\/\\    / \\/\r\n       \\  /\r\n        ■";
        public Banana(string name) : base(name, 50,20,1, image) { }

        public override string AttackMessage()
        {
            return "껍질 날리기!";
        }
    }
}
