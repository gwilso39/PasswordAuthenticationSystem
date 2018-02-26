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
                    PasswordAuthentication();
                    input = true;
                }
                catch
                {
                    Console.WriteLine("Error - please try again... ");
                }
            } while (!input);
        }

        private static void PasswordAuthentication()
        {

            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Please select one option:\n");
            Console.WriteLine("1. Establish an account");
            Console.WriteLine("2. Authenticate a user");
            Console.WriteLine("3. Exit the system\n");
            UserInput();
        }

        public static int UserInput()
        {
            var input = false;

            int selection = 0;

            do
            {
                Console.Write(" Make a selection :");

                try
                {
                    selection = int.Parse(Console.ReadLine());
                    if (selection < 4 && selection >0)
                    {
                        input = true;
                    }
                    else
                    {
                        Console.WriteLine("Enter selection between 1 and 3. Try again.\n");
                    }
                    
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid selection, Try again!");
                }
            } while (!input);

            return selection;

        }

        private bool ActOnSelectedItem(int selection)
        {
            var exit = false;

            switch (selection)
            {
                case 1:
                    EstablishAccount();
                    break;
                case 2:
                    AuthenticateUser();
                    break;
                case 3:
                    exit = true;
                    break;
                default:
                    exit = true;
                    break;
            }
            return exit;
        }

        private void AuthenticateUser()
        {
            throw new NotImplementedException();
        }

        private void EstablishAccount()
        {
            Console.Clear();
            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("Setup New User Account\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.Write("Enter a user name: ");
            Console.WriteLine("1. Establish an account");
            Console.WriteLine("2. Authenticate a user");
            Console.WriteLine("3. Exit the system\n");
        }
    }
}
