using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Password_Encryption_and_Authorization
{
    class Users
    {
        string username;
        string password;

        Dictionary<string, string> accounts = new Dictionary<string, string>();

        //Method to read in new username and password
        public void GetUserNameAndPassword()
        {

            this.username = Console.ReadLine();

            //this will mask the user's input and store the characters as this.password.
            Console.Write("Please enter a password: ");
            char chr = (char)0;
            string maskedPassword = "";
            const int ENTER = 13;
            do
            {
                chr = Console.ReadKey(true).KeyChar;
                Console.Write("*");
                maskedPassword += chr;
            } while (chr != ENTER);

            this.password = maskedPassword;

            
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, this.password);

                Console.WriteLine("The MD5 hash of " + this.password + " is: " + hash + ".");

                //inserted here because the order of the previous readline outputs wrong...
                Console.ReadLine();




                Console.WriteLine("Verifying the hash...");

                if (VerifyMd5Hash(md5Hash, this.password, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }
        }



        static string GetMd5Hash(MD5 md5Hash, string password)
        {
            // Convert the password string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        
        
        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string password, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, password);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        //received user name and password to determine if they match
        public void AuthenticateUser()
        {
            int attempsAtLogin = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("Authenticate User and Password\n");
                Console.WriteLine("-----------------------------------------\n");
                Console.Write("Enter your user name: ");
                string typedUserName = Console.ReadLine();

                //foreach (string checkedUserName in inputUserName)
                //{
                //    if (typedUserName == checkedUserName)
                //    {
                //        Console.Write("Enter your password: ");
                //        string typedPassword = Console.ReadLine();

                //        foreach (string checkedPassword in inputPassword)
                //        {
                //            if (typedPassword == checkedPassword)
                //            {
                //                Console.WriteLine("Authentication Successful");
                //                Console.ReadKey();
                //            }
                //            else
                //            {
                //                Console.WriteLine("Invalid Password");
                //                attempsAtLogin++;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Console.WriteLine("Invalid User Name");
                //    }

                //}
            }
            if (attempsAtLogin > 2)
                Console.WriteLine("You have failed to authenticate.");
            else
            {
                Console.WriteLine("You have successfully authenticated.");
            }
            Console.ReadKey();
        }

        public void EstablishUser()
        {
            //inputUserName.Add("username");
            Console.Clear();
            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("Setup New User Account\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.Write("Enter a user name: ");

            GetUserNameAndPassword();


            //foreach (val checkUserName in accounts)
            //{
            //    if (checkUserName == typedUserName)
            //    {
            //        Console.WriteLine("This User Name is already in use.\n");
            //        Console.WriteLine("Press enter to return.");
            //        Console.ReadKey();
            //    }
            //    else
            //    {
            //        inputUserName.Add(Console.ReadLine());
            //        EstablishPassword();
            //    }
            //}
        }
    }
}
