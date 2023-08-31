using FindingPotato.Character.Monster;
using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Skill
{
    internal class DoubleSkill: ISkill
    {
        public SkillType SkillType { get; }

        public string Description { get; }

        public DoubleSkill()
        {
            SkillType = SkillType.DOUBLE;
            //Description = "더블 스트라이크 - MP 15\n   공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.\n";
            Description = "더블 스트라이크(MP 15) 공격력 * 1.5 로 2명의 적을 랜덤 공격";
        }

        public void Use(Player player, List<ICharacter> monsterList)
        {
            //Console.Clear();

            //Extension.TypeWriting("Battle!!\n");
            Console.SetCursorPosition(30, 32);
            Extension.TypeWriting($"{player.Name}의 더블 스트라이크 공격!");
            Console.WriteLine();

            int damage = (int)((player.Attack + player.AddAtk) * 1.5); // 플레이어 공격력 * 1.5

            List<int> targetMonsterIdxList = GetRandomAliveMonsterIdx(monsterList); // 공격할 몬스터 인덱스가 담긴 리스트
            List<int> targetMonsterPrevHP = new List<int>();    // 공격할 몬스터의 이전 체력을 담을 배열

            foreach (int idx in targetMonsterIdxList)
            {
                Monster curMonster = (Monster)monsterList[idx];
                targetMonsterPrevHP.Add(curMonster.CurrentHealth);
                Console.SetCursorPosition(30, Console.CursorTop);
                curMonster.TakeDamage(damage);
            }
            
            Console.WriteLine();

            int prevHpIdx = 0;
            // 더블 스트라이크 결과 출력
            foreach (int idx in targetMonsterIdxList)
            {
                Console.SetCursorPosition(30, Console.CursorTop);
                Console.WriteLine($"Lv.{monsterList[idx].Level} {monsterList[idx].Name}");

                Console.SetCursorPosition(30, Console.CursorTop);
                Console.WriteLine($"HP {targetMonsterPrevHP[prevHpIdx++]} -> {monsterList[idx].CurrentHealth}\n");
            }
        }

        // Monster 배열을 받아서 살아있는 몬스터 중 랜덤으로 2마리를 뽑고, 그 몬스터의 인덱스를 리스트에 담아 반환
        // 리스트 크기가 1일 때는 1마리만 뽑아서 리턴
        private List<int> GetRandomAliveMonsterIdx(List<ICharacter> monsterList)
        {
            int maxLength = 2;
            List<int> randomIdx = new List<int>();

            while (randomIdx.Count < maxLength)
            {
                if (monsterList.Where(x => !x.IsDead).Count() == 1)
                {
                    int aliveMonsterIdx = monsterList.FindIndex(x => !x.IsDead);
                    randomIdx.Add(aliveMonsterIdx);
                    break;
                }

                int idx = new Random().Next(0, monsterList.Count);

                if (!((Monster)monsterList[idx]).IsDead && !randomIdx.Contains(idx)) randomIdx.Add(idx);
            }

            return randomIdx;
        }
    }
}
