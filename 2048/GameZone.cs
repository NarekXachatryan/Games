using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class GameZone
    {
        Random rand = new Random();
        public string[,] Zone = new string[4, 4];
        public GameZone()
        {
           
            PrintZone();          
        }
        public void PrintZone()
        {     
            for (int i = 0; i < Zone.GetLength(0); i++)
            {
                for (int j = 0; j < Zone.GetLength(1); j++)
                {
                    Zone[i, j] = new string(' ',Game.maxLength);            
                }               
            }
        }
        List<Coordy> coord;
        public void Random(int num)
        {
            Console.Clear();
            int count=0;
            coord = new List<Coordy>();
            for (int i = 0; i < Zone.GetLength(0); i++)
            {
                for (int j = 0; j < Zone.GetLength(1); j++)
                {
                    if(Zone[i,j]=="    ")
                    {
                        coord.Add(new Coordy(i, j));
                        count++;
                    }
                }
            }
            int k = rand.Next(0, count - 1);
            Zone[coord[k].i, coord[k].j] = num.ToString()+ new string(' ', Game.maxLength-1);
            Print();
            Console.WriteLine($"Point : {Game.point}");
        }
        public void Print()
        {
            Console.Clear();
            Console.WriteLine($"┌────┬────┬────┬────┐");
            Console.WriteLine($"│{Zone[0,0]}│{Zone[0, 1]}│{Zone[0, 2]}│{Zone[0, 3]}│");
            Console.WriteLine($"├────┼────┼────┼────┤");
            Console.WriteLine($"│{Zone[1, 0]}│{Zone[1, 1]}│{Zone[1, 2]}│{Zone[1, 3]}│");
            Console.WriteLine($"├────┼────┼────┼────┤");
            Console.WriteLine($"│{Zone[2, 0]}│{Zone[2, 1]}│{Zone[2, 2]}│{Zone[2, 3]}│");
            Console.WriteLine($"├────┼────┼────┼────┤");
            Console.WriteLine($"│{Zone[3, 0]}│{Zone[3, 1]}│{Zone[3, 2]}│{Zone[3, 3]}│");
            Console.WriteLine($"└────┴────┴────┴────┘");
          
        }
    }
    class Coordy
    {
        public int i;
        public int j;

        public Coordy(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
        public Coordy()
        {

        }
    }
}
