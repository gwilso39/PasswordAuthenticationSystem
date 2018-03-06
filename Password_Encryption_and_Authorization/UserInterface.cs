using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Encryption_and_Authorization
{
    class UserInterface
    {
        //Main Menu - calls UserInput and acts on item methods
        public void PasswordAuthentication()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("-----------------------------------------\n");
                Console.WriteLine("Please select one option:\n");
                Console.WriteLine("1. Establish an account");
                Console.WriteLine("2. Authenticate a user");
                Console.WriteLine("3. Exit the system\n");
            }
            while (!(ActOnSelectedItem(UserInput())));
        }

        //Obtains User Input and returns selection 
        public int UserInput()
        {
            var input = false;

            int selection = 0;

            do
            {
                Console.Write(" Make a selection :");

                try
                {
                    selection = int.Parse(Console.ReadLine());
                    if (selection < 4 && selection > 0)
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

        //switch case to determine which method to call based on selection
        private static bool ActOnSelectedItem(int selection)
        {
            var exit = false;

            switch (selection)
            {
                case 1:
                    new Users().EstablishUser();
                    break;
                case 2:
                    new Users().AuthenticateUser();
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

    }

}
