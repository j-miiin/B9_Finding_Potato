using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Durian : Monster
    {
        static string image = "   \r\n  \r\n  \r\n  \r\n       ___\r\n    ____|____\r\n   / \\/\\ /\\/ \\ \r\n  │  ㅡωㅡ  │ \r\n  /\\/ \\ /\\/ \\/\\   \r\n /  \\/_\\_/_\\/  \\  \r\n       / \\\r\n";
        public Durian(string name) : base(name, 50,20, 1, image) { }

        public override string AttackMessage()
        {
           return "냄새 풍기기!!";
        }
    }
}
