using FindingPotato.Character;
using FindingPotato.Character.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FindingPotato.UI
{
    internal class UIExtension
    {
        // x : UI를 출력할 x 좌표
        // y : UI를 출력할 y 좌표
        // interval : 출력 간격 (1줄에 하나 출력이면 1, 메뉴 창처럼 위아래 padding, margin 줄거면 4)
        // selectStrList : 출력할 string 리스트 (맨 끝에는 "0번 나가기" 넣어야 함)
        // isPossibleToExit : 0번으로 나가기/취소 가능하다면 true, 아니라면 false
        public static int GetPlayerSelectFromUI(int x, int y, int interval, string[] selectStrList, bool isPossibleToExit)
        {
            bool isSelected = false;
            int selectedNum = 1;
            int listLength = (isPossibleToExit) ? selectStrList.Length : selectStrList.Length - 1;
            int minLine = y;

            while (!isSelected)
            {
                y = minLine;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);

                bool[] isLimited = new bool[listLength + 1];
                int[] inputArr = GetInputKey(selectedNum, listLength, isPossibleToExit, isLimited);
                isSelected = (inputArr[0] == 0) ? false : true;
                selectedNum = inputArr[1];

                string emptyStr = GetPaddingStr(selectStrList);
                for (int i = 0; i < listLength; i++)
                {
                    if (i == (selectedNum - 1)) SetSelectedBackground(true);
                    else SetSelectedBackground(false);

                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    Console.SetCursorPosition(x, y++);
                    string curStr = selectStrList[i];
                    while (GetByteLength(curStr) < emptyStr.Length) curStr += " ";
                    Console.WriteLine(curStr);
                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    if (interval == 4) y++;
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;

            if (isPossibleToExit && selectedNum == listLength) selectedNum = 0;
            return selectedNum;
        }

        // 선택지에 제한 사항이 있을 경우 사용
        // isLimited[i] == true 이면 제한된 선택지 -> 회색으로 표시
        // isLimited[i] == false 이면 선택 가능
        // isLimited 배열은 selectStrList.Length + 1로 초기화
        //  -> 인덱스 1부터 isLimited.Length까지 for문으로 돌면서 isLimited에 선택 제한 반영
        //  -> 만약 isPossibleToExit == true 이면 인덱스 1부터 isLimited.Length - 1 까지 !! (마지막은 "취소/나가기" 이므로 활성해야 함)
        public static int GetPlayerSelectFromUI(int x, int y, int interval, string[] selectStrList, bool isPossibleToExit, bool[] isLimited)
        {
            bool isSelected = false;
            int selectedNum = 1;
            while (isLimited[selectedNum] == true) selectedNum++;
            int listLength = (isPossibleToExit) ? selectStrList.Length : selectStrList.Length - 1;
            int minLine = y;

            while (!isSelected)
            {
                y = minLine;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);

                int[] inputArr = GetInputKey(selectedNum, listLength, isPossibleToExit, isLimited);
                isSelected = (inputArr[0] == 0) ? false : true;
                selectedNum = inputArr[1];

                string emptyStr = GetPaddingStr(selectStrList);
                for (int i = 0; i < listLength; i++)
                {
                    if (i == (selectedNum - 1)) SetSelectedBackground(true);
                    else SetSelectedBackground(false);

                    if (!isPossibleToExit || i != (listLength - 1))
                    {
                        if (isLimited[i + 1]) Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    Console.SetCursorPosition(x, y++);
                    string curStr = selectStrList[i];
                    while (GetByteLength(curStr) < emptyStr.Length) curStr += " ";
                    Console.WriteLine(curStr);
                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    if (interval == 4) y++;

                    if (isLimited[i + 1]) Console.ResetColor();
                }
            }
            Console.ResetColor();
            Console.CursorVisible = true;

            if (isPossibleToExit && selectedNum == listLength) selectedNum = 0;
            return selectedNum;
        }

        public static int GetPlayerSelectFromUI(int x, int y, int interval, string[] selectStrList, 
            bool isPossibleToExit, bool[] isLimited, List<ICharacter>[] imageList)
        {
            bool isSelected = false;
            int selectedNum = 1;
            int listLength = (isPossibleToExit) ? selectStrList.Length : selectStrList.Length - 1;
            int minLine = y;

            int prevSelect = 0;
            int[] prevIdxList = new int[listLength];

            while (!isSelected)
            {
                y = minLine;
                Console.CursorVisible = false;
                Console.SetCursorPosition(x, y);

                if (prevSelect != selectedNum)
                {
                    prevSelect = selectedNum;
                    if (selectedNum != listLength)
                    {
                        int monsterX = 85; int monsterY = 20;
                        prevIdxList[selectedNum - 1] = DrawRandomCharacterAndDesc(imageList[selectedNum - 1], monsterX, monsterY, prevIdxList[selectedNum - 1]);
                    }
                }

                int[] inputArr = GetInputKey(selectedNum, listLength, isPossibleToExit, isLimited);
                isSelected = (inputArr[0] == 0) ? false : true;
                selectedNum = inputArr[1];

                string emptyStr = GetPaddingStr(selectStrList);
                for (int i = 0; i < listLength; i++)
                {
                    if (i == (selectedNum - 1)) SetSelectedBackground(true);
                    else SetSelectedBackground(false);

                    if (!isPossibleToExit || i != (listLength - 1))
                    {
                        if (isLimited[i + 1]) Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    Console.SetCursorPosition(x, y++);
                    string curStr = selectStrList[i];
                    while (GetByteLength(curStr) < emptyStr.Length) curStr += " ";
                    Console.WriteLine(curStr);
                    if (interval == 4)
                    {
                        Console.SetCursorPosition(x, y++);
                        Console.WriteLine(emptyStr);
                    }
                    if (interval == 4) y++;
                }
                Console.ResetColor();
            }
            Console.ResetColor();
            Console.CursorVisible = true;

            if (isPossibleToExit && selectedNum == listLength) selectedNum = 0;
            return selectedNum;
        }

        // 사용자의 방향키 및 키패드 숫자와 엔터 입력을 받아옴
        // GetInputKey()[0] == isSelected의 true(1)/false(0) 여부 (사용자가 Enter 했는지 안 했는지)
        // GetInputKey()[1] == 선택한 아이템 번호
        private static int[] GetInputKey(int curNum, int maxIdx, bool isPossibleToExit, bool[] isLimited)
        {
            int minAvailableIdx = 1;
            while (isLimited[minAvailableIdx]) minAvailableIdx++;
            int selectedNum = curNum;
            bool isSelected = false;

            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        do selectedNum--;
                        while (isLimited[selectedNum]);
                        selectedNum = Math.Max(selectedNum, minAvailableIdx);
                        break;
                    case ConsoleKey.DownArrow:
                        do selectedNum++;
                        while (selectedNum < isLimited.Length && isLimited[selectedNum]);
                        selectedNum = Math.Min(selectedNum, maxIdx);
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                    default:
                        int pivotKeyInt = (int)ConsoleKey.NumPad0;
                        int curKeyInt = (int)key;
                        if (curKeyInt == pivotKeyInt && isPossibleToExit) selectedNum = maxIdx;
                        else if ((curKeyInt > pivotKeyInt) && curKeyInt - pivotKeyInt <= maxIdx 
                            && !isLimited[curKeyInt - pivotKeyInt])
                        {
                            selectedNum = curKeyInt - pivotKeyInt;
                        }
                        break;
                }
            }

            return new int[] { (isSelected) ? 1 : 0, selectedNum };
        }

        // 위아래 padding에 넣을 공백 길이 계산
        private static string GetPaddingStr(string[] selectStrList)
        {
            string emptyStr = "";
            int maxLength = selectStrList.Max(str => str.Length);
            string longestStr = selectStrList.First(str => str.Length == maxLength);

            int maxByteLength = GetByteLength(longestStr);

            for (int i = 0; i < maxByteLength; i++) emptyStr += " ";
            return emptyStr;
        }

        // 문자열의 byte 길이를 계산
        private static int GetByteLength(string str)
        {
            int length = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '\uAC00' && str[i] <= '\uD7AF') length += 2;
                else length++;
            }
            return length;
        }


        private static int DrawRandomCharacterAndDesc(List<ICharacter> monsterList, int x, int y, int prevIdx)
        {
            ClearCharacter(x, y);
            int randomImageIdx = 0;
            while (randomImageIdx == prevIdx) randomImageIdx = new Random().Next(0, monsterList.Count);
            Monster curMonster = (Monster)monsterList[randomImageIdx];
            curMonster.PrintMonsterImage(x, y);
            return randomImageIdx;
        }

        //image는 ICharacter.Image를 넣으면 됩니다. ex) DrawCharacter(player.Image, 23, 20);
        public static void DrawCharacter(string image, int posX, int posY)
        {
            string[] imageLines = image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(posX, posY);
            foreach (string line in imageLines)
            {
                Console.SetCursorPosition(posX, Console.CursorTop);
                Console.WriteLine($"{line}   ");
            }
        }

        public static void ShakeCharacter(string image, int posX, int posY)
        {
            string[] imageLines = image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(posX, posY);
            foreach (string line in imageLines)
            {
                Console.SetCursorPosition(posX, Console.CursorTop);
                Console.WriteLine($"  {line}");
            }
        }

        public static void DrawHit(ICharacter character, int posX, int posY)
        {
            Console.ForegroundColor = ConsoleColor.Red;     // 일단은 빨간색으로 했습니다.

            Thread.Sleep(50);
            ShakeCharacter(character.Image, posX, posY);
            Thread.Sleep(50);
            DrawCharacter(character.Image, posX, posY);
            Thread.Sleep(50);
            ShakeCharacter(character.Image, posX, posY);
            Thread.Sleep(50);
            DrawCharacter(character.Image, posX, posY);

            Console.ResetColor();
        }

        public static void ClearCharacter(int x, int y)
        {
            string clearStr = "";
            for (int i = 0; i < 45; i++) clearStr += " ";
            Console.SetCursorPosition(x - 10, y);
            for (int i = y; i < y + 20; i++)
            {
                Console.SetCursorPosition(x - 10, Console.CursorTop);
                Console.WriteLine(clearStr);
            }
        }

        public static void PrintSuperMarketFrame(int x, int y)
        {
            string supermarketFrameStr = "               * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\r\n"
                                    + "              *                                                                                                             *\r\n"
                                    + "             *       ■■■ ■    ■ ■■■ ■■■ ■■■     ■■      ■■     ■     ■■■ ■    ■ ■■■ ■■■        *\r\n"
                                    + "            *        ■     ■    ■ ■  ■ ■     ■  ■     ■ ■    ■ ■    ■■    ■  ■ ■  ■   ■       ■           *\r\n"
                                    + "           *         ■■■ ■    ■ ■■■ ■■■ ■■■     ■  ■  ■  ■   ■■■   ■■■ ■■     ■■■   ■            *\r\n"
                                    + "          *              ■ ■    ■ ■     ■     ■ ■      ■   ■■   ■  ■    ■  ■ ■  ■  ■   ■       ■             *\r\n"
                                    + "         *           ■■■ ■■■■ ■     ■■■ ■   ■    ■    ■    ■ ■      ■ ■   ■■    ■ ■■■   ■              *\r\n"
                                    + "        *                                                                                                                         *\r\n"
                                    + "       * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *\r\n";

            string[] supermarketFrameStrArr = supermarketFrameStr.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.SetCursorPosition(x, y);
            foreach (string str in supermarketFrameStrArr)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine(str);
            }
            x += 16;
            y += supermarketFrameStrArr.Length;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i <= 30; i++)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine("|                                                                                                   |"); Console.SetCursorPosition(x, y++);
            }
            x -= 16; y -= 2;
            Console.SetCursorPosition(x, y);
            PrintFloor(y);
        }

        public static void SetSelectedBackground(bool isSelected)
        {
            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        public static void PrintFloor(int y)
        {
            string floor = new string('_', 150);

            Console.SetCursorPosition(0, y);
            Console.WriteLine(floor);
            Console.SetCursorPosition(22, y);
            Console.WriteLine("\\|/");
            Console.SetCursorPosition(38, y);
            Console.WriteLine("\\|/");
            Console.SetCursorPosition(88, y);
            Console.WriteLine("\\|/");
        }

        public static void PrintCloud()
        {
            string cloud = ("                  ■■■                \r\n                ■      ■              \r\n              ■          ■■          \r\n            ■              ▒▒■        \r\n        ■■▒▒                ■        \r\n  ■■■      ▒▒            ▒▒▒▒■■    \r\n■▒▒            ▒▒        ▒▒      ▒▒■  \r\n■▒▒▒▒        ▒▒▒▒▒▒▒▒▒▒▒▒          ▒▒■\r\n  ■▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒■\r\n    ■■■■▒■■■■■■■■■■■■  \r\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            DrawCharacter(cloud, 100, 3);
            DrawCharacter(cloud, 7, 20);
            Console.ResetColor();
        }
    } 
}
