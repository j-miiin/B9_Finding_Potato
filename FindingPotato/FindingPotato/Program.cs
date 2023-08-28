using FindingPotato.Character.Monster;
using FindingPotato.Character;
using FindingPotato.Item;

namespace FindingPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Player"); // 플레이어 생성
            Paprika paprika = new Paprika("Paprika"); // 고블린 생성
            Onion onion = new Onion("Onion"); // 드래곤 생성

            // 각 스테이지의 보상 아이템들
            List<IItem> stage1Rewards = new List<IItem> { new HealthPotion(), new StrengthPotion() };
            List<IItem> stage2Rewards = new List<IItem> { new StrengthPotion(), new HealthPotion() };

            // 스테이지 1
            Stage stage1 = new Stage(player, paprika, stage1Rewards);
            stage1.Start();
        }
    }
}