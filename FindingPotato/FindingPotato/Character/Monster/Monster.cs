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

        public int CurrentHealth
        {
            get => health;
            set => health = Math.Max(value,0);
        }
        public int Attack => new Random().Next(10, 20); // 공격력은 랜덤

        public bool IsDead => CurrentHealth <= 0;

        public Monster(string name, int health, int level)
        {
            Name = name;
            CurrentHealth = health;
            Level = level;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (IsDead) Extension.TypeWriting($"{Name} 이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name} 이(가) {damage}의 데미지를 받았습니다.");
        }

        public void Avoid()
        {
            Console.WriteLine($"Lv.{Level} {Name} 을(를) 공격했지만 아무 일도 일어나지 않았습니다.");
        }

        public virtual void AttackMessage()
        {
            Console.WriteLine("공격!"); 
        }
    }
}
