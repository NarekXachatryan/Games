using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChingaChung
{
    class Player
    {
        public string step;
       
        public string StepPlayer()
        {
            Console.WriteLine("What do you want to coose " );
            Console.WriteLine();
            Console.WriteLine("1. Paper");
            Console.WriteLine("2. Stone");
            Console.WriteLine("3. Scissors");
            var keyinfo1 = Console.ReadKey();
            if (keyinfo1.Key == ConsoleKey.D1)
            {
                step = "paper";

            }
            else if (keyinfo1.Key == ConsoleKey.D2)
            {
                step = "stone";
            }
            else if (keyinfo1.Key == ConsoleKey.D3)
            {
                step = "scissors";
            }
            else
            {
                Console.Clear();
                StepPlayer();
            }
            return step;
        }
    }
}
