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
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");
        Console.Write(">> ");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                if (_min <= input && input <= _max)
                    return input;
            }

            Console.WriteLine("\n잘못된 입력입니다. 다시 입력해주세요.");
            Console.Write(">> ");
        }
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
}