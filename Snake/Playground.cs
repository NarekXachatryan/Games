using System;
using System.Collections.Generic;
using System.Text;

namespace Narek
{
    class Playground
    {
        private int size1;
        private int size2;
        public Playground(int size1, int size2)
        {
            this.size1 = size1;
            this.size2 = size2;
            graund = new char[size1, size2];
        }
        public Playground()
        {

        }
        public char[,] graund ;

    }
}
