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

        //this method will call the appropriate methods to create a user in the Dictionary
        public void EstablishUser()
        {
            CreateUserName();
            EnterPassword();
            accounts.Add(username, password);

            Console.Clear();
            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("S U C C E S S !\n");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine($"\n Your Account has been Created.  Press enter to continue.");
            Console.ReadLine();
        }

        //this method receives a username and checks it against the dictionary
        //if the username is unique, it will store in username variable for later use
        private void CreateUserName()
        {
            bool valid;
            do
            {
                Console.Clear();
                Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
                Console.WriteLine("Setup New User Account\n");
                Console.WriteLine("-----------------------------------------\n");
                valid = true;
                Console.Write("Enter a user name: ");
                this.username = Console.ReadLine();

                foreach (KeyValuePair<string, string> element in accounts)
                {
                    if (this.username == element.Key)
                    {
                        Console.WriteLine("This User Name is already in use.\n");
                        Console.WriteLine("Press enter to return.");
                        Console.ReadLine();
                        valid = false;
                    }
                    else
                    {
                        username = this.username;
                    };
                };
            } while (valid == !true);
        }
        
        //Method to take in a password with a screen mask
        private void EnterPassword()
        {
            //this section will mask the user's input/store the characters as this.password.
            Console.Write("Please enter a password: ");
            char chr = (char)0;//this declaring chr and casting from integral type as 0 or null
            string maskedPassword = "";
            const int ENTER = 13;
            const int TAB = 9;
            do
            {
                //this reads the key pressed and masks the entry with an *
                //TODO adjust for space hit at end
                chr = Console.ReadKey(true).KeyChar;
                Console.Write("*");
                maskedPassword += chr;
            }
            while ((chr != ENTER) && (chr != TAB));

            //Calling method to convert input password to hash code
            using (MD5 md5Hash = MD5.Create())
            {
                password = GetMd5Hash(md5Hash, maskedPassword);

                //Code used to test if hash was working -from MSDN documentation
                //Console.WriteLine($"\n {maskedPassword}");
                //Console.WriteLine($"\n is really {password}");
                //Console.ReadLine();
                
                //Code used to verify hash is the same (from MDSN)
                //Console.WriteLine("Verifying the hash...");
                //if (VerifyMd5Hash(md5Hash, this.password, hash))
                //{
                //    Console.WriteLine("The hashes are the same.");
                //}
                //else
                //{
                //    Console.WriteLine("The hashes are not same.");
                //}
            }
        }
        
        //Hash creator for password
        public string GetMd5Hash(MD5 md5Hash, string password)
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

        //Code used to test hash
        // Verify a hash against a string.
        //public bool VerifyMd5Hash(MD5 md5Hash, string password, string hash)
        //{
        //    // Hash the input.
        //    string hashOfInput = GetMd5Hash(md5Hash, password);

        //    // Create a StringComparer an compare the hashes.
        //    StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        //    if (0 == comparer.Compare(hashOfInput, hash))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //received user name and password to determine if they match

        public void AuthenticateUser()
        {
            //int attempsAtLogin = 0;

            Console.Clear();
            Console.WriteLine("\nPASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("Authenticate User and Password\n");
            Console.WriteLine("-----------------------------------------\n");

            Console.Write("Enter your user name: ");
            this.username = Console.ReadLine();

            EnterPassword();

            //TODO compare the input username/password combination with that in the 
            //Dictionary and indicate authentication successfull

            foreach (KeyValuePair<string, string> element in accounts)
            {
                if (this.username == element.Key)
                    //TODO found == true...
                    //TODO need to build a portion if username not found (i.e. create one)
                {
                    if (password == element.Value)
                    {
                        //TODO this will be authentication success.
                        //return allow access...
                    }
                    else
                    {
                        //TODO return invalid password, access denied, attempts +1
                    }
                }
            };

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

            //for (int i = 0; i < 3; i++)
            //{
            //    //original call to authentication method here... correct?
            //}
            //if (attempsAtLogin > 2)
            //    Console.WriteLine("You have tried to many times to authenticate.");

            //else
            //{
            //    Console.WriteLine("You have successfully authenticated.");
            //}
            //Console.ReadKey();
        }

    }
}
