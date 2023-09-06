using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FindingPotato.UI
{
    public class StartSceneUI
    {
        public static void PrintGameTitleUI()
        {
            int x = 25;
            int y = 5;

            string gameTitleStr = "〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓\r\n"
                                + " \r\n"
                                + "■■■■   ■   ■■      ■   ■■■      ■   ■■      ■      ■■■■\r\n"
                                + "■         ■   ■ ■     ■   ■   ■     ■   ■ ■     ■     ■\r\n"
                                + "■■■■   ■   ■  ■    ■   ■    ■    ■   ■  ■    ■    ■\r\n"
                                + "■         ■   ■   ■   ■   ■     ■   ■   ■   ■   ■   ■      ■■\r\n"
                                + "■         ■   ■    ■  ■   ■    ■    ■   ■    ■  ■    ■        ■\r\n"
                                + "■         ■   ■     ■ ■   ■   ■     ■   ■     ■ ■     ■      ■\r\n"
                                + "■         ■   ■      ■■   ■■■      ■   ■      ■■       ■■■\r\n"
                                + " \r\n"
                                + "                  ■■■■       ■■■     ■■■■■       ■       ■■■■■     ■■■\r\n"
                                + "                  ■      ■   ■      ■       ■          ■■          ■       ■      ■\r\n"
                                + "                  ■      ■   ■      ■       ■         ■  ■         ■       ■      ■\r\n"
                                + "                  ■■■■     ■      ■       ■        ■ ■ ■        ■       ■      ■\r\n"
                                + "                  ■           ■      ■       ■       ■      ■       ■       ■      ■\r\n"
                                + "                  ■           ■      ■       ■      ■        ■      ■       ■      ■\r\n"
                                + "                  ■             ■■■         ■     ■          ■     ■         ■■■\r\n"
                                + " \r\n"
                                + "                                               〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓\r\n";

            string[] gameTitleStrArr = gameTitleStr.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < gameTitleStrArr.Length; i++)
            {
                if (i == 0 || i == gameTitleStrArr.Length - 1)
                    Console.ResetColor();
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(gameTitleStrArr[i]);
            }
        }

        public static string GetUserName()
        {
            int x = 50;
            int y = 30;

            string inputUserNameBoxStr = "┌────────────────────────────────────────────┐\r\n"
                                       + "│                                            │\r\n"
                                       + "│  Enter Your Name >>                        │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "└────────────────────────────────────────────┘\r\n";

            string[] inputUserNameBoxStrArr = inputUserNameBoxStr.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(x, y);
            foreach (string str in inputUserNameBoxStrArr)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(str);
            }

            x = 62;
            y = 35;
            while (true)
            {
                Console.SetCursorPosition(x + 6, y);
                string playerName = Console.ReadLine();

                if (playerName.Length == 0)
                {
                    Console.SetCursorPosition(x, y + 1);
                    Extension.ColorWriteLine("이름을 입력해주세요!", ConsoleColor.Black, ConsoleColor.Red);
                }
                else
                    return playerName;
            }
        }

        public static int GetPlayerType()
        {
            int x = 50;
            int y = 30;

            string inputPlayerTypeBoxStr = "┌────────────────────────────────────────────┐\r\n"
                                       + "│                                            │\r\n"
                                       + "│          ★ 직업을 선택하세요 ★           │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "│                                            │\r\n"
                                       + "└────────────────────────────────────────────┘\r\n";

            string[] inputPlayerTypeBoxStrArr = inputPlayerTypeBoxStr.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(x, y);
            foreach (string str in inputPlayerTypeBoxStrArr)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(str);
            }

            return UIExtension.GetPlayerSelectFromUI(68, 34, 1, new string[] { " 1. 감  자 ", " 2. 고구마 ", " 3. 당  근 ", "0" }, false);
        }
    }
}
