using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Customer : Monster
    {
        static string image = "     ────────       ────           \r\n    /          \\   /       \\       \r\n   /            ──          \\      \r\n  /                        ──      \r\n /         ────      ───           \r\n/        ─       ───               \r\n             ────      ────        \r\n           ─────      ── ──   ─    \r\n                                   \r\n            \\    ■     \\   ■     \r\n             ─────      ──────     \r\n                              \\    \r\n                               \\   \r\n         ─                   /     \r\n       /     ──────────────        \r\n       \\     ────────────────  /   \r\n         ──────────────────── /    \r\n                             /     \r\n       ────────────────────        ";

        static string desc = "오늘 저녁은 감자전이다";
        static ConsoleColor color = ConsoleColor.Yellow;

        public Customer(string name) : base(name, 300, 70, 5, image, desc, color) { }

        public override void Avoid()
        {
            Console.SetCursorPosition(53, Console.CursorTop);
            Console.WriteLine($"Lv.{Level} {Name} 을(를) 공격했지만 아무 일도 일어나지 않았습니다.\n");

            Console.SetCursorPosition(53, Console.CursorTop);
            switch (Random.Next(0,3))
            {
                case 0:
                    Console.WriteLine($"{Name}은 카드로 방어 했다"); 
                    break; 
                case 1:
                    Console.WriteLine($"{Name}은 직원과 이야기 중이다");
                    break; 
                case 2:
                    Console.WriteLine($"{Name}은 휴대폰을 보고있는 중이다");
                    break; 
            }
        }

        public override string AttackMessage()
        {
            switch (Random.Next(0, 5))
            {
                case 0:
                    return "손 휘젓기!!";
                case 1:
                    return "찔러보기!!";
                case 2:
                    return "쓰다듬기!!";
                case 3:
                    return "장바구니에 넣었다 빼기!!";
                default:
                    return "감자전이나 해먹을까? ";
            }
        }

        public override void PrintMonsterImage(int x, int y)
        {
            base.PrintMonsterImage(x - 5, y - 3);
            y += 17;
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"Lv.{base.Level} {base.Name}");
            Console.SetCursorPosition(x, y);
            Console.WriteLine(desc);
        }
    }
}
