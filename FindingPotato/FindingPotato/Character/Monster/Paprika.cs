using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Paprika : Monster
    {
        static string image = "    \r\n  \r\n  \r\n  \r\n  \r\n     _  /\\  _\r\n   /   \\/ \\/  \\\r\n  │   \\   /   │ \r\n  /\\    Д    /\\ \r\n /  \\________/  \\   \r\n       / \\\r\n";

        static string desc = "ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㄱ!!!!!!";
        static ConsoleColor color = ConsoleColor.Green;

        public Paprika(string name) : base(name, 80, 25, 4, image, desc, color) { }

        public override string AttackMessage()
        {
            return (Random.Next(0, 2) == 0) ? "고함지르기!!" : "씨 뿌리기!!";
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x, y);
            x -= 10;
            y += 15;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{Level} {Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
