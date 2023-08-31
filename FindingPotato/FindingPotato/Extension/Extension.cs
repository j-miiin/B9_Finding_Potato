using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Extension
{
    // 한 글자씩 타이핑
    public static void TypeWriting(string _str)
    {
        for (int i = 0; i < _str.Length; i++)
        {
            Console.Write(_str[i]);
            Thread.Sleep(1);
        }
        Console.WriteLine();
    }

    // 색상 다르게 문자열 출력 (기본값 배경:black, 문자열:yellow)
    public static void ColorWriteLine(string _str, ConsoleColor _back = ConsoleColor.Black, ConsoleColor _front = ConsoleColor.Yellow)
    {
        Console.BackgroundColor = _back;
        Console.ForegroundColor = _front;
        Console.WriteLine(_str);
        Console.ResetColor();
    }

    // 사용자 입력 받기 (min <= input <= max 값만 받도록)
    public static int GetInput(int _min, int _max)
    {
        Console.SetCursorPosition(0, 35);
        CenterAlign("┌──────────────────────────────────────────────┐  ");
        for (int i = 0; i < 7; i++) CenterAlign("│                                              │  ");
        CenterAlign("└──────────────────────────────────────────────┘  ");

        Console.SetCursorPosition(0, 38);
        CenterAlign("원하시는 행동을 입력해주세요 >>");
        Console.SetCursorPosition(73, 40);
        Console.CursorVisible = true;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (_min <= input && input <= _max)
                    return input;
            }

            Console.SetCursorPosition(0, 38);
            CenterAlign("잘못된 입력입니다. 다시 입력해주세요 >>");
            Console.WriteLine();
            CenterAlign("                     ");
            Console.SetCursorPosition(73, 40);
        }
        Console.CursorVisible= false;
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

    public static void CenterAlign(string text, ConsoleColor _back = ConsoleColor.Black, ConsoleColor _front = ConsoleColor.White)
    {
        int count = text.Count(c => c >= '\uAC00' && c <= '\uD7AF');            // uAC00은 '가', uD7AF는 '힣'을 의미하는 유니코드 범위. 두 범위 사이의 값을 찾는 것 = (완성형) 한글을 찾는 것
        int len = (150 - (text.Length + count)) / 2;
        Console.SetCursorPosition(len, Console.CursorTop);
        Extension.ColorWriteLine(text, _back, _front);
    }

}