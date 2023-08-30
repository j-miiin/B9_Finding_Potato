using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Beet :Monster
    {
        public Beet(string name) : base(name, 150,35, 5) { }

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
