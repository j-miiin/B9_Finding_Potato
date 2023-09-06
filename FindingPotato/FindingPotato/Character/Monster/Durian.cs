using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Durian : Monster
    {
        static string image = "   \r\n  \r\n  \r\n  \r\n       ___\r\n    ____|____\r\n   / \\/\\ /\\/ \\ \r\n  │  ㅡωㅡ  │ \r\n  /\\/ \\ /\\/ \\/\\   \r\n /  \\/_\\_/_\\/  \\  \r\n       / \\\r\n";

        static string desc = "우리 두리안~";
        static ConsoleColor color = ConsoleColor.DarkGreen;

        public Durian(string name) : base(name, 50, 20, 1, image, desc, color) { }

        public override string AttackMessage()
        {
           return "냄새 풍기기!!";
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x, y);
            y += 15;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{base.Level} {base.Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
