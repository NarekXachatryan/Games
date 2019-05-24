using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Bot : Battleship
    {
        public Bot()
        {
            Four();
            while (Number < three)
            {
                Three();
            }
            Number = 0;
            while (Number < two)
            {
                Two();
            }
            Number = 0;
            while (Number < one)
            {
                One();
            }
        }

        public void Strike()
        {
            if (Win())
            {
                return;
            }
            Random();
            Console.SetCursorPosition(30, Indent++);
            Console.WriteLine("Hakarakordi krakocy: " + str1[Letter[Step]] + (Index[Step] + 1));
            if (Hit(Index[Step], Letter[Step]))
            {
                Step++;
                Points++;
                Strike();
            }
        }

        private void Random()
        {
            var random = new Random(DateTime.Now.Millisecond);
            Letter[Step] = random.Next(9);
            Index[Step] = random.Next(9);
            if (Field1[Index[Step], Letter[Step]] > 0)
            {
                Random();
            }
        }

        public bool Hit(int i, int j)
        {
            if (UserField[i, j] == 0)
            {
                Field1[i, j] = 3;
                UserField[i, j] = 3;
                return false;
            }
            if (UserField[i, j] == 1)
            {
                Field1[i, j] = 2;
                UserField[i, j] = 2;
                Stroke(UserField, i, j);
                return true;
            }
            if (UserField[i, j] > 1)
            {
                return false;
            }
            return false;
        }

        public bool Win()
        {
            if (Points == 20)
            {
                Console.SetCursorPosition(10, 0);
                Console.Write("duq partveciq!");
                return true;
            }
            return false;
        }

        private void Four()
        {
            var random = new Random();
            int x = random.Next(10);
            int y = random.Next(10);
            if (x > 5)
            {
                y = random.Next(5);
                for (int i = y; i < y + 4; i++)
                {
                    BotField[i, x] = 1;
                }
                return;
            }
            if (y > 5)
            {
                x = random.Next(5);
                for (int j = x; j < x + 4; j++)
                {
                    BotField[y, j] = 1;
                }
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y; i < y + 4; i++)
                {
                    BotField[i, x] = 1;
                }
            }
            else
            {
                for (int j = x; j < x + 4; j++)
                {
                    BotField[y, j] = 1;
                }
            }
        }
        private void Three()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 6)
            {
                x = random.Next(7);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 4; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    BotField[y, j] = 1;
                }
                Number++;
                return;
            }
            if (x > 6)
            {
                y = random.Next(7);
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    BotField[i, x] = 1;
                }
                Number++;
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y - 1; i < y + 4; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }

                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    BotField[i, x] = 1;
                }
                Number++;
            }
            else
            {
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 4; j++)
                    {
                        if (j < 0)
                        {
                            j = 0;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    BotField[y, j] = 1;
                }
                Number++;
            }
        }
        private void Two()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            if (y > 7)
            {
                x = random.Next(8);
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 3; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    BotField[y, j] = 1;
                }
                Number++;
                return;
            }
            if (x > 7)
            {
                y = random.Next(8);
                for (int i = y - 1; i < y + 3; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j > 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    BotField[i, x] = 1;
                }
                Number++;
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y - 1; i < y + 3; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 2; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }

                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    BotField[i, x] = 1;
                }
                Number++;
            }
            else
            {
                for (int i = y - 1; i < y + 2; i++)
                {
                    if (i < 0)
                    {
                        i++;
                    }
                    if (i > 9)
                    {
                        break;
                    }
                    for (int j = x - 1; j < x + 3; j++)
                    {
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (BotField[i, j] != 0)
                        {
                            return;
                        }

                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    BotField[y, j] = 1;
                }
                Number++;
            }
        }
        private void One()
        {
            var random = new Random();
            var x = random.Next(10);
            var y = random.Next(10);
            for (int i = y - 1; i < y + 2; i++)
            {
                if (i < 0)
                {
                    i++;
                }
                if (i > 9)
                {
                    break;
                }
                for (int j = x - 1; j < x + 2; j++)
                {
                    if (j < 0)
                    {
                        j++;
                    }
                    if (j > 9)
                    {
                        break;
                    }
                    if (BotField[i, j] != 0)
                    {
                        return;
                    }
                }
            }
            BotField[y, x] = 1;
            Number++;
        }
    }
}
