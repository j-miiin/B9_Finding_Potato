using FindingPotato.Character;
using FindingPotato.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.Stage
{
    internal class Stage
    {
        private ICharacter player; // 플레이어
        private ICharacter monster; // 몬스터
        private List<IItem> rewards; // 보상 아이템들

        // 이벤트 델리게이트 정의
        public delegate void GameEvent(ICharacter character);
        public event GameEvent OnCharacterDeath; // 캐릭터가 죽었을 때 발생하는 이벤트

        public Stage(ICharacter player, ICharacter monster, List<IItem> rewards)
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
    }
}
