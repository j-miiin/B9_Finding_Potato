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

        public Paprika(string name) : base(name, 80,25,4, image, desc, color) { }

        public override string AttackMessage()
        {
            string message = " ";
            switch (Random.Next(0, 2))
            {
                case 0:
                    message = "고함지르기!!";
                    break;

                case 1:
                    message = "씨 뿌리기!!";
                    break;
            }

            return message;
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
