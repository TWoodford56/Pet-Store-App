using humans;
using employeeCodes;
using System.Text;
using uiManager;
using icsvmanager;
using hash;

namespace workers
{
    class Workers : Humans, ICSVManager
    {
        //Approved passwords
        public List<EmployeeCodes> passwords = new List<EmployeeCodes>();

        //saves the new employees password
        public string newEmpPassword = string.Empty;

        //Allows a user to log in by checking the password
        public override bool logIn(string name, UIManager u)
        {
            //Initialise attempts variable
            int attempts = 0;
            //Find the employee and their info through their name
            if (passwords.Any(p => p.name == name))
            {
                EmployeeCodes employee = passwords.Find(e => e.name == name);
                //Using the name and employee info get the correct password hash for them
                string passwordHash = employee.password;

                //Continuous loop for 3 attempts
                while (attempts < 3)
                {
                    //Calls a function which gets the password that the user inputs and stores it
                    string userPass = requestPassword();

                    //Checks if the password is correct
                    if (Hash.VerifyPassword(passwordHash, userPass))
                    {
                        //If it is, store that the user is logged in and break the loop
                        loggedIn = true;
                        Console.WriteLine("You are now logged in");
                        break;
                    }
                    else
                    {
                        //if the user reaches 3 attempts without a correct input force quit the program
                        if (attempts == 2)
                        {
                            Console.WriteLine("No valid password provided, Exiting the program");
                            u.closeProgram();
                        }
                        else
                        {
                            //If the password is not correct let them know and increment the counter
                            Console.WriteLine("Incorrect Password");
                            attempts++;
                        }
                    }
                }
            }
            else
            {
                //NO valid name provided
                Console.WriteLine("The name provided is not of an employee");
            }

            //for now return the logged in state
            return loggedIn;
        }

        public override void logOut()
        {
            //Change boolean when employee logs out so they cannot acces employee only things
            loggedIn = false;
        }

        public string requestPassword()
        {
            //Asks the user for a password
            Console.WriteLine("Please input your password");
            string? password;
            while (string.IsNullOrEmpty(password = Console.ReadLine()))
            {
                Console.WriteLine("Invalid input try again");
            }
            //returns it
            return password;
        }

        public override void removeEmployee(string password, string name)
        {
            //Locates the matching employee by name and verifies the password hash before removing it
            passwords.RemoveAll(p => p.name == name && Hash.VerifyPassword(p.password, password));
        }

        public override void addEmployee(string newPassword, string newName)
        {
            //hboolean to help check if the employee already exists
            bool inUse = false;

            //Check reuse against the plaintext password before it gets hashed, since hashes are salted and can't be compared directly
            if (passwords.Any(p => Hash.VerifyPassword(p.password, newPassword)))
            {
                //if the password is already being used print this and turn inUse to true
                Console.WriteLine("Password already in use");
                inUse = true;
            }

            //Creates new employee variable, hashing the password before storing it
            EmployeeCodes newEmp = new EmployeeCodes(newName, Hash.HashPassword(newPassword));
            if (passwords.Any(p => p.name == newEmp.name))
            {
                //if the person is already an employee make inUse true 
                Console.WriteLine("Person is already an employee");
                inUse = true;
            }

            if (!inUse)
            {
                //if the password or name is not already in use add that employee
                passwords.Add(newEmp);
            }
        }

        public void openCSV(string filePath)
        {
            //opens streamreader
            StreamReader reader = null;

            //basic check to see if file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No Valid file found");
            }
            else
            {
                //opens the file 
                using (reader = new StreamReader(File.OpenRead(filePath)))
                {
                    //ensure all lines are read
                    while (!reader.EndOfStream)
                    {
                        //reads each line and splits the name from the password hash
                        //limited to 2 parts since an Argon2 hash itself contains commas
                        var line = reader.ReadLine();
                        var values = line.Split(',', 2);
                        //adds an employee code containing the name of the employee and the password hash to the list of passwords
                        passwords.Add(new EmployeeCodes(values[0], values[1].Trim()));
                    }
                }
            }
        }

        public void writeToCSV(string filepath)
        {
            //starts string builder
            StringBuilder output = new StringBuilder();

            //for each employee and code in passwords
            foreach (EmployeeCodes employee in passwords)
            {
                //append the employeeCodes (name and password)
                output.Append(employee);
                //append a line break
                output.Append("\n");
            }

            //write up to the file path as a string
            File.WriteAllText(filepath, output.ToString());
        }

        public bool checkPassword()
        {
            //valid variable
            bool valid = false;

            //ask for the employee password
            Console.WriteLine("Please Provide the Employee's password");
            string? sPass = Console.ReadLine();

            //if the string is null recursively call until a non null is given
            if (sPass == null)
            {
                Console.WriteLine("Please provide a valid, non null value");
                return checkPassword();
            }
            //passwords are hashed, so no need to restrict to digits only - just enforce a minimum length
            else if (sPass.Length < 10)
            {
                Console.WriteLine("Password does not meet the password requirements:" + "\n" + "The Password must be at least 10 characters long");
                return checkPassword();
            }

            //store the password outside the function to be referenced in other classes (hashed later, on add)
            newEmpPassword = sPass;
            valid = true;

            //return whether or not the password is valid
            return valid;
        }
    }
}