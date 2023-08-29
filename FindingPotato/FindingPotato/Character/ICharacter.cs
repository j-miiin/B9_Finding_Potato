using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character
{
    internal interface ICharacter
    {
        string Name { get; }
        int CurrentHealth { get; set; }

        public int MaxHealth { get; set; }
        int Attack { get; }
        int Level { get; set; }
        bool IsDead { get; }
        void TakeDamage(int damage);
    }
}
