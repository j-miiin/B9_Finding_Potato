using FindingPotato.Character;
using FindingPotato.Character.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Skill
{
    internal class AlphaSkill : ISkill
    {
        public SkillType SkillType { get; }

        public string Description { get; }

        public AlphaSkill()
        {
            SkillType = SkillType.ALPHA;
            Description = "알파 스트라이크 - MP 10\n   공격력 * 2 로 하나의 적을 공격합니다.\n";
        }

        public void Use(Player player, List<ICharacter> monsterList)
        {
            Console.Clear();

            Extension.TypeWriting("Battle!!\n");
            Extension.TypeWriting($"{player.Name}의 알파 스트라이크 공격!");
            Console.WriteLine();

            Monster curMonster = (Monster)monsterList[0];
            int monsterPrevHP = curMonster.CurrentHealth;

            int damage = (player.Attack + player.AddAtk) * 2;
            curMonster.TakeDamage(damage);  // 공격력 * 2 로 하나의 적 공격

            // 알파 스트라이크 결과 출력
            Console.WriteLine($"Lv.{curMonster.Level} {curMonster.Name}");
            Console.WriteLine($"HP {monsterPrevHP} -> {curMonster.CurrentHealth}\n");
            Console.WriteLine();
        }
    }
}
