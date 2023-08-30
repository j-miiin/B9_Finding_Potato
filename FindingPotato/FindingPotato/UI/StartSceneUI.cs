using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    public class StartSceneUI
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
            Console.SetCursorPosition(x + 15, y + 5);
            return Console.ReadLine();
        }

        public static int GetPlayerType()
        {
            int x = 50;
            int y = 30;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine("┌────────────────────────────────────────────┐"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│          ★ 직업을 선택하세요 ★           │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("│                                            │"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("└────────────────────────────────────────────┘"); Console.SetCursorPosition(x, y++);

            bool isSelected = false;
            int playerType = 1;
            int selectedLine = 34;
            while (!isSelected)
            {
                y = 34;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x + 18, y);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedLine--;
                            if (selectedLine < 34) selectedLine = 34;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedLine++;
                            if (selectedLine > 36) selectedLine = 36;
                            break;
                        case ConsoleKey.Enter:
                            if (selectedLine == 34) playerType = 1;
                            else if (selectedLine == 35) playerType = 2;
                            else playerType = 3;
                            isSelected = true;
                            break;
                        case ConsoleKey.NumPad1:
                            playerType = 1;
                            isSelected = true;
                            break;
                        case ConsoleKey.NumPad2:
                            playerType = 2;
                            isSelected = true;
                            break;
                        case ConsoleKey.NumPad3:
                            playerType = 3;
                            isSelected = true;
                            break;
                    }
                }

                if (selectedLine == 34)
                {
                    SetSelectedBackground(true);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                } else if (selectedLine == 35)
                {
                    SetSelectedBackground(false);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    SetSelectedBackground(true);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                } else
                {
                    SetSelectedBackground(false);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    SetSelectedBackground(true);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                }
            }
            Console.ResetColor();
            Console.CursorVisible = false;
            return playerType;
        }

        private static void SetSelectedBackground(bool isSelected)
        {
            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            } else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }
}
