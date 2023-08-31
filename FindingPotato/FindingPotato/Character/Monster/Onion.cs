using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Onion : Monster
    {
        static string image = "   \r\n    \r\n  \r\n  \r\n  \r\n      \r\n    __//|\\\\__\r\n   / /     \\ \\ \r\n  │  ￣Д￣  │ \r\n  /\\__\\___/__/\\ \r\n       / \\\r\n        ";
        public Onion(string name) : base(name, 70,25,3, image) { }

        public override string AttackMessage()
        {
            string message = " ";
            switch (Random.Next(0, 2))
            {
                case 0:
                    message = "양파즙 뿌리기!!";
                    break;

                case 1:
                    message = "매운 향 뿜어내기!!";
                    break;
            }

            return message;
        }
    }
}
