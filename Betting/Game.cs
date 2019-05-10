using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Betting.Execptions;
namespace Betting
{
    [Serializable]
    public class Game
    {
        User[] users = new User[0];
        XmlSerializer formatter = new XmlSerializer(typeof(User[]));

        public void Menu()
        {
            try
            {
                DeSerialiation();

            }
            catch
            {

            }
            Console.WriteLine("              ╔══════════════╗");
            Console.WriteLine("              ║  1. Sign in  ║");
            Console.WriteLine("              ╚══════════════╝");
            Console.WriteLine("              ╔══════════════╗");
            Console.WriteLine("              ║  2. Sign up  ║");
            Console.WriteLine("              ╚══════════════╝");
            
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                try
                {
                    DeSerialiation();

                }
                catch
                {

                }
                Console.Clear();
                Console.WriteLine("              ╔══════════════╗");
                Console.WriteLine("              ║     Login    ║");
                Console.WriteLine("              ╚══════════════╝");
                string login = Console.ReadLine();
                Console.WriteLine("              ╔══════════════╗");
                Console.WriteLine("              ║   Password   ║");
                Console.WriteLine("              ╚══════════════╝");
                string password = Console.ReadLine();
                CheckUp(login, password);
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                SingUp();

            }
        }
        public void CheckUp(string login, string password)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].login == login)
                {
                    if (users[i].password == password)
                    {
                        SingIn(i);
                        break;
                    }
                }
            }
        }
        public void SingUp()
        {

            Console.WriteLine("       ╔══════════════╗");
            Console.WriteLine("       ║  Your name   ║");
            Console.WriteLine("       ╚══════════════╝");
            
            string name = Console.ReadLine();
            Console.WriteLine("       ╔══════════════╗");
            Console.WriteLine("       ║ Your surname ║");
            Console.WriteLine("       ╚══════════════╝");

            
            string surname = Console.ReadLine();
            Console.WriteLine("       ╔══════════════╗");
            Console.WriteLine("       ║  Your login  ║");
            Console.WriteLine("       ╚══════════════╝");
            string login = Console.ReadLine();
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].login == login)
                {
                    Console.Clear();
                    Console.WriteLine("       ╔═══════════════╗");
                    Console.WriteLine("       ║  ║");
                    Console.WriteLine("       ╚═══════════════╝");
                    SingUp();
                    break;
                }

            }
            Console.WriteLine("       ╔═══════════════╗");
            Console.WriteLine("       ║ Your password ║");
            Console.WriteLine("       ╚═══════════════╝");
            
            string password = Console.ReadLine();
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User(name, surname, login, password);
            Serialiation();
            Console.Clear();
            Menu();

        }

        public void SingIn(int i)
        {
            Console.Clear();
            Console.WriteLine("              ╔═════════════════════════════════════╗");
            Console.WriteLine("              ║Your balance "  +  users[i].money+" $║");
            Console.WriteLine("              ╚═════════════════════════════════════╝");
          
            GameMenu(i);
        }
        public void DeSerialiation()
        {
            using (FileStream filestrem = new FileStream("Users.xml", FileMode.Open, FileAccess.Read))
            {
                users = (User[])formatter.Deserialize(filestrem);
            }
        }
        public void Serialiation()
        {
            try
            {
                using (FileStream filestrem = new FileStream("Users.xml", FileMode.Truncate, FileAccess.Write))
                {
                    formatter.Serialize(filestrem, users);
                }
            }
            catch
            {
                using (FileStream filestrem = new FileStream("Users.xml", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    formatter.Serialize(filestrem, users);
                }
            }
        }
        public void GameMenu(int i)
        {
            Console.Clear();
            
            
            
          
            Console.WriteLine();
            Console.WriteLine("              ╔═══════════════╗");
            Console.WriteLine("              ║   1. Start    ║");
            Console.WriteLine("              ╚═══════════════╝");
            Console.WriteLine("              ╔═══════════════╗");
            Console.WriteLine("              ║ 2. My history ║");
            Console.WriteLine("              ╚═══════════════╝");
            
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                if (users[i].money > 0)
                {
                    Console.Clear();
                    Rate(i);
                    Continue(i);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No Money");
                }

            }
            else if(key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Console.WriteLine(users[i].history);
                Continue(i);
            }
           
        }
        public void Rate(int i)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Your bid" + "(1-" + users[i].money + "$)");
            int rate = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (rate <= users[i].money && rate > 0)
                {
                    users[i].money = users[i].money - rate;
                }
                else
                {
                    Console.Clear();
                    throw new NoMoney("You don't have so much money");

                }

            }
            catch (NoMoney e)
            {
                Console.WriteLine(e.messige);
                Rate(i);
            }
            Number(i, rate);
        }
        public void Number(int i, int rate)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("You want to put money on the number (1-6) ?");
            int number = Convert.ToInt32(Console.ReadLine());
            try
            {
               

                if (number > 0 && number < 7)
                {

                }

                else
                {
                    Console.Clear();
                    throw new _1_6("You did not choose number 1-6 diapason");
                }

            }
            catch (_1_6 e)
            {
                Console.WriteLine(e.messige);
                Number(i, rate);
            }
            if (number == Random())
            {
                Win(i, rate);
            }
            else
            {
                Console.WriteLine("You Lose "+rate +" $");
                users[i].history += "You Lose " + rate + " $"+"\n";
            }

            Serialiation();
            Continue(i);

        }
        public int Random()
        {
            Random rand = new Random();
            int n = rand.Next(1, 7);
            return n;
        }
        public void Win(int i, int rate)
        {
            Console.WriteLine("You Win " + rate +" $" );
            users[i].history += "You win  " + rate+" $"+"\n";
            users[i].money = users[i].money + 2 * rate;
        }

        public void Continue(int i)
        {
            Console.WriteLine("Continue?");
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No. Exit.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                Console.Clear();
                GameMenu(i);
            }
            else if(key.Key == ConsoleKey.D2)
            {
                Console.Clear();
                Menu();
            }
        }
    }
}
