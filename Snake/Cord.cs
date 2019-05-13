using System;
using System.Collections.Generic;
using System.Text;

namespace Narek
{
    class Cord
    {
        private int x;
        private int y;
        private char tail;
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public char Tail { get => tail; set => tail = value; }

        public Cord(int X,int Y,char tail)
        {
            this.X = X;
            this.Y = Y;
            this.tail = tail;
        }
        public Cord()
        {

        }
    }
}
