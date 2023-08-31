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
            
            int idx = 0;
            foreach (string str in gameTitleStrArr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (idx == 0 || idx == gameTitleStrArr.Length - 1) Console.ResetColor();
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(str);
                idx++;
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

            x = 62; y = 35;
            string playerName = "";
            while (true)
            {
                Console.SetCursorPosition(x + 6, y);
                playerName = Console.ReadLine();
                if (playerName.Length == 0)
                {
                    Console.SetCursorPosition(x, y + 1);
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

            string[] playerTypeStrList = { " 1. 감  자 ", " 2. 고구마 ", " 3. 당  근 ", "0" };

            x = 68; y = 34;

            return UIExtension.GetPlayerSelectFromUI(x, y, 1, playerTypeStrList, false);
        }
    }
}
