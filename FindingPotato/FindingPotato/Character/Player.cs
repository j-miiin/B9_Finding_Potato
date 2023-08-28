using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character
{
    internal class Player : ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public bool IsDead => Health <= 0;
        public int Attack => new Random().Next(30, AttackPower); // 공격력은 랜덤

        public Player(string name)
        {
            Name = name;
            Health = 100; // 초기 체력
            AttackPower = 50; // 초기 공격력
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
        }
    }
}
