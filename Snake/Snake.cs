using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace Narek
{
    delegate void Click(ConsoleKeyInfo key);
    class Snake
    {
        private static int point = 0;
        Random rand = new Random();
        public char head;
        public Snake()
        {
            cords = new List<Cord>();
            cords.Add(new Cord(15, 14, '◄'));
            for (int i = 0; i < 3; i++)
            {
                cords.Add(new Cord(15, 15 + i, '■'));
            }

        }
        Playground playground = new Playground(30, 60);
        public List<Cord> cords;
        public void Ground()
        {
            int i = 0;
            int j = 0;
            playground.graund[0, 0] = '╔';
            playground.graund[0, playground.graund.GetLength(1) - 1] = '╗';
            playground.graund[playground.graund.GetLength(0) - 1, 0] = '╚';
            playground.graund[playground.graund.GetLength(0) - 1, playground.graund.GetLength(1) - 1] = '╝';
            for (i = 1; i < playground.graund.GetLength(0) - 1; i++)
            {
                j = 0;
                playground.graund[i, j] = '║';
                j = playground.graund.GetLength(1) - 1;
                playground.graund[i, j] = '║';
            }
            for (j = 1; j < playground.graund.GetLength(1) - 1; j++)
            {
                i = 0;
                playground.graund[i, j] = '═';
                i = playground.graund.GetLength(0) - 1;
                playground.graund[i, j] = '═';
            }
            for (i = 1; i < playground.graund.GetLength(0) - 1; i++)
            {
                for (j = 1; j < playground.graund.GetLength(1) - 1; j++)
                {
                    playground.graund[i, j] = ' ';
                }
            }
            PrintGround();
        }
        public void PrintGround()
        {
            Thread.Sleep(200);
            Console.Clear();

            for (int i = 0; i < cords.Count; i++)
            {
                playground.graund[cords[i].X, cords[i].Y] = cords[i].Tail;
            }
            for (int i = 0; i < playground.graund.GetLength(0); i++)
            {
                for (int j = 0; j < playground.graund.GetLength(1); j++)
                {
                    Console.Write(playground.graund[i, j]);
                }
                Console.WriteLine();
            }
            Point();
            Console.SetCursorPosition(30, 30);
            Console.WriteLine($"Point : {point}");

        }
        bool GameStatus = true;
        bool up = false;
        bool down = false;
        bool left = false;
        bool right = true;
        Thread thread;
        public  void Move()
        {
            Move: { }
            thread = new Thread(new ParameterizedThreadStart(WhileClick));
            
            while (GameStatus)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (!GameStatus)
                {
                    Console.Clear();
                    break;
                }
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (up == false)
                            {
                                up = true;
                                down = true;
                                left = false;
                                right = false;
                                thread.Start(key);
                            }
                            goto Move;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (down == false)
                            {
                                down = true;
                                up = true;
                                left = false;
                                right = false;
                                thread.Start(key);
                            }
                            goto Move;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (left == false)
                            {
                                left = true;
                                up = false;
                                down = false;
                                right = true;
                                thread.Start(key);
                            }
                            goto Move;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (right == false)
                            {
                                right = true;
                                up = false;
                                down = false;
                                left = true;
                                thread.Start(key);
                            }
                            goto Move;
                        }

                }
                break;
            }
            Console.Clear();
        }
        public void WhileClick(object key1)
        {
            ConsoleKeyInfo key = (ConsoleKeyInfo)key1;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        while (up)
                        {
                            head = '▲';
                            if (cords[0].X - 1 != 0)
                            {
                                int i;
                                int x = cords[cords.Count - 1].X;
                                int y = cords[cords.Count - 1].Y;
                                Console.SetCursorPosition(cords[0].Y, cords[0].X);
                                Console.Write(cords[cords.Count - 1].Tail);
                                Console.SetCursorPosition(cords[0].Y, cords[0].X - 1);
                                Console.Write(head);
                                Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                Console.Write(' ');
                                playground.graund[cords[cords.Count - 1].X, cords[cords.Count - 1].Y] = ' ';
                                for (i = cords.Count - 1; i >= 1; i--)
                                {
                                    cords[i].X = cords[i - 1].X;
                                    cords[i].Y = cords[i - 1].Y;
                                }
                                cords[0].X--;
                                if (cords[0].X == PointX && cords[0].Y == PointY)
                                {
                                    point += 25;
                                    cords.Add(new Cord(x, y, '■'));
                                    Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                    Console.Write('■');
                                    Point();
                                    Console.SetCursorPosition(30, 30);
                                    Console.WriteLine($"Point : {point}");
                                }
                                Thread.Sleep(200);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Game Over");
                                break;
                            }
                            for (int i = 1; i < cords.Count; i++)
                            {
                                if (cords[i].X == cords[0].X && cords[i].Y == cords[0].Y)
                                {
                                    GameStatus = false;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {

                        head = '▼';
                        while (down)
                        {
                            if (cords[0].X + 1 != playground.graund.GetLength(0) - 1)
                            {
                                int i;
                                int x = cords[cords.Count - 1].X;
                                int y = cords[cords.Count - 1].Y;
                                Console.SetCursorPosition(cords[0].Y, cords[0].X);
                                Console.Write(cords[cords.Count - 1].Tail);
                                Console.SetCursorPosition(cords[0].Y, cords[0].X + 1);
                                Console.Write(head);
                                Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                Console.Write(' ');
                                playground.graund[cords[cords.Count - 1].X, cords[cords.Count - 1].Y] = ' ';
                                for (i = cords.Count - 1; i >= 1; i--)
                                {
                                    cords[i].X = cords[i - 1].X;
                                    cords[i].Y = cords[i - 1].Y;
                                }
                                cords[0].X++;
                                if (cords[0].X == PointX && cords[0].Y == PointY)
                                {
                                    point += 25;
                                    cords.Add(new Cord(x, y, '■'));
                                    Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                    Console.Write('■');
                                    Point();
                                    Console.SetCursorPosition(30, 30);
                                    Console.WriteLine($"Point : {point}");
                                }
                                Thread.Sleep(200);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Game Over");
                                break;
                            }
                            for (int i = 1; i < cords.Count; i++)
                            {
                                if (cords[i].X == cords[0].X && cords[i].Y == cords[0].Y)
                                {
                                    GameStatus = false;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        head = '◄';


                        while (left)
                        {
                            if (cords[0].Y - 1 != 0)
                            {
                                int i;
                                int x = cords[cords.Count - 1].X;
                                int y = cords[cords.Count - 1].Y;
                                Console.SetCursorPosition(cords[0].Y, cords[0].X);
                                Console.Write(cords[cords.Count - 1].Tail);
                                Console.SetCursorPosition(cords[0].Y - 1, cords[0].X);
                                Console.Write(head);
                                Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                Console.Write(' ');
                                playground.graund[cords[cords.Count - 1].X, cords[cords.Count - 1].Y] = ' ';
                                for (i = cords.Count - 1; i >= 1; i--)
                                {
                                    cords[i].X = cords[i - 1].X;
                                    cords[i].Y = cords[i - 1].Y;
                                }
                                cords[0].Y--;
                                if (cords[0].X == PointX && cords[0].Y == PointY)
                                {
                                    point += 25;
                                    cords.Add(new Cord(x, y, '■'));
                                    Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                    Console.Write('■');
                                    Point();
                                    Console.SetCursorPosition(30, 30);
                                    Console.WriteLine($"Point : {point}");
                                }
                                Thread.Sleep(200);

                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Game Over");
                                break;
                            }
                            for (int i = 1; i < cords.Count; i++)
                            {
                                if (cords[i].X == cords[0].X && cords[i].Y == cords[0].Y)
                                {
                                    GameStatus = false;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {

                        head = '►';
                        int x = cords[cords.Count - 1].X;
                        int y = cords[cords.Count - 1].Y;

                        while (right)
                        {
                            if (cords[0].Y + 1 != playground.graund.GetLength(1) - 1)
                            {
                                int i;
                                Console.SetCursorPosition(cords[0].Y, cords[0].X);
                                Console.Write(cords[cords.Count - 1].Tail);
                                Console.SetCursorPosition(cords[0].Y + 1, cords[0].X);
                                Console.Write(head);
                                Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                Console.Write(' ');
                                playground.graund[cords[cords.Count - 1].X, cords[cords.Count - 1].Y] = ' ';
                                for (i = cords.Count - 1; i >= 1; i--)
                                {
                                    cords[i].X = cords[i - 1].X;
                                    cords[i].Y = cords[i - 1].Y;
                                }
                                cords[0].Y++;
                                if (cords[0].X == PointX && cords[0].Y == PointY)
                                {
                                    point += 25;
                                    cords.Add(new Cord(x, y, '■'));
                                    Console.SetCursorPosition(cords[cords.Count - 1].Y, cords[cords.Count - 1].X);
                                    Console.Write('■');
                                    Point();
                                    Console.SetCursorPosition(30, 30);
                                    Console.WriteLine($"Point : {point}");
                                }
                                Thread.Sleep(200);
                            }

                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Game Over");
                                break;
                            }
                            for (int i = 1; i < cords.Count; i++)
                            {
                                if (cords[i].X == cords[0].X && cords[i].Y == cords[0].Y)
                                {
                                    GameStatus = false;
                                    break;
                                }
                            }
                        }
                        break;
                    }

            }

        }

        static int PointX;
        static int PointY;
        public void Point()
        {
            PointX = rand.Next(1, playground.graund.GetLength(0) - 1);
            PointY = rand.Next(1, playground.graund.GetLength(1) - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(PointY, PointX);
            Console.Write('*');
        }
    }
}
