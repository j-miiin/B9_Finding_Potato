using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public string Image { get; set; }
        public string Desc { get; }
        public ConsoleColor MonsterColor { get; }

        public Monster(string name, int maxHealth, int attackPower, int level, string image, string desc, ConsoleColor monsterColor)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            AttackPower = attackPower;
            Level = level;
            Image = image;
            Desc = desc;
            MonsterColor = monsterColor;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (IsDead) Extension.TypeWriting($"{Name} 이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name} 이(가) {damage}의 데미지를 받았습니다.");
        }

        public virtual void Avoid()
        {
            Console.SetCursorPosition(53, Console.CursorTop);
            Console.WriteLine($"Lv.{Level} {Name} 을(를) 공격했지만 아무 일도 일어나지 않았습니다."); 
        }

        public virtual string AttackMessage()
        {
            return "공격!"; 
        }

        public virtual void PrintMonsterImage(int x, int y)
        {
            Console.ForegroundColor = MonsterColor;

            string[] imageLines = Image.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            Console.SetCursorPosition(x, y);
            foreach (string line in imageLines)
            {
                Console.SetCursorPosition(x, Console.CursorTop);
                Console.WriteLine($"{line}   ");
            }
            Console.ResetColor();
        }
    }
}
