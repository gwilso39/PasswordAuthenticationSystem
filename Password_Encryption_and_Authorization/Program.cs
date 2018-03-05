using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Encryption_and_Authorization
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = false;
            do
            {
                try
                {
                    new UserInterface().PasswordAuthentication();
                    input = true;
                }
                catch
                {
                    Console.WriteLine("Error - please try again... ");
                }
            } while (!input);
        }
    }
}
