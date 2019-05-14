using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XandO
{
    class GameClass 
    {
        public char Pl1;
        public char Pl2;
        public void MainManu(ref char Pl1, ref char Pl2)
        {
            Console.WriteLine("Player 1: X OR O");
            Console.WriteLine("1. X");
            Console.WriteLine("2. O");
            var keyinfo1 = Console.ReadKey();
            if (keyinfo1.Key == ConsoleKey.D1)
            {

                Pl1 = 'X';
                Pl2 = 'O';
            }
            else if (keyinfo1.Key == ConsoleKey.D2)
            {
                Console.WriteLine("Player 1: O");
                Console.WriteLine("Player 2: X");
                Pl1 = 'O';
                Pl2 = 'X';

            }
            else
            {
                Console.WriteLine("\n\nWrong input, please wait 2 seconds...");
                Thread.Sleep(2000);
                Console.Clear();
                MainManu(ref Pl1, ref Pl2);
            }
            Console.Clear();
        }
        char[,] Arr = new char[3, 3];
      
        public void Game()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Arr[i, j] =' ';
                }
            }
            Console.WriteLine("Player 1: "+Pl1);
            Console.WriteLine("Player 2: "+Pl2);
            int k = 0;
            bool gamestatus = true;
            while (gamestatus && k < 5)
            {
                
                if (Pl1 == 'X')
                {
                    
                    Pl11(ref gamestatus);
                    k++;
                    if (k < 5&& gamestatus == true)
                    {
                        Pl21(ref gamestatus);
                    }
                }
                else
                {
                    Pl21(ref gamestatus);
                    k++;
                    if (k < 5 && gamestatus == true)
                    {
                        Pl11(ref gamestatus);
                    }
                }


                

                

            }
            if (gamestatus == true)
            {
                Console.Clear();
                Console.WriteLine("Draw");
            }

            Console.WriteLine("┌───┬───┬───┐");
            Console.WriteLine("│ " + Arr[0, 0] + " │ " + Arr[0, 1] + " │ " + Arr[0, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[1, 0] + " │ " + Arr[1, 1] + " │ " + Arr[1, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[2, 0] + " │ " + Arr[2, 1] + " │ " + Arr[2, 2] + " │");
            Console.WriteLine("└───┴───┴───┘");
            Console.WriteLine();


        }
        public void Pl11(ref bool gamestatus)
        {
            Console.WriteLine("┌───┬───┬───┐");
            Console.WriteLine("│ " + Arr[0, 0] + " │ " + Arr[0, 1] + " │ " + Arr[0, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[1, 0] + " │ " + Arr[1, 1] + " │ " + Arr[1, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[2, 0] + " │ " + Arr[2, 1] + " │ " + Arr[2, 2] + " │");
            Console.WriteLine("└───┴───┴───┘");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Player 1:");
            var keyinfo1 = Console.ReadKey();
            switch (keyinfo1.Key)
            {
                case ConsoleKey.D1:
                    {
                        if (Arr[0, 0] != Pl1 && Arr[0, 0] != Pl2)
                        {
                            Arr[0, 0] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        if (Arr[0, 1] != Pl1 && Arr[0, 1] != Pl2)
                        {
                            Arr[0, 1] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;

                    }
                case ConsoleKey.D3:
                    {
                        if (Arr[0, 2] != Pl1 && Arr[0, 2] != Pl2)
                        {
                            Arr[0, 2] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }

                case ConsoleKey.D4:
                    {
                        if (Arr[1, 0] != Pl1 && Arr[1, 0] != Pl2)
                        {

                            Arr[1, 0] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        if (Arr[1, 1] != Pl1 && Arr[1, 1] != Pl2)
                        {
                            Arr[1, 1] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D6:
                    {
                        if (Arr[1, 2] != Pl1 && Arr[1, 2] != Pl2)
                        {
                            Arr[1, 2] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D7:
                    {
                        if (Arr[2, 0] != Pl1 && Arr[2, 0] != Pl2)
                        {
                            Arr[2, 0] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D8:
                    {
                        if (Arr[2, 1] != Pl1 && Arr[2, 1] != Pl2)
                        {
                            Arr[2, 1] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D9:
                    {
                        if (Arr[2, 2] != Pl1 && Arr[2, 2] != Pl2)
                        {
                            Arr[2, 2] = Pl1;
                        }
                        else
                        {
                            Console.Clear();
                            Pl11(ref gamestatus);
                        }
                        break;
                    }
                default :
                    {
                        Console.WriteLine("\n\nWrong input, please wait 2 seconds...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Pl11(ref gamestatus);
                        break;
                    }
            }
            Console.Clear();
            if (Arr[0, 0] == Pl1 && Arr[0, 1] == Pl1 && Arr[0, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
                
            }
            else if (Arr[0, 0] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl1 && Arr[1, 0] == Pl1 && Arr[2, 0] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl1 && Arr[1, 2] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 0] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[2, 0] == Pl1 && Arr[2, 1] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 1] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 1] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[1, 0] == Pl1 && Arr[1, 1] == Pl1 && Arr[1, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[0, 1] == Pl2 && Arr[0, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[1, 0] == Pl2 && Arr[2, 0] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl2 && Arr[1, 2] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 0] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[2, 0] == Pl2 && Arr[2, 1] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 1] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 1] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[1, 0] == Pl2 && Arr[1, 1] == Pl2 && Arr[1, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }

           


        }
        public void Pl21(ref bool gamestatus)
        {
            Console.WriteLine("┌───┬───┬───┐");
            Console.WriteLine("│ " + Arr[0, 0] + " │ " + Arr[0, 1] + " │ " + Arr[0, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[1, 0] + " │ " + Arr[1, 1] + " │ " + Arr[1, 2] + " │");
            Console.WriteLine("├───┼───┼───┤");
            Console.WriteLine("│ " + Arr[2, 0] + " │ " + Arr[2, 1] + " │ " + Arr[2, 2] + " │");
            Console.WriteLine("└───┴───┴───┘");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Player 2:");
            var keyinfo2 = Console.ReadKey();
             switch (keyinfo2.Key)
            {
                case ConsoleKey.D1:
                    {
                        if (Arr[0, 0] != Pl1 && Arr[0, 0] != Pl2)
                        {
                            Arr[0, 0] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        if (Arr[0, 1] != Pl1 && Arr[0, 1] != Pl2)
                        {
                            Arr[0, 1] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;

                    }
                case ConsoleKey.D3:
                    {
                        if (Arr[0, 2] != Pl1 && Arr[0, 2] != Pl2)
                        {
                            Arr[0, 2] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }

                case ConsoleKey.D4:
                    {
                        if (Arr[1, 0] != Pl1 && Arr[1, 0] != Pl2)
                        {

                            Arr[1, 0] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D5:
                    {
                        if (Arr[1, 1] != Pl1 && Arr[1, 1] != Pl2)
                        {
                            Arr[1, 1] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D6:
                    {
                        if (Arr[1, 2] != Pl1 && Arr[1, 2] != Pl2)
                        {
                            Arr[1, 2] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D7:
                    {
                        if (Arr[2, 0] != Pl1 && Arr[2, 0] != Pl2)
                        {
                            Arr[2, 0] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D8:
                    {
                        if (Arr[2, 1] != Pl1 && Arr[2, 1] != Pl2)
                        {
                            Arr[2, 1] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                case ConsoleKey.D9:
                    {
                        if (Arr[2, 2] != Pl1 && Arr[2, 2] != Pl2)
                        {
                            Arr[2, 2] = Pl2;
                        }
                        else
                        {
                            Console.Clear();
                            Pl21(ref gamestatus);
                        }
                        break;
                    }
                default:
                    {
                        Console.Clear();
                        Pl21(ref gamestatus);
                        break;
                    }
            }
            Console.Clear();
            if (Arr[0, 0] == Pl1 && Arr[0, 1] == Pl1 && Arr[0, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl1 && Arr[1, 0] == Pl1 && Arr[2, 0] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl1 && Arr[1, 2] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 0] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[2, 0] == Pl1 && Arr[2, 1] == Pl1 && Arr[2, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 1] == Pl1 && Arr[1, 1] == Pl1 && Arr[2, 1] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[1, 0] == Pl1 && Arr[1, 1] == Pl1 && Arr[1, 2] == Pl1)
            {
                Console.WriteLine(Pl1 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[0, 1] == Pl2 && Arr[0, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 0] == Pl2 && Arr[1, 0] == Pl2 && Arr[2, 0] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl2 && Arr[1, 2] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 2] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 0] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[2, 0] == Pl2 && Arr[2, 1] == Pl2 && Arr[2, 2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[0, 1] == Pl2 && Arr[1, 1] == Pl2 && Arr[2, 1] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }
            else if (Arr[1, 0] == Pl2 && Arr[1, 1] == Pl2 && Arr[1,2] == Pl2)
            {
                Console.WriteLine(Pl2 + " winer");
                gamestatus = false;
            }

          

        }
    }
}