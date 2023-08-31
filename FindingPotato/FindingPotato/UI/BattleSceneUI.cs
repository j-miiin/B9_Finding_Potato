using FindingPotato.Character;
using FindingPotato.Character.Monster;
using FindingPotato.Stage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindingPotato.UI
{
    internal class BattleSceneUI
    {
        public static int GetPlayerSelect(int mode)
        {
            //Console.SetCursorPosition(30, 4);
            //Console.WriteLine("=======================================================================================");//88

            //Console.SetCursorPosition(30, 31);
            //Console.WriteLine("=======================================================================================");

            Console.SetCursorPosition(30, 31);
            string[] selectMain = { "1.공    격", "2.스    킬", "0.도망가기" };


            string[] next = { "0.다음" };



            switch (mode)
            {
                case 1:
                    return UIExtension.GetPlayerSelectFromUI(106, 28, 1, selectMain, true);
                case 2:
                    return UIExtension.GetPlayerSelectFromUI(30, 40, 1, next, true);

                default:
                    return 0;
            }

        }

        public static void GetResultBox()
        {
            string[] box = {
                         "┌─────────────────────────────────────────────────────┐" ,
                         "│                                                     │" ,
                         "└─────────────────────────────────────────────────────┘" };

            
            Console.SetCursorPosition(43, 4);
            Console.WriteLine(box[0]);
            for(int i=0; i<20; i++)
            {
                Console.SetCursorPosition(43, Console.CursorTop);
                Console.WriteLine(box[1]);
            }
            Console.SetCursorPosition(43, Console.CursorTop);
            Console.WriteLine(box[2]);


            string[] next = { "0.다음" };

        }
    }
}
