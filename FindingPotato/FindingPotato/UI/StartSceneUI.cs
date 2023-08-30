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
            string playerName = "";
            while (true)
            {
                Console.SetCursorPosition(x + 15, y + 5);
                playerName = Console.ReadLine();
                if (playerName.Length == 0)
                {
                    Console.SetCursorPosition(x + 10, y + 6);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("닉네임을 입력해주세요!");
                    Console.ResetColor();
                }
                else break;
            }
            return playerName;
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
                            selectedLine = 34;
                            break;
                        case ConsoleKey.NumPad2:
                            selectedLine = 35;
                            break;
                        case ConsoleKey.NumPad3:
                            selectedLine = 36;
                            break;
                    }
                }

                if (selectedLine == 34)
                {
                    Extension.SetSelectedBackground(true);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    Extension.SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                } else if (selectedLine == 35)
                {
                    Extension.SetSelectedBackground(false);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    Extension.SetSelectedBackground(true);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    Extension.SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                } else
                {
                    Extension.SetSelectedBackground(false);
                    Console.WriteLine("1. 감  자");
                    Console.SetCursorPosition(x + 18, y++);
                    Extension.SetSelectedBackground(false);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("2. 고구마");
                    Extension.SetSelectedBackground(true);
                    Console.SetCursorPosition(x + 18, y++);
                    Console.WriteLine("3. 당  근");
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;
            return playerType;
        }
    }
}
