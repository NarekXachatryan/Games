using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();
                GameZone Zone = new GameZone();
                Zone.Random(2);
                Zone.Random(4);

                game.GameStart();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("End");
            }
        }
    }
}
