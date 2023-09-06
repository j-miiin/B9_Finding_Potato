using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Onion : Monster
    {
        static string image = "   \r\n    \r\n  \r\n  \r\n  \r\n      \r\n    __//|\\\\__\r\n   / /     \\ \\ \r\n  │  ￣Д￣  │ \r\n  /\\__\\___/__/\\ \r\n       / \\\r\n        ";

        static string desc = "눈 매워서 아무것도 못하죠? 킹받죠?";
        static ConsoleColor color = ConsoleColor.DarkYellow;

        public Onion(string name) : base(name, 70, 25, 3, image, desc, color) { }

        public override string AttackMessage()
        {
            return (Random.Next(0, 2) == 0) ? "양파즙 뿌리기!!" : "매운 향 뿜어내기!!";
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
