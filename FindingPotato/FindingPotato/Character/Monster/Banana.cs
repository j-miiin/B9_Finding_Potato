using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Banana : Monster
    {
        public Banana(string name) : base(name, 75,25,2) { }

        public override string AttackMessage()
        {
            return "껍질 날리기!";
        }
    }
}
