using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Character
{
    internal class Player: ICharacter
    {
        public string Name { get; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int MP { get; set; }

        public bool IsDead => Health <= 0;
        public int Attack => new Random().Next(10, AttackPower); // 공격력은 랜덤

        public enum MPAttackType
        {
            Alpha,
            Double
        }

        private const int ALPHA_MP = 10;
        private const int DOUBLE_MP = 15;

        public Player(string name)
        {
            Name = name;
            Health = 100; // 초기 체력
            AttackPower = 20; // 초기 공격력
            MP = 50;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
        }

        public bool AttackWithMP(MPAttackType attackType)
        {
            if (attackType == MPAttackType.Alpha)
            {
                if (MP >= ALPHA_MP) MP -= ALPHA_MP;
                else
                {
                    Console.WriteLine("MP가 부족합니다!");
                    return false;
                }
            }
            else
            {
                if (MP >= DOUBLE_MP) MP -= DOUBLE_MP;
                else 
                {
                    Console.WriteLine("MP가 부족합니다!");
                    return false;
                }
            }
            return true;
        }
    }
}
