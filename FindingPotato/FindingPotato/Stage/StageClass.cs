using FindingPotato.Character;
using FindingPotato.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Stage
{
    internal class StageClass
    {
        private Player player; // 플레이어
        private ICharacter monster; // 몬스터
        private List<IItem> rewards; // 보상 아이템들

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        public StageClass(Player player, ICharacter monster, List<IItem> rewards)
        {
            this.player = player;
            this.monster = monster;
            this.rewards = rewards;
            OnCharacterDeath += StageClear; // 캐릭터가 죽었을 때 StageClear 메서드 호출
        }

        // 스테이지 시작 메서드
        public void Start()
        {

        }

        // 스테이지 클리어 메서드
        private void StageClear(ICharacter character)
        {

        }

        // Player가 공격과 스킬 중 스킬 선택 시 실행
        private void PrintAttackWithMP()
        {
            Console.WriteLine("1. 알파 스트라이크 - MP 10");
            Console.WriteLine("공격력 * 2 로 하나의 적을 공격합니다.");
            Console.WriteLine("2. 더블 스트라이크 - MP 15");
            Console.WriteLine("공격력 * 1.5 로 2명의 적을 랜덤으로 공격합니다.");
            Console.WriteLine("0. 취소");

            // Player 선택 값 받아와서 Player 객체에 넘겨주기
            //int select = GetPlayerSelect(0, 2);
            // bool isPossibleToAttack = player.AttackWithMP(select);

            // 알파 스트라이크면 하나의 몬스터를 공격력 * 2로 공격
            // if (isPossibleToAttack)
            // {
            //if (select == 1)
            //{
            //    monster.TakeDamage(player.Attack * 2);
            //}

            // 더블 스트라이크면 몬스터 리스트에서 2개의 랜덤한 몬스터를 공격력 * 1.5로 공격
            //else if (select == 2)
            //{
            //    List<int> randomIdx = GetRandomIdx(2, 0, monsterList.Count);
            //    foreach (int idx in randomIdx)
            //    {
            //        monsterList[idx].TakeDamage((int)(player.Attack * 1.5));
            //    }
            //}
            //}
        }

        private List<int> GetRandomIdx(int idxNum, int min, int max)
        {
            List<int> randomIdx = new List<int>();

            while (randomIdx.Count < idxNum) {
                int currentNum = new Random().Next(min, max);
                if (randomIdx.Contains(currentNum))
                {
                    currentNum = new Random().Next(min, max);
                }
                randomIdx.Add(currentNum);
            }

            return randomIdx;
        }

        // TODO 공격 시 IsOccur(15, 1, 101) == true이면 monster.TakeDamage(player.Attack * 1.6);
        // else monster.TakeDamage(player.Attack)
        // TODO 공격 시 IsOccur(10, 1, 101) == true이면 스킬 회피 else monster.TakeDamage
        private bool IsOccur(int prob, int min, int max)
        {
            int isOccur = new Random().Next(min, max);
            if (isOccur <= prob) return true;
            else return false;
        }
    }
}
