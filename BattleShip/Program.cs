using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        internal class Program
        {
            public static void Main(string[] args)
            {
                var User = new User();
                var Bot = new Bot();
                Boolean yes = true;
                while (yes)
                {
                    while (true)
                    {
                        User.Output(User.Field1);
                        User.Strike();
                        if (User.Win())
                        {
                            break;
                        }
                        Bot.Strike();
                        if (Bot.Win())
                        {
                            break;
                        }
                    }
                    Console.SetCursorPosition(30, 1);
                    Console.WriteLine("Спасибо за игру! Хотите сыграть еще раз? ");
                    if (Console.ReadLine() != "да")
                    {
                        yes = false;
                    }
                }
            }
        }
    }

    

