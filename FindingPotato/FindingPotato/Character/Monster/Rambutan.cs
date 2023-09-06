using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Rambutan :Monster
    {
        static string image = "  \r\n  \r\n  \r\n  \r\n  \r\n  ~,--♨--,~\r\n ~/         \\~\r\n~│ #＞目＜# │~\r\n ~\\+       +/~\r\n   ~`--+--'~\r\n";

        static string desc = "슉 슈슉 ㅅ슉 슈슈슉";
        static ConsoleColor color = ConsoleColor.Magenta;

        public Rambutan(string name) : base(name, 60, 20, 2, image, desc, color) { }

        public override string AttackMessage()
        {
            return "찌르기!";
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
