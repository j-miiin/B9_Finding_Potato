using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Customer : Monster
    {
        public Customer(string name) : base(name, 300, 10) { }

        public override void AttackMessage()
        {
            Extension.TypeWriting("손 휘젓기!");
        }
    }
}
