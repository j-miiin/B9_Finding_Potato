using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Paprika : Monster
    {
        static string image = "    \r\n  \r\n  \r\n  \r\n  \r\n     _  /\\  _\r\n   /   \\/ \\/  \\\r\n  │   \\   /   │ \r\n  /\\    Д    /\\ \r\n /  \\________/  \\   \r\n       / \\\r\n";
        public Paprika(string name) : base(name, 80,25,4, image) { }

        public override string AttackMessage()
        {
            string message = " ";
            switch (Random.Next(0, 2))
            {
                case 0:
                    message = "고함지르기!!";
                    break;

                case 1:
                    message = "씨 뿌리기!!";
                    break;
            }

            return message;
        }
    }
}
