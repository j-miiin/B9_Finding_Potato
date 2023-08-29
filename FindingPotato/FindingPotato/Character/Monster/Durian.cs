using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Durian : Monster
    {
        public Durian(string name) : base(name, 50, 1) { }

        public override void AttackMessage()
        {
            Extension.TypeWriting("냄새 풍기기!");
        }
    }
}
