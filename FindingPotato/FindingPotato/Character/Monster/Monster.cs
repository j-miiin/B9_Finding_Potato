using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character.Monster
{
    internal class Monster : ICharacter
    {
        public Random Random = new Random();

        private int health;
        public int MaxHealth { get; set; }
        public string Name { get; }

        public int Level { get; set; }

        public int CurrentHealth
        {
            get => health;
            set => health = Math.Max(value,0);
        }
        public int Attack => Random.Next(AttackPower-10, AttackPower+5);
        public int AttackPower { get; set; }
        public bool IsDead => CurrentHealth <= 0;

        public Monster(string name, int maxHealth, int attackPower, int level)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            AttackPower = attackPower;
            Level = level;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (IsDead) Extension.TypeWriting($"{Name} 이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name} 이(가) {damage}의 데미지를 받았습니다.");
        }

        public virtual void Avoid()
        {
            Console.SetCursorPosition(30, Console.CursorTop);
            Console.WriteLine($"Lv.{Level} {Name} 을(를) 공격했지만 아무 일도 일어나지 않았습니다."); 
        }

        public virtual string AttackMessage()
        {
            return "공격!"; 
        }
    }
}
