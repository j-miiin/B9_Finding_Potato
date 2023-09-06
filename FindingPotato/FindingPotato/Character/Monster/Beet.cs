using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Beet :Monster
    {
        static string image = "   \r\n  \r\n  \r\n  \r\n      \r\n    __\\|/__\r\n  /         \\ \r\n │   ￣Д￣ │ \r\n /\\         /\\ \r\n/  \\______ /  \\\r\n      / \\\r\n";

        static string desc = "줘 근데 할말 있숴요 This is Competition";
        static ConsoleColor color = ConsoleColor.DarkMagenta;

        public Beet(string name) : base(name, 70, 25, 3, image, desc, color) { }

        public override string AttackMessage()
        {
            return (Random.Next(0, 2) == 0) ? "디스 랩 하기!!" : "얼룩 제거 하기!!";
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x, y);
            x -= 10;
            y += 15;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{base.Level} {base.Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
