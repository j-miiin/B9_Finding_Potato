using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Rambutan :Monster
    {
        public Rambutan(string name) : base(name, 100, 25,3) { }

        public override string AttackMessage()
        {
            return "찌르기!";
        }
    }
}
