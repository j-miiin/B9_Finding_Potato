using FindingPotato.Character;
using FindingPotato.Character.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Skill
{
    internal interface ISkill
    {
        SkillType SkillType { get; }

        string Description { get; }

        List<int> Use(Player player, List<ICharacter> monsterList);
    }
}
