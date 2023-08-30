using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Durian : Monster
    {
        public Durian(string name) : base(name, 50,20, 1) { }

        public override string AttackMessage()
        {
           return "냄새 풍기기!!";
        }
    }
}
