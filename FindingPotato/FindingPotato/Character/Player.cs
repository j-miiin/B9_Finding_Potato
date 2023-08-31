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
                        break;
                    case 2:
                        return 34;
                        break;
                    case 3:
                        return 64;
                        break;
                    case 5:
                        return 100;
                        break;
                    default:
                        return 0;
                        break;
                }
            }
            set
            {

            }
        }
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

        public int Attack => new Random().Next(AttackPower-5, AttackPower+5); 
        // 공격력은 랜덤

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

            if (type == VegetableType.감자)
            {
                MaxHealth = 120;
                Defense = 10;
                AttackPower = 50;
                MaxMP = 50;
                Image = " \r\n     ______\r\n    /      \\  \r\n\\  /  ⊙ ⊙ \\  /\r\n \\|    ▲    |/\r\n  \\     V    /   \r\n   \\________/     \r\n       / \\\r\n      /   \\";
            }
            else if (type == VegetableType.고구마)
            {
                MaxHealth = 140;
                Defense = 20;
                AttackPower = 40;
                MaxMP = 20;
                Image = "   \r\n           ______  \r\n          /      \\\r\n         |        |\r\n       \\ |  ⊙ ⊙ | / \r\n        \\|    ^   |/\r\n         |    V   |\r\n          \\______/\r\n             / \\\r\n            /   \\";
            }
            else // 당근
            {
                MaxHealth = 110;
                Defense = 5;
                AttackPower = 60;
                MaxMP = 30;
                Image = "       \\ | /\r\n       _\\|/__  \r\n      /      \\\r\n   \\ │  ⊙ ⊙│ / \r\n    \\│    ^  │/\r\n      \\   V  / \r\n       \\    /\r\n        \\  / \r\n       / \\/ \\\r\n      /      \\";
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
            if (IsDead) Extension.TypeWriting($"{Name}이(가) 죽었습니다.");
            else Extension.TypeWriting($"{Name}이(가) {damage}의 데미지를 받았습니다.");
        }

        // Player가 스킬을 사용할 때 실행
        public List<int> UseSkill(SkillType type, List<ICharacter> monsterList)
        {
            if (type == SkillType.ALPHA)
            {
                CurrentMP -= (int)SkillType.ALPHA;
                int skillIdx = SkillList.FindIndex(x => x.SkillType == SkillType.ALPHA);
                return SkillList[skillIdx].Use(this, monsterList);
            }
            else
            {
                CurrentMP -= (int)SkillType.DOUBLE;
                int skillIdx = SkillList.FindIndex(x => x.SkillType == SkillType.DOUBLE);
                return SkillList[skillIdx].Use(this, monsterList);
            }
        }

        public void GetReward(IItem newItem)
        {
            IItem item = PlayerInventory.InventoryItems.Find(x => x.Name == newItem.Name);
            if (item == null) PlayerInventory.InventoryItems.Add(newItem);
            else
            {
                if (item.Type == ItemType.HealthPotion || item.Type == ItemType.StrengthPotion)
                {
                    ((IConsumable)item).Quantity++;
                }
            }
        }

        public void PotionEffectReset()
        {
            hadPotion = false;
            AddAtk -= potionEffect;
            potionEffect = 0;
        }

        // 경험치 관리 메서드
        public void ExpUpdate(int totalExp)
        {
            CurrentExp += totalExp;
        }

        // 레벨업 관리 메서드
        public void LevelUpdate()
        {
            if (CurrentExp >= 0 && CurrentExp < 10)
            {
                Level = 1;
            }
            else if (CurrentExp >= 10 && CurrentExp < 35)
            {
                Level = 2;
            }
            else if (CurrentExp >= 35 && CurrentExp < 65)
            {
                Level = 3;
            }
            else if (CurrentExp >= 65 && CurrentExp < 99)
            {
                Level = 4;
            }
            else
            {
                Level = 5;
            }
        }
    }
}
