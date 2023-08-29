using FindingPotato.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum VegetableType
{
    감자 = 1, 고구마, 당근
}

namespace FindingPotato.Character
{
    internal class Player : ICharacter
    {
        private int currentHealth; 
        public string Name { get; }
        public VegetableType Type { get; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int CurrentHealth 
        { 
            get =>currentHealth;
            set => currentHealth = Math.Max(0, Math.Min(value, Health));
        }
        public int Defense { get; set; }
        public int AddDef { get; set; }
        public int AttackPower { get; set; }
        public int AddAtk { get; set; }

        public int MP { get; set; }
        

        public bool IsDead => CurrentHealth <= 0;

        public int Attack => new Random().Next(30, AttackPower); // 공격력은 랜덤

        public int CurrentStage { get; set; } = 1; 

        public List<IItem> Inventory = new List<IItem>();

        public Player(string name, VegetableType type)
        {
            Name = name;
            Type = type;
            Level = 1;

            if (type == VegetableType.감자)
            {
                Health = 100;
                Defense = 10;
                AttackPower = 50;
                MP = 70;
            }
            else if (type == VegetableType.고구마)
            {
                Health = 120;
                Defense = 20;
                AttackPower = 40;
                MP = 30;
            }
            else // 당근
            {
                Health = 100;
                Defense = 0;
                AttackPower = 60;
                MP = 50;
            }

            CurrentHealth = Health;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (IsDead) Extension.TypeWriting($"{Name}이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }

        public void AttackWithMP(MPAttackType type)
        {
            if (type == MPAttackType.ALPHA) MP -= (int)MPAttackType.ALPHA;
            else MP -= (int)MPAttackType.DOUBLE;
        }

        public enum MPAttackType
        {
            ALPHA = 10,
            DOUBLE = 15
        }
    }
}
