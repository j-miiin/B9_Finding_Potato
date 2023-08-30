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
            int y = 5;
            Console.SetCursorPosition(10, y++);
            Console.WriteLine("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓"); Console.SetCursorPosition(15, y++);
            Console.WriteLine(); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■■■■   ■   ■■      ■   ■■■      ■   ■■      ■      ■■■■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■         ■   ■ ■     ■   ■   ■     ■   ■ ■     ■     ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■■■■   ■   ■  ■    ■   ■    ■    ■   ■  ■    ■    ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■         ■   ■   ■   ■   ■     ■   ■   ■   ■   ■   ■      ■■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■         ■   ■    ■  ■   ■    ■    ■   ■    ■  ■    ■        ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■         ■   ■     ■ ■   ■   ■     ■   ■     ■ ■     ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("■         ■   ■      ■■   ■■■      ■   ■      ■■       ■■■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine(); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■■■■       ■■■     ■■■■■       ■       ■■■■■     ■■■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■      ■   ■      ■       ■          ■■          ■       ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■      ■   ■      ■       ■         ■  ■         ■       ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■■■■     ■      ■       ■        ■ ■ ■        ■       ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■           ■      ■       ■       ■      ■       ■       ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■           ■      ■       ■      ■        ■      ■       ■      ■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                  ■             ■■■         ■     ■          ■     ■         ■■■"); Console.SetCursorPosition(15, y++);
            Console.WriteLine(); Console.SetCursorPosition(15, y++);
            Console.WriteLine("                                               〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓"); Console.SetCursorPosition(15, y++);
        }

        public static string GetUserName()
        {
            int y = 30;
            Console.SetCursorPosition(10, y++);
            Console.WriteLine("──────────────────────────");
            Console.WriteLine("│                                                  │");

            return "";
        }
    }
}
