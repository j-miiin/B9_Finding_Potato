﻿using FindingPotato.Item;
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
        public int CurrentHealth { get; set; } 

        public int AttackPower { get; set; }
        public int AddAtk { get; set; }

        public int DefensePower { get; set; }
        public int AddDef { get; set; }

        public bool IsDead => Health <= 0;

        public int Attack => new Random().Next(10, AttackPower); // 공격력은 랜덤

        public List<IItem> Inventory = new List<IItem>();

        public Player(string name)
        {
            Name = name;
            Health = 100; // 초기 체력
            AttackPower = 20; // 초기 공격력
            DefensePower = 30; // 초기 방어력
            CurrentHealth = Health;
        }


        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (IsDead) Console.WriteLine($"{Name}이(가) 죽었습니다.");
            else Console.WriteLine($"{Name}이(가) {damage}의 데미지를 받았습니다. 남은 체력: {Health}");
        }
    }
}
