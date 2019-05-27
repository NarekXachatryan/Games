using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChingaChung
{
    class Start
    {
        public int highschore;
        public  int Start1()
        {
            Console.Write("What highschore do you want to be : ");
             highschore = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return highschore;
        }
    }
}
