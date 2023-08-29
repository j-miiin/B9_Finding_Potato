using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Watermelon : Monster
    {
        public Watermelon(string name) : base(name, 75, 2) { }

        public override void AttackMessage()
        {
            Extension.TypeWriting("몸통 박치기!");
        }
    }
}
