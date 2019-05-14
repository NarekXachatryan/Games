using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XandO
{
    class Program
    {
        static void Main(string[] args)
        {
            bool GameStatus = true;
            while (GameStatus)
            {
                GameClass gmc = new GameClass();
                gmc.MainManu(ref gmc.Pl1, ref gmc.Pl2);
                gmc.Game();

                Console.WriteLine("Play again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                var keyinfo1 = Console.ReadKey();
                if (keyinfo1.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    GameStatus = false;
                    Console.WriteLine("End");
                }
            }


        }
    }
}
