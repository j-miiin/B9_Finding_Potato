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

        static string desc = "나를 만날 \"수박\"에";
        static ConsoleColor color = ConsoleColor.DarkGreen;

        public Watermelon(string name) : base(name, 60, 20, 2, image, desc, color) { }

        public override string AttackMessage()
        {
            return "몸통 박치기!";
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x, y);
            y += 15;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{Level} {Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
