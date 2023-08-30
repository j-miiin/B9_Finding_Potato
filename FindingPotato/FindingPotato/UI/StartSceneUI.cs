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
                Console.SetCursorPosition(x + 18, y + 5);
                playerName = Console.ReadLine();
                if (playerName.Length == 0)
                {
                    Console.SetCursorPosition(x + 12, y + 6);
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

            string[] playerTypeStrList = { " 1. 감  자 ", " 2. 고구마 ", " 3. 당  근 ", "0" };

            x = 68; y = 34;

            return UIExtension.GetPlayerSelectFromUI(x, y, 1, playerTypeStrList, false);
        }
    }
}
