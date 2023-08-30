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
        private int currentMP;
        public string Name { get; }
        public VegetableType Type { get; }
        public int Level { get; set; }
        public int MaxHealth { get; set; }  // Player가 가질 수 있는 최대 체력 값
        public int CurrentHealth    // Player 현재 체력 값
        { 
            get => currentHealth;
            set => currentHealth = Math.Max(0, Math.Min(value, MaxHealth));
        }
        public int Defense { get; set; }
        public int AddDef { get; set; }
        public int AttackPower { get; set; }
        public int AddAtk { get; set; }

        public int MaxMP { get; set; }  // Player가 가질 수 있는 현재 마나 값

        public int CurrentMP    // Player의 현재 마나 값
        {
            get => currentMP;
            set => currentMP = Math.Max(0, Math.Min(value, MaxMP));
        }

        public bool IsDead => CurrentHealth <= 0;

        public int Attack => new Random().Next(30, AttackPower); // 공격력은 랜덤

        public int CurrentStage { get; set; } = 1;

        public bool hadPotion = false;
        public int potionEffect = 0;
        public Player(string name, VegetableType type)
        {
            Name = name;
            Type = type;
            Level = 1;

            if (type == VegetableType.감자)
            {
                MaxHealth = 100;
                Defense = 10;
                AttackPower = 50;
                MaxMP = 70;
            }
            else if (type == VegetableType.고구마)
            {
                MaxHealth = 120;
                Defense = 20;
                AttackPower = 40;
                MaxMP = 30;
            }
            else // 당근
            {
                MaxHealth = 100;
                Defense = 0;
                AttackPower = 60;
                MaxMP = 50;
            }

            CurrentHealth = MaxHealth;
            CurrentMP = MaxMP;
        }

        // Player가 공격 당했을 때 실행
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (IsDead) Extension.TypeWriting($"{Name}이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }

        // Player가 스킬을 사용할 때 실행
        public void AttackWithMP(MPAttackType type)
        {
            if (type == MPAttackType.ALPHA) CurrentMP -= (int)MPAttackType.ALPHA;
            else CurrentMP -= (int)MPAttackType.DOUBLE;
        }

        public enum MPAttackType
        {
            ALPHA = 10,
            DOUBLE = 15
        }
    }
}
