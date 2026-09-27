using System.Text;
using humans;
using icsvmanager;

namespace customers
{
    class Customers : Humans, ICSVManager
    {
        //variable to store info about whether or not the customer has shopped here before
        public bool returning;

        //Fills list of customers to allow editing into the main database
        public List<string> customerList = new List<string>();

        public override bool cusLogIn(string name)
        {
            //if the customer name matches one in the list returning = true
            if (customerList.Contains(name))
            {
                returning = true;
            }
            //return whether or not the customer has shopped here before
            return returning;
        }

        public override void logOut()
        {
            //returning = false
            returning = false;
        }

        public override void addCustomer(string name)
        {
            //if the customers name is not already in the list 
            if (!customerList.Contains(name))
            {
                //add the name 
                customerList.Add(name);
            }
            else
            {
                //else let them know they are already a customer
                Console.WriteLine(name + " is already a customer");
            }
        }

        public override void removeCustomer(string name)
        {
            //if the name can be found
            if (customerList.Contains(name))
            {
                //remove that customer
                customerList.Remove(name);
            }
            else
            {
                //else let them know that there is no customer by that name
                Console.WriteLine("No customer found with the name: " + name);
            }

        }

        public void openCSV(string filePath)
        {
            //opens a streamreader to allow us to read the excel file
            StreamReader reader = null;

            //basic check to see if file exists with the given file path
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
                        //reads and adds the customer names to the customerList
                        var line = reader.ReadLine();
                        customerList.Add(line);
                    }
                }
            }
        }

        public void writeToCSV(string filepath)
        {
            //intialises string ubuilder
            StringBuilder output = new StringBuilder();

            //for each customer in the list 
            foreach (string customer in customerList)
            {
                //append customer and line break 
                output.Append(customer);
                output.Append("\n");
            }

            //write out the string builder which seperates each name by line
            File.WriteAllText(filepath, output.ToString());
        }
    }
}