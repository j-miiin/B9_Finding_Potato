using FindingPotato.Character;
using FindingPotato.Stage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class SelectStageScene
    {
       public static int GetStageSelect(int stageState)
        {
            int x = 5, y = 3;

            UIExtension.PrintSuperMarketFrame(x, y);

            x = 37; y = 15;
            Console.SetCursorPosition(x, y);
            Extension.ColorWriteLine("감자를 구하러 가려면 과일코너에서  채소코너를 지나감자 진열대 까지 가야해 !\n");

            string[] stageStrList = { " 1. 과  일  코  너 (Easy) ",
                                      " 2. 야  채  코  너 (Normal) ",
                                      " 3. 감 자 진 열 대 (Hard) ", 
                                      " 0. 전  투  종  료 " };

            x = 35; y = 20;
            bool[] isLimited = new bool[stageStrList.Length + 1];
            for (int i = stageState + 1; i < isLimited.Length - 1; i++) isLimited[i] = true;
            return UIExtension.GetPlayerSelectFromUI(x, y, 4, stageStrList, true, isLimited);
        }
    }
}


