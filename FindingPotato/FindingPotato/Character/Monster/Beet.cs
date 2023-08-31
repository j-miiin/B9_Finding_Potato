using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Beet :Monster
    {
        static string image = "   \r\n  \r\n  \r\n  \r\n      \r\n    __\\|/__\r\n  /         \\ \r\n │   ￣Д￣ │ \r\n /\\         /\\ \r\n/  \\______ /  \\\r\n      / \\\r\n";
        public Beet(string name) : base(name, 70,25, 3, image) { }

        public override string AttackMessage()
        {
            string message = " "; 
            switch(Random.Next(0,2))
            {
                case 0: message = "디스 랩 하기!!"; 
                    break; 

                case 1:
                    message = "얼룩 제거 하기!!";
                    break; 
            }

            return message;
        }
    }
}
