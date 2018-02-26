using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Encryption_and_Authorization
{
    class Program
    {

        public static List<string> inputUserName = new List<string>();
        public static List<string> inputPassword = new List<string>();

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

        //Main Menu - calls UserInput and acts on item methods
        private static void PasswordAuthentication()
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

        //switch case to determine which method to call based on selection
        private static bool ActOnSelectedItem(int selection)
        {
            var exit = false;

            switch (selection)
            {
                case 1:
                    EstablishUser();
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

        //TODO - check pw against data structure
        private static void AuthenticateUser()
        {
            int attempsAtLogin = 0;

            for (int i = 0; i<3; i++)
            {
                Console.Clear();
                Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("Authenticate User and Password\n");
                Console.WriteLine("-----------------------------------------\n");
                Console.Write("Enter your user name: ");
                string typedUserName = Console.ReadLine();

                foreach (string checkedUserName in inputUserName)
                {
                    if (typedUserName == checkedUserName)
                    {
                        Console.Write("Enter your password: ");
                        string typedPassword = Console.ReadLine();

                        foreach (string checkedPassword in inputPassword)
                        {
                            if (typedPassword == checkedPassword)
                            {
                                Console.WriteLine("Authentication Successful");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Invalid Password");
                                attempsAtLogin++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid User Name");
                    }

                }
            }
            if (attempsAtLogin > 2)
                Console.WriteLine("You have failed to authenticate.");
            else
            {
                Console.WriteLine("You have successfully authenticated.");
            }
            Console.ReadKey();
        }

        private static void EstablishUser()
        {
            Console.Clear();
            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("Setup New User Account\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.Write("Enter a user name: ");
            string typedUserName = (Console.ReadLine());

            foreach (string checkUserName in inputUserName)
            {
                if (checkUserName == typedUserName)
                {
                    Console.WriteLine("This User Name is already in use.\n");
                    Console.WriteLine("Press enter to return.");
                    Console.ReadKey();
                }
                else
                {
                    inputUserName.Add(Console.ReadLine());
                }
            }
            EstablishPassword();
        }

        //Add encryption of some kind here
        private static void EstablishPassword()
        {
            Console.Write("Enter a password: ");
            inputPassword.Add (Console.ReadLine());
            Console.WriteLine("Password Saved");
            Console.ReadKey();
        }
    }
}
