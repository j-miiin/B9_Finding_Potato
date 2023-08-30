using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class SelectActivitySceneUI
    {
        public static int GetPlayerActivity(string playerName)
        {
            int playerSelect = 1;

            int x = 5, y = 3;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine("               * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("              *                                                                                                             *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("             *       ■■■ ■    ■ ■■■ ■■■ ■■■     ■■      ■■     ■     ■■■ ■    ■ ■■■ ■■■        *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("            *        ■     ■    ■ ■  ■ ■     ■  ■     ■ ■    ■ ■    ■■    ■  ■ ■  ■   ■       ■           *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("           *         ■■■ ■    ■ ■■■ ■■■ ■■■     ■  ■  ■  ■   ■■■   ■■■ ■■     ■■■   ■            *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("          *              ■ ■    ■ ■     ■     ■ ■      ■   ■■   ■  ■    ■  ■ ■  ■  ■   ■       ■             *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("         *           ■■■ ■■■■ ■     ■■■ ■   ■    ■    ■    ■ ■      ■ ■   ■■    ■ ■■■   ■              *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("        *                                                                                                                         *"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("       * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *"); Console.SetCursorPosition(x, y++);
            for (int i = 0; i < 20; i++) {
                Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);
            }
            Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);

            x = 55; y = 15;
            Console.SetCursorPosition(x + 8, y++);
            Extension.TypeWriting($"어서오세요. {playerName} 님");
            Console.SetCursorPosition(x, y++);
            Extension.TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            string[] activityStrList = { "1. 상 태 보 기", "2. 인 벤 토 리", "3. 전 투 시 작", "0. 게 임 종 료" };
            Extension.ColorWriteLine(activityStrList[0]);
            Extension.ColorWriteLine(activityStrList[1]);
            Extension.ColorWriteLine(activityStrList[2]);
            Extension.ColorWriteLine(activityStrList[3]);

            //bool isSelected = false;
            //int playerType = 1;
            //int selectedLine = 34;
            //while (!isSelected)
            //{
            //    y = 34;
            //    Console.CursorVisible = false;
            //    Console.SetCursorPosition(x + 18, y);

            //    if (Console.KeyAvailable)
            //    {
            //        var key = Console.ReadKey(true).Key;
            //        switch (key)
            //        {
            //            case ConsoleKey.UpArrow:
            //                selectedLine--;
            //                if (selectedLine < 34) selectedLine = 34;
            //                break;
            //            case ConsoleKey.DownArrow:
            //                selectedLine++;
            //                if (selectedLine > 36) selectedLine = 36;
            //                break;
            //            case ConsoleKey.Enter:
            //                if (selectedLine == 34) playerType = 1;
            //                else if (selectedLine == 35) playerType = 2;
            //                else playerType = 3;
            //                isSelected = true;
            //                break;
            //            case ConsoleKey.NumPad1:
            //                selectedLine = 34;
            //                break;
            //            case ConsoleKey.NumPad2:
            //                selectedLine = 35;
            //                break;
            //            case ConsoleKey.NumPad3:
            //                selectedLine = 36;
            //                break;
            //        }
            //    }
            //}
            
            return playerSelect;
        }
    }
}
