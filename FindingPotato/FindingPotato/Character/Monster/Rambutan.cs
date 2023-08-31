using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Rambutan :Monster
    {
        static string image = "  \r\n  \r\n  \r\n  \r\n  \r\n  ~,--♨--,~\r\n ~/         \\~\r\n~│ #＞目＜# │~\r\n ~\\+       +/~\r\n   ~`--+--'~\r\n";
        public Rambutan(string name) : base(name, 60, 20, 2, image) { }

        public override string AttackMessage()
        {
            return "찌르기!";
        }
    }
}
