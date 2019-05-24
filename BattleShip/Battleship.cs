using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Battleship
    {
        protected const int four = 1;
        protected const int three = 2;
        protected const int two = 3;
        protected const int one = 4;
        public int[,] Field1 = new int[10, 10]; //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
        public static readonly string[] str1 = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
        public static readonly string[] str2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public int Step = new int();
        protected int[] Letter = new int[101];
        protected int[] Index = new int[101];
        public int Points = 0;
        public static int Indent = 2;
        public int Number = 0;

        protected static int[,] BotField = new int[10, 10];

        protected static int[,] UserField = new int[10, 10];

        public void Output(int[,] Field)
        {
            if (Indent > 20)
            {
                Indent = 2;
                Console.Clear();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 0);
                Console.Write(str1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.Write(str2[i]);
                Console.SetCursorPosition(2, i + 1);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    Part(UserField[i, j]);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 13);
                Console.Write(str1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 14);
                Console.Write(str2[i]);
                Console.SetCursorPosition(2, i + 14);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 14);
                    Part(Field[i, j]);

                }
            }
        }
        public void Part(int a)
        {
            switch (a)
            {
                case 0:
                    Console.Write('+');
                    break;
                case 1:
                    Console.Write('\u25A0');
                    break;
                case 2:
                    Console.Write('X');
                    break;
                case 3:
                    Console.Write('O');
                    break;
            }
        }
        protected void Stroke(int[,] Field, int i, int j)
        {
            int Long = 1;
            int x = j;
            int y = i;
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i - k, j] == 2)
                    {
                        Long++;
                        y--;
                    }
                    if (Field[i - k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i - k, j] == 0 || Field[i - k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i + k, j] == 2)
                    {
                        Long++;
                    }
                    if (Field[i + k, j] == 1)
                    {
                        return;
                    }
                    if (Field[i + k, j] == 0 || Field[i + k, j] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int k = y - 1; k < y + Long + 1 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k++;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[k, l] != 2)
                        {
                            Field[k, l] = 3;
                            Field1[k, l] = 3;
                        }
                    }
                }
                return;
            }

            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j - k] == 2)
                    {
                        Long++;
                        x--;
                    }
                    if (Field[i, j - k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j - k] == 0 || Field[i, j - k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            for (int k = 1; k < 4; k++)
            {
                try
                {
                    if (Field[i, j + k] == 2)
                    {
                        Long++;
                    }
                    if (Field[i, j + k] == 1)
                    {
                        return;
                    }
                    if (Field[i, j + k] == 0 || Field[i, j + k] == 3)
                    {
                        break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            if (Long > 1)
            {
                for (int l = y - 1; l < y + 2 && l < 10; l++)
                {
                    for (int k = x - 1; k < x + Long + 1 && k < 10; k++)
                    {
                        if (k < 0)
                        {
                            k++;
                        }
                        if (l < 0)
                        {
                            l++;
                        }
                        if (Field[l, k] != 2)
                        {
                            Field[l, k] = 3;
                            Field1[l, k] = 3;
                        }
                    }
                }
                return;
            }

            if (Long == 1)
            {
                for (int k = y - 1; k < y + 2 && k < 10; k++)
                {
                    if (k < 0)
                    {
                        k = 0;
                    }
                    for (int l = x - 1; l < x + 2 && l < 10; l++)
                    {
                        if (l < 0)
                        {
                            l = 0;
                        }
                        if (Field[k, l] != 2)
                        {
                            Field[k, l] = 3;
                            Field1[k, l] = 3;
                        }
                    }
                }
            }
        }
    }
}
