using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsClub
{
    class AdminClass
    {
        private const string userName = "Admin";
        private int pass = 123456;

        public string getUsername()
        {
            return userName;
        }

        public int getPass()
        {
            return pass;
        }

        public bool login(string n, int p)
        {
            if (n == userName && p == pass)
                return true;
            return false;
        }
    }
}
