using FindingPotato.Character;
using FindingPotato.Character.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class EndingScene
    {
       
        static string deadPotatoStr = @"

                                                                      ______
                                                                     /      \                   
                                                                    |  ⊙ ⊙ | 
                                                                    |    ^   |
                                                                   /\   --   /\                 
                                                                  /  \______/  \                                                              
                                                                        / \
                                                                       /   \";

        static string deadSweetPotato = @"   

                                                                        ____                    
                                                                      /      \
                                                                     |        |
                                                                     |   O O  |            
                                                                     |    ^   |
                                                                    /|   --   |\
                                                                   /  \       / \
                                                                       \_____/
                                                                         / \
                                                                        /   \
";

        static string deadCarrotStr = @"

                                                                         \ | /
                                                                         _\|/__                    
                                                                        /      \
                                                                       |  ⊙ ⊙ |            
                                                                       |    ^   |
                                                                       /\   --  /\ 
                                                                      /  \     /  \
                                                                          \   / 
                                                                        /  \ / \
                                                                       /        \ ";

        static string Image = " \r\n     ______\r\n    /      \\  \r\n\\  /  ⊙ ⊙ \\  /\r\n \\|    ▲    |/\r\n  \\     V    /   \r\n   \\________/     \r\n       / \\\r\n      /   \\";

        static string[] potatoRecipe = {"<감자전 조리법>",
                                        "1.감자를 씻어 껍질을 벗겨 준 후, 깍둑썰기로 썰어 믹서기에 넣어줍니다" ,
                                        "2.물을 조금 넣고 갈아준 감자는 채반에 15분정도 두어 전분과 물을 빼줍니다",
                                        "3.빠진 물은 버리고 전분을 섞어 소금, 후추 간을 해줍니다",
                                        "4.후라이팬에 한입크기로 부쳐주면 완성!"};

        static string[] sweetPotatoRecipe = {"<고구마 맛탕 조리법>",
                                             "1.고구마를 씻어 껍질을 번겨준 후 먹기 좋은 크기로 썰어줍니다",
                                             "2.손질한 고구마를 웍에 넣고 설탕을 세스푼 흩뿌려줍니다",
                                             "3.고구마가 반정도 잠길만큼의 기름을 넣어 센불에 튀겨주세요",
                                             "4.기름이 자글자글 끓기 시작하면 중불로 줄여서 한번씩 뒤적여주며 튀겨줍니다",
                                             "5.고구마의 색이 전체적으로 노랗게 변하고 끄트머리쪽이 갈색으로 변한다면 다시 센불로 올려서 두어번 뒤적여주면 완성!" };

        static string[] carrotRecipe = { "<당근 케이크 조리법>",
                                        "1.분량의 계란과 설탕, 식용유를 함께 섞어줍니다",
                                         "2.갈아진 당근과 베이킹파우더를 넣고 잘 섞어줍니다",
                                         "3.나머지 재료를 모두 넣고 잘 섞어주고, 동시에 오븐도 200도로 예열시켜주세요",
                                         "4.케익시트 틀에 기름칠을 해주고,위에 빵가루도 뿌려줍니다",
                                         "5.잘 섞어진 재료를 넣고 오븐에 약 40분 정도 구워주면 완성! "};




        public static void VictoryScene(Player player)
        {
            string str = @"



 
                             〓〓〓〓〓〓〓〓〓〓

                             ■■■■■■■ ■          ■  ■■■■■■■   ■■■■■■■  ■■      ■  ■■■■■
                                   ■       ■          ■  ■               ■              ■ ■     ■  ■        ■
                                   ■       ■          ■  ■               ■              ■  ■    ■  ■          ■
                                   ■       ■■■■■■■  ■■■■■■■   ■■■■■■■  ■   ■   ■  ■          ■
                                   ■       ■          ■  ■               ■              ■    ■  ■  ■          ■
                                   ■       ■          ■  ■               ■              ■     ■ ■  ■        ■
                                   ■       ■          ■  ■■■■■■■   ■■■■■■■  ■      ■■  ■■■■■

                                                                                                       〓〓〓〓〓〓〓〓〓〓



                                                          내 친구 감자를 구했다!!


";


            Console.WriteLine(str);

            UIExtension.DrawCharacter(player.Image, 48, 23);
            UIExtension.DrawCharacter(Image, 71, 24);

            UIExtension.PrintFloor(33); 


            Console.SetCursorPosition(63, Console.CursorTop + 3);
            Console.WriteLine("아무키나 눌러서 종료...");
            Console.ReadKey();
            Environment.Exit(0);

        }

        public static void DeadScene(Player player)
        {
            string str = @"


                                    〓〓〓〓〓〓〓〓〓〓〓〓〓

                                    ■     ■  ■■■   ■    ■    ■■■■    ■■■■■  ■■■■■  ■■■■    
                                     ■   ■  ■    ■  ■    ■    ■      ■      ■      ■          ■      ■            
                                      ■ ■   ■    ■  ■    ■    ■       ■     ■      ■■■■■  ■       ■             
                                       ■     ■    ■  ■    ■    ■       ■     ■      ■          ■       ■              
                                       ■     ■    ■  ■    ■    ■      ■      ■      ■          ■      ■      
                                       ■      ■■■    ■■■     ■■■■    ■■■■■  ■■■■■  ■■■■              

                                                                                              〓〓〓〓〓〓〓〓〓〓〓〓〓



";

            Console.WriteLine(str);
            switch(player.Type)
            {
                case VegetableType.감자:
                    for(int i = 0; i<potatoRecipe.Length; i++)
                    {
                        Extension.CenterAlign(potatoRecipe[i]);
                        Thread.Sleep(500); 
                        Console.WriteLine(); 
                    }
                    Console.WriteLine(deadPotatoStr);   
                        break;
                case VegetableType.고구마:
                    for (int i = 0; i < potatoRecipe.Length; i++)
                    {
                        Extension.CenterAlign(sweetPotatoRecipe[i]);
                        Console.WriteLine();
                    }
                    Console.WriteLine(deadSweetPotato); 
                    break;
                case VegetableType.당근:
                    for (int i = 0; i < potatoRecipe.Length; i++)
                    {
                        Extension.CenterAlign(carrotRecipe[i]);
                        Console.WriteLine(); 
                    }
                    Console.WriteLine(deadCarrotStr);
                    break;
            }

            Console.SetCursorPosition(65, Console.CursorTop+3); 
            Console.WriteLine("아무키나 눌러서 종료...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
