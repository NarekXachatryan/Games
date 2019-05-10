using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting
{
    [Serializable]
    public class User
    {
        public string name;
        public string surname;
        public string login;
        public string password;
        public int money;
        public string history;
        public User(string name, string surname, string login, string password)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
            this.money = 1000;
            this.history = " ";
        }
        public User()
        {
                
        }
    }
}
