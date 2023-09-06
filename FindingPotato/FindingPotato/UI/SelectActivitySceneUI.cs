﻿using FindingPotato.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class SelectActivitySceneUI
    {
        public static int GetPlayerActivity(string playerName)
        {
            int x = 5, y = 3;

            UIExtension.PrintSuperMarketFrame(x, y);

            x = 60;
            y = 15;
            Console.SetCursorPosition(x + 5, y++);
            Extension.TypeWriting($"어서오세요. {playerName} 님");
            Console.SetCursorPosition(x, y++);
            Extension.TypeWriting("이곳에서 활동을 할 수 있습니다.\n");

            return UIExtension.GetPlayerSelectFromUI(65, 20, 4, new string[] { " 1. 상 태 보 기 ", " 2. 인 벤 토 리 ", " 3. 전 투 시 작 ", " 0. 게 임 종 료 " }, true);
        }
    }
}
