using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChingaChung
{
    class Bot
    {
        
        public string step;
        public string StepBot()
        {
            Random rand = new Random();
            int number = rand.Next(1, 4);
            if (number == 1)
            {
                step= "paper";
            }
            if (number == 2)
            {
                step = "stone";
            }
            if (number == 3)
            {
                step = "scissors";
            }
            return step;
        }
    }
}
