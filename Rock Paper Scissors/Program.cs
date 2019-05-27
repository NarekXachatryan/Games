using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChingaChung
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Bot bt = new Bot();
            Player pl = new Player();
            Start st = new Start();
            st.Start1();
            Game(bt, pl,st);
        }
        public static void Game(Bot bt, Player pl,Start st)
        {
            pl.StepPlayer();
            bt.StepBot();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You :" + pl.step);
            Console.WriteLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Bot :" + bt.step);

           
            Console.ForegroundColor = ConsoleColor.White;
            if (pl.step == "paper" && bt.step == "paper")
            {

                Console.WriteLine("Draw");
            }
            else if (pl.step == "paper" && bt.step == "stone")
            {
                Point.playerpoint++;
                Console.WriteLine("You win");

            }
            else if (pl.step == "paper" && bt.step == "scissors")
            {
                Point.botpoint++;
                Console.WriteLine("You lost");

            }

           
            else if (pl.step == "stone" && bt.step == "paper")
            {
                Point.botpoint++;
                Console.WriteLine("You lost");

            }
            else if (pl.step == "stone" && bt.step == "stone")
            {
                Console.WriteLine("Draw");
            }
            else if (pl.step == "stone" && bt.step == "scissors")
            {
                Point.playerpoint++;
                Console.WriteLine("You win");

            }

            else if (pl.step == "scissors" && bt.step == "paper")
            {
                Point.playerpoint++;
                Console.WriteLine("You win");

            }
            else if (pl.step == "scissors" && bt.step == "paper")
            {
                Point.botpoint++;
                Console.WriteLine("You lost");

            }
            else if (pl.step == "scissors" && bt.step == "scissors")
            {
                Console.WriteLine("Draw");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your point : " + Point.playerpoint);
            Console.WriteLine("Bot point : " + Point.botpoint);

            if (Point.playerpoint != st.highschore && Point.botpoint != st.highschore)
            {

                Continue1(bt, pl,st);


            }
            if (Point.playerpoint == st.highschore)
            {
                Console.Clear();
                Console.WriteLine("You Win");
            }
            if (Point.botpoint == st.highschore)
            {
                Console.Clear();
                Console.WriteLine("You Lose");
            }



        }
        public static void Continue1(Bot bt, Player pl,Start st)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Want to continue?");
            Console.WriteLine();
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            var keyinfo2 = Console.ReadKey();
            if (keyinfo2.Key == ConsoleKey.D1)
            {
                Console.Clear();
                Game(bt, pl,st);
            }
            else if (keyinfo2.Key == ConsoleKey.D2)
            {
                Console.Clear();

                Console.WriteLine("YOU LOST!");
            }
            else
            {
                Console.Clear();
                Continue1(bt, pl, st);
            }

        }
       

    }
}
