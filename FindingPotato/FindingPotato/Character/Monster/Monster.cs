using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Monster : ICharacter
    {
        private int health; 
        public string Name { get; }

        public int Level { get; set; }

        public int Health 
        {
            get => health;
            set => health = Math.Max(value,0);
        }
        public int Attack => new Random().Next(10, 20); // 공격력은 랜덤

        public bool IsDead => Health <= 0;

        public Monster(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Extension.TypeWriting($"{Name}이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }

        public virtual void AttackMessage()
        {
            Console.WriteLine("공격!"); 
        }
    }
}
