using FindingPotato.Item;
using FindingPotato.Skill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindingPotato.Inventory;

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
        public int CurrentExp { get; set; } // player 현재 경험치
        public int MaxExp // player 레벨업에 필요한 경험치
        {
            get
            {
                switch (Level)
                {
                    case 1:
                        return 9;
                    case 2:
                        return 34;
                    case 3:
                        return 64;
                    case 5:
                        return 100;
                    default:
                        return 0;
                }
            }
        }

        public int TotalExp { get; set; } // 스테이지에서 획득한 경험치의 합
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

        public string Image { get; set; }

        public int Attack => new Random().Next(AttackPower - 5, AttackPower + 5);

        public int CurrentStage { get; set; } = 1;

        public InventoryClass PlayerInventory;
        
        public List<ISkill> SkillList { get; }

        public bool hadPotion = false;
        public int potionEffect = 0;
        public Player(string name, VegetableType type)
        {
            Name = name;
            Type = type;
            Level = 1;

            switch (type)
            {
                case VegetableType.감자:
                    MaxHealth = 120;
                    Defense = 10;
                    AttackPower = 50;
                    MaxMP = 50;
                    Image = " \r\n     ______\r\n    /      \\  \r\n\\  /  ⊙ ⊙ \\  /\r\n \\|    ▲    |/\r\n  \\     V    /   \r\n   \\________/     \r\n       / \\\r\n      /   \\";
                    break;

                case VegetableType.고구마:
                    MaxHealth = 140;
                    Defense = 20;
                    AttackPower = 40;
                    MaxMP = 20;
                    Image = "   \r\n           ______  \r\n          /      \\\r\n         |        |\r\n       \\ |  ⊙ ⊙ | / \r\n        \\|    ^   |/\r\n         |    V   |\r\n          \\______/\r\n             / \\\r\n            /   \\";
                    break;

                default:    // 당근
                    MaxHealth = 110;
                    Defense = 5;
                    AttackPower = 60;
                    MaxMP = 30;
                    Image = "       \\ | /\r\n       _\\|/__  \r\n      /      \\\r\n   \\ │  ⊙ ⊙│ / \r\n    \\│    ^  │/\r\n      \\   V  / \r\n       \\    /\r\n        \\  / \r\n       / \\/ \\\r\n      /      \\";
                    break;
            }

            CurrentHealth = MaxHealth;
            CurrentMP = MaxMP;
            PlayerInventory = new InventoryClass();
            SkillList = new List<ISkill> { new AlphaSkill(), new DoubleSkill() };
        }

        // Player가 공격 당했을 때 실행
        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;

            if (IsDead)
                Extension.TypeWriting($"{Name}이(가) 죽었습니다.");
            else
                Extension.TypeWriting($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }

        // Player가 스킬을 사용할 때 실행
        public List<int> UseSkill(SkillType type, List<ICharacter> monsterList)
        {
            currentMP -= (int)type;
            int skillIdx = SkillList.FindIndex(x => x.SkillType == type);
            return SkillList[skillIdx].Use(this, monsterList);
        }

        public void GetReward(IItem newItem)
        {
            IItem item = PlayerInventory.InventoryItems.Find(x => x.Name == newItem.Name);

            if (item == null)
                PlayerInventory.InventoryItems.Add(newItem);
            else if (item.Type == ItemType.HealthPotion || item.Type == ItemType.StrengthPotion)
                ((IConsumable)item).Quantity++;
        }

        public void PotionEffectReset()
        {
            hadPotion = false;
            AddAtk -= potionEffect;
            potionEffect = 0;
        }

        // 경험치 업데이트
        public void ExpUpdate(int totalExp)
        {
            TotalExp += totalExp; // 스테이지 클리어 Before Exp적용 용도 TotalExp 값 저장
            CurrentExp += totalExp; // 현재 경험치 변경 용도

            if      (CurrentExp >= 100) { Level = 5; }
            else if (CurrentExp >= 65)  { Level = 4; }
            else if (CurrentExp >= 35)  { Level = 3; }
            else if (CurrentExp >= 10)  { Level = 2; }
            else                        { Level = 1; }
        }
    }
}
