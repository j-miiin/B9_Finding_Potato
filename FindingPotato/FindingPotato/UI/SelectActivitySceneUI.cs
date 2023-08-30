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
            for (int i = 0; i < 30; i++) {
                Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);
            }
            Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);
            Console.WriteLine("                   |                                                                                                   |"); Console.SetCursorPosition(x, y++);

            x = 60; y = 15;
            Console.SetCursorPosition(x + 5, y++);
            Extension.TypeWriting($"어서오세요. {playerName} 님");
            Console.SetCursorPosition(x, y++);
            Extension.TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            string[] activityStrList = { " 1. 상 태 보 기 ", " 2. 인 벤 토 리 ", " 3. 전 투 시 작 ", " 0. 게 임 종 료 " };

            bool isSelected = false;
            int playerSelect = 1;
            int selectedLine = 20;
            x = 65;
            while (!isSelected)
            {
                y = 20;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedLine -= 4;
                            selectedLine = Math.Max(selectedLine, 20);
                            break;
                        case ConsoleKey.DownArrow:
                            selectedLine += 4;
                            selectedLine = Math.Min(selectedLine, 35);
                            break;
                        case ConsoleKey.Enter:
                            if (selectedLine == 20) playerSelect = 1;
                            else if (selectedLine == 24) playerSelect = 2;
                            else if (selectedLine == 28) playerSelect = 3;
                            else playerSelect = 0;
                            isSelected = true;
                            break;
                        case ConsoleKey.NumPad1:
                            selectedLine = 20;
                            break;
                        case ConsoleKey.NumPad2:
                            selectedLine = 24;
                            break;
                        case ConsoleKey.NumPad3:
                            selectedLine = 28;
                            break;
                        case ConsoleKey.NumPad0:
                            selectedLine = 32;
                            break;
                    }
                }

                for (int i = 0; i < activityStrList.Length; i++)
                {
                    if (selectedLine == 20 && i == 0) Extension.SetSelectedBackground(true);
                    else if (selectedLine == 24 && i == 1) Extension.SetSelectedBackground(true);
                    else if (selectedLine == 28 && i == 2) Extension.SetSelectedBackground(true);
                    else if (selectedLine == 32 && i == 3) Extension.SetSelectedBackground(true);
                    else Extension.SetSelectedBackground(false);
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine(activityStrList[i]);
                    Console.SetCursorPosition(x, y++);
                    Console.WriteLine("                ");
                    y++;
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;
            return playerSelect;
        }
    }
}
