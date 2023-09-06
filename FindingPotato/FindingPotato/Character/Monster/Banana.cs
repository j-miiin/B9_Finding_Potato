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

        static string desc = "다들 왜 내 껍질만 밟으면 넘어지는지 모르겠어";
        static ConsoleColor color = ConsoleColor.Yellow;
        
        public Banana(string name) : base(name, 50, 20, 1, image, desc, color) { }

        public override string AttackMessage()
        {
            return "껍질 날리기!";
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x, y);
            x -= 10; y += 15;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{base.Level} {base.Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
