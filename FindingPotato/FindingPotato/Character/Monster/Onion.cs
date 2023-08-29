using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Onion : Monster
    {
        public Onion(string name) : base(name, 50,1) { }

        public override void AttackMessage()
        {
            Extension.TypeWriting("양파즙 뿌리기!"); 
        }
    }
}
