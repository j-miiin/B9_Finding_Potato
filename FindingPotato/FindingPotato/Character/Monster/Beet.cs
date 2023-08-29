using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Beet :Monster
    {
        public Beet(string name) : base(name, 50, 5) { }

        public override void AttackMessage()
        {
            Extension.TypeWriting("디스 랩 하기!");
        }
    }
}
