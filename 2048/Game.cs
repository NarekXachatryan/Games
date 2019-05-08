using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Game
    {
        public static int point = 0;
        public static bool status = true;
        public static int num = 2;
        public static int maxLength = 4;
        public bool UpOne;
        public bool DownOne;
        public bool LeftOne;
        public bool RightOne;
        GameZone gameZone = new GameZone();
        public void GameStart()
        {
            while (GameStatus())
            {
                if (status)
                {
                    gameZone.Random(2);
                    gameZone.Random(4);
                }
                status = false;
                int k;
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            DownOne = false;
                            LeftOne = false;
                            RightOne = false;
                            if (UpOne)
                            {
                                if (Up())
                                {
                                    break;
                                }
                            }
                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = gameZone.Zone.GetLength(0) - 2; i >= 0; i--)
                                {
                                    k = i;
                                    while (gameZone.Zone[k + 1, j] == "    " && k < gameZone.Zone.GetLength(0) - 2)
                                    {
                                        gameZone.Zone[k + 1, j] = gameZone.Zone[k, j];
                                        gameZone.Zone[k, j] = "    ";
                                        k++;

                                    }
                                }
                            }

                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = 0; i < gameZone.Zone.GetLength(0) - 1; i++)
                                {
                                    if (gameZone.Zone[i, j] == gameZone.Zone[i + 1, j] && gameZone.Zone[i, j] != "    ")
                                    {
                                        gameZone.Zone[i , j] = (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString() + new string(' ', maxLength - (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString().Length);


                                        point += Convert.ToInt32(gameZone.Zone[i, j]) ;


                                        gameZone.Zone[i+1, j] = "    ";
                                    }
                                }
                            }

                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = 1; i < gameZone.Zone.GetLength(0); i++)
                                {
                                    k = i;
                                    while (k > 0 && gameZone.Zone[k - 1, j] == "    ")
                                    {
                                        gameZone.Zone[k - 1, j] = gameZone.Zone[k, j];
                                        gameZone.Zone[k, j] = "    ";
                                        k--;

                                    }
                                }
                            }
                            UpOne = true;
                            ResizeLength();
                            if (GameStatus())
                            {
                                gameZone.Random(num);
                            }

                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            UpOne = false;
                            LeftOne = false;
                            RightOne = false;
                            if (DownOne)
                            {
                                if (Down())
                                {
                                    break;
                                }
                            }

                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = 1; i < gameZone.Zone.GetLength(0); i++)
                                {
                                    k = i;
                                    while (k > 0 && gameZone.Zone[k - 1, j] == "    ")
                                    {
                                        gameZone.Zone[k - 1, j] = gameZone.Zone[k, j];
                                        gameZone.Zone[k, j] = "    ";
                                        k--;

                                    }
                                }
                            }

                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = gameZone.Zone.GetLength(0) - 1; i > 0; i--)
                                {
                                    if (gameZone.Zone[i, j] == gameZone.Zone[i - 1, j] && gameZone.Zone[i, j] != "    ")
                                    {
                                        gameZone.Zone[i, j] = (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString() + new string(' ', maxLength - (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString().Length);

                                        point += Convert.ToInt32(gameZone.Zone[i, j]) ;

                                        gameZone.Zone[i-1, j] = "    ";

                                    }
                                }
                            }

                            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                            {
                                for (int i = gameZone.Zone.GetLength(0) - 2; i >= 0; i--)
                                {
                                    k = i;
                                    while (k <= gameZone.Zone.GetLength(0) - 2 && gameZone.Zone[k + 1, j] == "    ")
                                    {
                                        gameZone.Zone[k + 1, j] = gameZone.Zone[k, j];
                                        gameZone.Zone[k, j] = "    ";
                                        k++;

                                    }
                                }
                            }
                            DownOne = true;
                            ResizeLength();
                            if (GameStatus())
                            {
                                gameZone.Random(num);
                            }
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            DownOne = false;
                            UpOne = false;
                            RightOne = false;
                            if (LeftOne)
                            {
                                if (Left())
                                {
                                    break;
                                }

                            }

                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = gameZone.Zone.GetLength(1) - 2; j >= 0; j--)
                                {
                                    k = j;
                                    while (k < gameZone.Zone.GetLength(1) - 1 && gameZone.Zone[i, k + 1] == "    ")
                                    {
                                        gameZone.Zone[i, k + 1] = gameZone.Zone[i, k];
                                        gameZone.Zone[i, k] = "    ";
                                        k++;
                                    }

                                }
                            }

                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = 0; j < gameZone.Zone.GetLength(1) - 1; j++)
                                {
                                    if (gameZone.Zone[i, j] == gameZone.Zone[i, j + 1] && gameZone.Zone[i, j] != "    ")
                                    {
                                        gameZone.Zone[i, j] = (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString() + new string(' ', maxLength - (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString().Length);
                                        point += Convert.ToInt32(gameZone.Zone[i, j]);
                                        gameZone.Zone[i, j+1] = "    ";

                                    }

                                }
                            }

                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = 1; j < gameZone.Zone.GetLength(1); j++)
                                {
                                    k = j;
                                    while (k > 0 && gameZone.Zone[i, k - 1] == "    ")
                                    {
                                        gameZone.Zone[i, k - 1] = gameZone.Zone[i, k];
                                        gameZone.Zone[i, k] = "    ";
                                        k--;
                                    }

                                }
                            }
                            LeftOne = true;
                            ResizeLength();
                            if (GameStatus())
                            {
                                gameZone.Random(num);
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {

                            DownOne = false;
                            UpOne = false;
                            LeftOne = false;
                            if (RightOne)
                            {
                                if (Right())
                                {
                                    break;
                                }

                            }
                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = 1; j < gameZone.Zone.GetLength(1); j++)
                                {
                                    k = j;
                                    while (k > 0 && gameZone.Zone[i, k - 1] == "    ")
                                    {
                                        gameZone.Zone[i, k - 1] = gameZone.Zone[i, k];
                                        gameZone.Zone[i, k] = "    ";
                                        k--;
                                    }

                                }
                            }

                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = gameZone.Zone.GetLength(1) - 1; j > 0; j--)
                                {
                                    if (gameZone.Zone[i, j] == gameZone.Zone[i, j - 1] && gameZone.Zone[i, j] != "    ")
                                    {
                                        gameZone.Zone[i, j] = (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString() + new string(' ', maxLength - (Convert.ToInt32(gameZone.Zone[i, j]) * 2).ToString().Length);
                                        point += Convert.ToInt32(gameZone.Zone[i, j]);
                                        gameZone.Zone[i, j-1] = "    ";

                                    }

                                }
                            }

                            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                            {
                                for (int j = gameZone.Zone.GetLength(1) - 2; j >= 0; j--)
                                {
                                    k = j;
                                    while (k < gameZone.Zone.GetLength(1) - 1 && gameZone.Zone[i, k + 1] == "    ")
                                    {
                                        gameZone.Zone[i, k + 1] = gameZone.Zone[i, k];
                                        gameZone.Zone[i, k] = "    ";
                                        k++;
                                    }

                                }
                            }

                            ResizeLength();
                            if (GameStatus())
                            {
                                gameZone.Random(num);
                            }
                            break;

                        }
                }

            }
        }
        public bool Up()
        {
            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
            {
                for (int i = 0; i < gameZone.Zone.GetLength(0) - 1; i++)
                {
                    if ((gameZone.Zone[i, j] == gameZone.Zone[i + 1, j] && gameZone.Zone[i, j] != "    ") || gameZone.Zone[i + 1, j] == "    ")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Down()
        {
            for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
            {
                for (int i = gameZone.Zone.GetLength(0) - 1; i > 0; i--)
                {
                    if ((gameZone.Zone[i, j] == gameZone.Zone[i - 1, j] && gameZone.Zone[i, j] != "    ") || gameZone.Zone[i - 1, j] == "    ")
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool Left()
        {
            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
            {
                for (int j = 0; j < gameZone.Zone.GetLength(1) - 1; j++)
                {
                    if ((gameZone.Zone[i, j] == gameZone.Zone[i, j + 1] && gameZone.Zone[i, j] != "    ") || gameZone.Zone[i, j + 1] == "    ")
                    {
                        return false;
                    }

                }

            }
            return true;
        }

        public bool Right()
        {
            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
            {
                for (int j = gameZone.Zone.GetLength(1) - 1; j > 0; j--)
                {
                    if ((gameZone.Zone[i, j] == gameZone.Zone[i, j - 1] && gameZone.Zone[i, j] != "    ") || gameZone.Zone[i, j - 1] == "    ")
                    {
                        return false;
                    }

                }
            }
            return true;
        }
        public bool GameStatus()
        {
            bool game = true;
            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
            {
                for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                {
                    if (gameZone.Zone[i, j] != "    ")
                    {
                        game = false;
                        break;
                    }

                }
            }
            if (game)
            {
                for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
                {
                    for (int j = 0; j < gameZone.Zone.GetLength(1) - 1; j++)
                    {
                        if (gameZone.Zone[i, j] == gameZone.Zone[i, j + 1])
                        {
                            return true;
                        }
                    }
                }

                for (int i = 0; i < gameZone.Zone.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                    {
                        if (gameZone.Zone[i, j] == gameZone.Zone[i + 1, j])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        public void ResizeLength()
        {
            for (int i = 0; i < gameZone.Zone.GetLength(0); i++)
            {
                for (int j = 0; j < gameZone.Zone.GetLength(1); j++)
                {
                    if (gameZone.Zone[i, j].Length > maxLength)
                    {
                        gameZone.Zone[i, j] = gameZone.Zone[i, j].Substring(0, maxLength);
                    }
                }
            }
        }
    }
}
