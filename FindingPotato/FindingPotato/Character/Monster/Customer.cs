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
            Console.WriteLine($"Lv.{Level} {Name} 을(를) 공격했지만 아무 일도 일어나지 않았습니다.\n");
            string message = ""; 
            switch(Random.Next(0,3))
            {
                  
                case 0:
                    message = $"{Name}은 카드로 방어 했다"; 
                    break; 
                case 1:
                    message = $"{Name}은 직원과 이야기 중이다";
                    break; 
                case 2:
                    message = $"{Name}은 휴대폰을 보고있는 중이다";
                    break; 
            }
          Console.WriteLine(message);
        }

        public override string AttackMessage()
        {
            string message = " ";
            switch (Random.Next(0, 5))
            {
                case 0:
                    message = "손 휘젓기!!";
                    break;

                case 1:
                    message = "찔러보기!!";
                    break;
                case 2:
                    message = "쓰다듬기!!";
                    break; 
                case 3:
                    message = "장바구니에 넣었다 빼기!!";
                    break; 
                case 4:
                    message = "감자전이나 해먹을까? "; 
                    break; 
            }

            return message;
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
