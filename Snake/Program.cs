using System;
using System.Threading.Tasks;
using System.Threading;
namespace Narek
{
    class Program
    {
        static void Main(string[] args)
        {         
            Game();
            Console.WriteLine("Game Over");     
        }
        static void Game()
        {
            Snake s = new Snake();
            s.Ground();
            s.Move();
            Console.Clear();
                 
        }
    }
}
