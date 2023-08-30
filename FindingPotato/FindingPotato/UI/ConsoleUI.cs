using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    public class ConsoleUI
    {
        public static void PrintGameTitleUI()
        {
            int x = 25;
            int y = 5;
            Console.SetCursorPosition(x - 5, y++);
            Console.WriteLine("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓"); Console.SetCursorPosition(x, y++);
            Console.WriteLine(); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■■■■   ■   ■■      ■   ■■■      ■   ■■      ■      ■■■■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■         ■   ■ ■     ■   ■   ■     ■   ■ ■     ■     ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■■■■   ■   ■  ■    ■   ■    ■    ■   ■  ■    ■    ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■         ■   ■   ■   ■   ■     ■   ■   ■   ■   ■   ■      ■■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■         ■   ■    ■  ■   ■    ■    ■   ■    ■  ■    ■        ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■         ■   ■     ■ ■   ■   ■     ■   ■     ■ ■     ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("■         ■   ■      ■■   ■■■      ■   ■      ■■       ■■■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine(); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■■■■       ■■■     ■■■■■       ■       ■■■■■     ■■■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■      ■   ■      ■       ■          ■■          ■       ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■      ■   ■      ■       ■         ■  ■         ■       ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■■■■     ■      ■       ■        ■ ■ ■        ■       ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■           ■      ■       ■       ■      ■       ■       ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■           ■      ■       ■      ■        ■      ■       ■      ■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                  ■             ■■■         ■     ■          ■     ■         ■■■"); Console.SetCursorPosition(x, y++);
            Console.WriteLine(); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                                               〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓"); Console.SetCursorPosition(x, y++);
        }

        public static string GetUserName()
        {
            int x = 50;
            int y = 30;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine("┌────────────────────────────────────────────┐"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│  Enter Your Name >>                        │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("└────────────────────────────────────────────┘"); Console.SetCursorPosition(x, y++);

            y = 30;
            Console.SetCursorPosition(x + 10, y + 5);
            return Console.ReadLine();
        }
    }
}
