using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User : Battleship
    {
        public User()
        {
            Console.Write("Patahakan ");
            if (Console.ReadLine() == "yes")
            {
                Console.Clear();
                Number = 0;
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
        }

        public void Strike()
        {
            if (Win())
            {
                return;
            }
            Console.SetCursorPosition(30, Indent++);
            Console.WriteLine("Krakoc N: " + ++Step);
            Boolean letter = true;
            while (letter)
            {
                Console.SetCursorPosition(30, Indent++);
                Console.Write("dzer krakocy: ");
                switch (Console.Read())
                {
                    case 'a':
                        Letter[Step] = 0;
                        letter = false;
                        break;
                    case 'b':
                        Letter[Step] = 1;
                        letter = false;
                        break;
                    case 'c':
                        Letter[Step] = 2;
                        letter = false;
                        break;
                    case 'd':
                        Letter[Step] = 3;
                        letter = false;
                        break;
                    case 'e':
                        Letter[Step] = 4;
                        letter = false;
                        break;
                    case 'f':
                        Letter[Step] = 5;
                        letter = false;
                        break;
                    case 'g':
                        Letter[Step] = 6;
                        letter = false;
                        break;
                    case 'h':
                        Letter[Step] = 7;
                        letter = false;
                        break;
                    case 'i':
                        Letter[Step] = 8;
                        letter = false;
                        break;
                    case 'k':
                        Letter[Step] = 9;
                        letter = false;
                        break;
                }
            }
            Index[Step] = Convert.ToInt32(Console.ReadLine()) - 1;
            if (Hit(Index[Step], Letter[Step]))
            {
                Points++;
                Strike();
            }
        }

        public bool Hit(int i, int j)
        {
            if (BotField[i, j] == 0)
            {
                BotField[i, j] = 3;
                Field1[i, j] = 3;
                Output(Field1);
                Console.SetCursorPosition(30, 0);
                Console.Write("Pust!   ");
                return false;
            }
            if (BotField[i, j] == 1)
            {
                BotField[i, j] = 2;
                Field1[i, j] = 2;
                Stroke(BotField, i, j);
                Output(Field1);
                Console.SetCursorPosition(30, 0);
                Console.Write("Dipchec!");
                return true;
            }
            Console.SetCursorPosition(30, 0);
            Console.Write("Chi kareli");
            Console.SetCursorPosition(30, 4);
            Console.WriteLine();
            Step--;
            return true;
        }

        public bool Win()
        {
            if (Points == 20)
            {
                Console.SetCursorPosition(10, 0);
                Console.Write("haxtanak");
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
                    UserField[i, x] = 1;
                }
                return;
            }
            if (y > 5)
            {
                x = random.Next(5);
                for (int j = x; j < x + 4; j++)
                {
                    UserField[y, j] = 1;
                }
                return;
            }
            int k = random.Next(1);
            if (k == 0)
            {
                for (int i = y; i < y + 4; i++)
                {
                    UserField[i, x] = 1;
                }
            }
            else
            {
                for (int j = x; j < x + 4; j++)
                {
                    UserField[y, j] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    UserField[y, j] = 1;
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
                        {
                            if (UserField[i, j] != 0)
                            {
                                return;
                            }
                        }
                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    UserField[i, x] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 3; i++)
                {
                    UserField[i, x] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 3; j++)
                {
                    UserField[y, j] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    UserField[y, j] = 1;
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
                        if (j < 0)
                        {
                            j++;
                        }
                        if (j > 9)
                        {
                            break;
                        }
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    UserField[i, x] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int i = y; i < y + 2; i++)
                {
                    UserField[i, x] = 1;
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
                        if (UserField[i, j] != 0)
                        {
                            return;
                        }
                    }
                }
                for (int j = x; j < x + 2; j++)
                {
                    UserField[y, j] = 1;
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
                    if (UserField[i, j] != 0)
                    {
                        return;
                    }
                }
            }
            UserField[y, x] = 1;
            Number++;
        }
    }
}
