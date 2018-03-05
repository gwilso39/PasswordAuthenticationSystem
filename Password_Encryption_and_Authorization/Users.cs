using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Encryption_and_Authorization
{
    class Users
    {
        string username;
        string password;

        //Public callable method to acquire username and password
        public void UserPassword()
        {
            GetUserNameAndPassword();
        }

        //Method to read in new username and password
        void GetUserNameAndPassword()
        {
            this.username = Console.ReadLine();
            this.password = Console.ReadLine();
        }

        //method to return false if the username and password exist in the list already
        bool CheckUserNameAndPassword(string username, string password)
        {
            return ((this.username == username) && (this.password == md5sum(password)));
        }
    }
}
