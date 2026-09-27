using workers;
using customers;
using pets;
using supplies;
using System.Text;
using ipurchasables;

namespace uiManager
{
    class UIManager
    {
        //Name of person using program
        public string name;

        //Initialise the Lists for later use 
        List<IPurchasables> currentOptions = new List<IPurchasables>();
        List<IPurchasables> basket = new List<IPurchasables>();

        //stores the csv filepath names
        string EmpCodesCSV;
        string customerCSV;

        //list of all purchasable items, update when adding more
        //ensure lowercase
        List<string> allowedValues = new List<string>
        {
            "dog","lizard","cat","enclosure","food","decorations","fish","hamster","health","snake","toys"
        };

        //Initialise references to other classes
        Workers w;
        Customers c;
        Pets pets;
        Supplies supplies;

        //Constructor to help initialise the class references 
        public UIManager(Workers w, Customers c, Pets pets, Supplies supplies, string customerCSV, string EmpCodesCSV)
        {
            this.supplies = supplies;
            this.c = c;
            this.w = w;
            this.pets = pets;
            this.customerCSV = customerCSV;
            this.EmpCodesCSV = EmpCodesCSV;
        }

        //begins running the program
        public void run()
        {
            //Read customer and employee info from CSV files
            //may have to change file path
            w.openCSV(EmpCodesCSV);
            c.openCSV(customerCSV);
            //fill lists of pets and pet supplies
            pets.fill();
            supplies.fill();
            //call welcome screen
            welcomeScreen();
        }

        //closes the program and properly uploads evrything to csv
        public void closeProgram()
        {
            //write updated lists to csv 
            c.writeToCSV(customerCSV);
            w.writeToCSV(EmpCodesCSV);
            Console.WriteLine("Goodbye");
            //close the program
            Environment.Exit(1);
        }

        private void welcomeScreen()
        {
            //initialise variables
            int selection;
            bool validEntry = false;

            //Display screen for user selection
            Console.WriteLine(
            "---------------------------" + "\n" +
            "Welcome to Pet Store: " + "\n" +
            "1. Employee Entry" + "\n" +
            "2. Customer Entry" + "\n" +
            "3. Quit"
            );

            //check validity of entry i.e. ensure it is non null and either 1,2 or 3
            while (!validEntry)
            {
                //while the value is null continuosly request a valid function
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    //tells the user to input valid valur
                    Console.WriteLine("Please ensure a value is entered");
                }

                //depending on the selection of the user choose the following
                switch (selection)
                {
                    case 1:
                        //end the validentry check loop
                        validEntry = true;
                        //call the employeeEntry UI
                        EmployeeEntry();
                        //ends switch
                        break;

                    case 2:
                        //end validentry check loop
                        validEntry = true;
                        //request name of the customer 
                        Console.WriteLine("Please sign in using your name:");
                        //stores the name of the customer once a non null value has been entered
                        while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
                        {
                            Console.WriteLine("Invalid entry, ensure your entry is not null or whitespace");
                            Console.WriteLine("Please sign in using your name:");
                        }
                        //call customer entry UI
                        CustomerEntry();
                        //end switch
                        break;

                    case 3:
                        //Calls the close program to ensure everything is shut correctly 
                        closeProgram();
                        //ends switch statement 
                        break;

                    default:
                        //if the value is not above remind the user of their options
                        Console.WriteLine("Invalid entry, please input either 1,2 or 3");
                        //end switch, no valid entry true so switch will run again
                        break;
                }
            }
        }

        private void EmployeeEntry()
        {
            //Request the name of the user 
            Console.WriteLine("Please sign in using your name:");

            //stores the name once a non null input is provided
            while (string.IsNullOrWhiteSpace(name = Console.ReadLine()))
            {
                Console.WriteLine("Invalid entry, ensure your entry is not null or whitespace");
                Console.WriteLine("Please sign in using your name:");
            }

            //checks if the name provided matches any within the employee codes list 
            if (w.passwords.Any(p => p.name == name))
            {
                //if it does call the login function and allow them to log
                w.logIn(name, this);
                //call employee screen
                EmployeeScreen();
            }
            else
            {
                //if the name is not found remind them of case sensitivity 
                Console.WriteLine("Name not found, Ensure case accuracy e.g. Jane Doe not jane doe");
                //recall the employee entry function to allow them to log in 
                EmployeeEntry();
            }
        }

        private void EmployeeScreen()
        {

            //initialise variables
            bool validEntry = false;
            int selection;

            //display employee screen UI
            Console.WriteLine
            (
                "---------------------------" + "\n" +
                "Welcome " + name + "\n" +
                "What would you like to do:" + "\n" +
                "1. Add Employee" + "\n" +
                "2. Exit"
            );

            //valid entry loop 
            while (!validEntry)
            {
                //requests a non null value 
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Please ensure a value is entered");
                }

                //switch dependant on user input
                switch (selection)
                {
                    case 1:
                        //ends valid entry loop
                        validEntry = true;
                        //calls the addEmpoyeeUI
                        addEmployeeUI();
                        //ends switch
                        break;

                    case 2:
                        //ensures proper program closure
                        closeProgram();
                        //ends switch
                        break;

                    default:
                        //reminds user of the only valid inputs
                        Console.WriteLine("Invalid entry, please input either 1 or 2");
                        //ends switch
                        break;
                }
            }

        }

        private void CustomerEntry()
        {
            //if the customer log in returns true, they have shopped here before
            if (c.cusLogIn(name))
            {
                //welcome them back
                Console.WriteLine(
                "---------------------------" + "\n" +
                "Welcome back " + name);
                //call customer UI
                customerScreen();
            }
            else
            {
                //else welcome them 
                Console.WriteLine(
                "---------------------------" + "\n" +
                "Welcome " + name);
                //add them to the list of customers who have used the program
                c.addCustomer(name);
                //call customer UI
                customerScreen();
            }
        }

        private void customerScreen()
        {
            //Resets the current options list to allow it to be repopulated when the user decides which products to view
            currentOptions.Clear();
            //initialises variables
            bool validEntry = false;
            int selection;

            //customer UI Screen
            Console.WriteLine(
            "What would you like to view: " + "\n" +
            "1. Pets" + "\n" +
            "2. Pet Supplies" + "\n" +
            "3. View Basket" + "\n" +
            "4. Exit"
            );

            //valid entry loop
            while (!validEntry)
            {
                //checks for non null value 
                while (!int.TryParse(Console.ReadLine(), out selection))
                {
                    Console.WriteLine("Please ensure a value is entered");
                }

                //switch dependant on user input 
                switch (selection)
                {
                    case 1:
                        //ends valid entry loop
                        validEntry = true;
                        //call view pets 
                        viewPets();
                        //end switch
                        break;

                    case 2:
                        //ends valid entry loop
                        validEntry = true;
                        //call view supplies
                        viewSupplies();
                        //end switch
                        break;

                    case 3:
                        //ends valid entry loop
                        validEntry = true;
                        //call view basket
                        viewBasket();
                        //end switch
                        break;

                    case 4:
                        //ensure proper program closure
                        closeProgram();
                        //end switch
                        break;

                    default:
                        //remind user of valid options
                        Console.WriteLine("Invalid entry, please input either 1,2,3 or 4");
                        //end switch
                        break;
                }
            }

        }

        public void viewBasket()
        {
            //intitialise variables
            //zero based index adjusted
            int counter = 1;
            int total = 0;
            //for each IPurchasable in the basket 
            foreach (IPurchasables basketOptions in basket)
            {
                //display a number, the type (e.g. Dog, Cat), the breed and the price
                Console.WriteLine(counter + ". " + basketOptions.GetType().Name + ", Breed: " + basketOptions.relatedAnimalorBreed + ", Price: £" + basketOptions.price);
                //calulate the total price of the basket 
                total += basketOptions.price;
                //increment the counter
                counter++;
            }
            //print the basket total 
            Console.WriteLine("Your Total is £" + total);
            //give them the option to proceed
            Console.WriteLine("Would you like to proceed y/n");
            //store the answer once it is a valid input
            string answer;
            while (string.IsNullOrWhiteSpace(answer = Console.ReadLine()))
            {
                Console.WriteLine("Invalid input try again");
            }
            if (answer.Equals("y"))
            {
                // if the user wishes to proceed, finish the purchas
                Console.WriteLine("Congratulations on your purchase, please come back soon");
                buy();

            }
            if (answer.Equals("n"))
            {
                //tell them the sale has been aborted
                Console.WriteLine("This sale has been aborted");
                //recall the customerScreen
                customerScreen();
            }


        }

        public void buy()
        {
            //go thorugh the list and see whether each option is a pet or supply and remove from the main list 
            foreach (IPurchasables option in basket.ToList())
            {
                if (option.GetType().BaseType.Name == "Supplies")
                {
                    supplies.suppliesList.Remove(option);
                }
                else if (option.GetType().BaseType.Name == "Pets")
                {
                    pets.petsList.Remove(option);
                }
                else
                {
                    Console.WriteLine("Error");
                }
                basket.Remove(option);
            }
            customerScreen();
        }

        public void viewPets()
        {
            //validate list of unique strings
            List<string> uniqueList = new List<string>();
            //initialise zero adjusted counter
            int counter = 1;
            //initialise string builder 
            StringBuilder possiblePets = new StringBuilder();
            //for each pets in the list of pets
            foreach (Pets pet in pets.petsList)
            {
                //get the pet type e.g, dog or cat in the type string 
                string petType = pet.GetType().Name;
                //if that type is not already in uniqueList add it 
                if (!uniqueList.Contains(petType))
                {
                    uniqueList.Add(petType);
                }
            }

            //then iterate through the uniqueList
            foreach (string unique in uniqueList)
            {
                //append each string to the string builder along side the counter
                possiblePets.Append(counter + ". " + unique + "\n");
                //increment the counter
                counter++;
            }

            //print the UI and the stringbuilder 
            Console.WriteLine("---------------------------" + "\n" + "Pets available:");
            Console.WriteLine(possiblePets);
            //ask which type of animal they would like to view
            Console.WriteLine("Please input the name of the animal you would like to view");

            //store the name of the type of pet the user would like to view when it is non null
            string petName;
            while (string.IsNullOrWhiteSpace(petName = Console.ReadLine().ToLower()))
            {
                Console.WriteLine("Invalid entry, ensure your entry is not null or whitespace");
                Console.WriteLine("Please input the name of the animal you would like to view");
            }

            //check if the petName -> pet or supplies name is valid
            if (allowedValues.Contains(petName))
            {
                //call viewSpecificPet with the parameter of the user decided pet type 
                viewSpecificPet(petName);
            }
            else
            {
                viewPets();
            }
        }

        public void viewSpecificPet(string petName)
        {
            //initialise counter
            int counter = 1;
            //display pet options UI
            Console.WriteLine("---------------------------");
            Console.WriteLine("These are our available " + petName + "'s:");
            //for every pet in pets list
            foreach (Pets petType in pets.petsList)
            {
                //check if the pet type matches the user decided pet type and that the pet is purchasable 
                if (petType.GetType().Name.ToLower() == petName.ToLower() && petType.purchasable)
                {
                    //add that pet to currentOptions
                    currentOptions.Add(petType);
                    //display info of that pet
                    Console.WriteLine(counter + ". " + "Unit #" + counter  + " Price: £" + petType.price + ", Breed: " + petType.relatedAnimalorBreed);
                    //increment counter
                    counter++;
                }
            }

            //offer an exit option
            Console.WriteLine(counter + ". Exit");
            //ask if the user wants to add any to basket 
            Console.WriteLine("Would you like to add any of these to your basket?");
            Console.WriteLine("If so, please provide the unit #");
            //store selection variable once valid
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Please ensure a valid input is provided and that the unit number is correct");
            }
            //if exit is selected reset to view pets
            if(selection == counter)
            {
                currentOptions.Clear();
                viewPets();
            }
            //add the selection to basket through the addtoBasket method 
            addToBasket(selection);
        }

        public void addToBasket(int selection)
        {
            //add the user selection adjusted to zero based index to the basket list 
            basket.Add(currentOptions[selection - 1]);
            //call the customer screen
            customerScreen();
        }

        public void viewSupplies()
        {
            //intialise list strings of uniqueList
            List<string> uniqueList = new List<string>();
            //initialise counter variable 
            int counter = 1;
            //intialise string builder 
            StringBuilder possibleSupplies = new StringBuilder();
            //for each supply in the supplies list 
            foreach (Supplies supply1 in supplies.suppliesList)
            {
                //get the name stored as a string 
                string supplyType = supply1.GetType().Name;
                //check if the type is already in the list 
                if (!uniqueList.Contains(supplyType))
                {
                    //if not add it 
                    uniqueList.Add(supplyType);
                }
            }

            //for each string inuniqueList
            foreach (string unique in uniqueList)
            {
                //append the counter and name to the string builder 
                possibleSupplies.Append(counter + ". " + unique + "\n");
                //increment the counter
                counter++;
            }

            //supplies available UI using string builder
            Console.WriteLine("---------------------------" + "\n" + "Supplies available:");
            Console.WriteLine(possibleSupplies);
            //ask what the user wants to view
            Console.WriteLine("Please input the name of the supplies you would like to view");
            //gets the user response once it is non null
            string supplyName;
            while (string.IsNullOrWhiteSpace(supplyName = Console.ReadLine()))
            {
                Console.WriteLine("Invalid entry, ensure your entry is not null or whitespace");
                Console.WriteLine("Please input the name of the supplies you would like to view");
            }

            //calls view specific supplies, passing the user input as a parameter 
            viewSpecificSupplies(supplyName);
        }

        public void viewSpecificSupplies(string supplyName)
        {
            int counter = 1;
            Console.WriteLine("---------------------------");
            Console.WriteLine("These are our available " + supplyName + "'s:");
            foreach (Supplies supplyType in supplies.suppliesList)
            {
                if (supplyType.GetType().Name.ToLower() == supplyName.ToLower() && supplyType.purchasable)
                {
                    currentOptions.Add(supplyType);
                    Console.WriteLine("Unit # " + counter + ". " + "Price: £" + supplyType.price + ", Related Animal: " + supplyType.relatedAnimalorBreed);
                    counter++;
                }
            }

            Console.WriteLine("Would you like to add any of these to your basket?");
            Console.WriteLine("If so, please provide the unit #");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Please ensure a valid input is provided and that the unit number is correct");
            }
            addToBasket(selection);
        }

        private void addEmployeeUI()
        {
            //initialise variables
            string newName;
            string newPassword;
            //display UI
            Console.WriteLine("----------------");
            Console.WriteLine("Please provide the name of the employee");
            //While the name is invalid keep asking for a valid input
            while (string.IsNullOrEmpty(newName = Console.ReadLine()))
            {
                Console.WriteLine("Invalid input, please provide a valid input");
            }
            //Call check password to get the user to input a valid password and that password is then stored within the workers class
            w.checkPassword();
            //assign the valid password to newPassword
            newPassword = w.newEmpPassword;
            //final checks for the user
            Console.WriteLine("Are you happy with the following information for the new employee y/n");
            Console.WriteLine("Name: " + newName + "\n" + "Password: " + newPassword);
            if (Console.ReadLine() == "y")
            {
                //add the employee
                w.addEmployee(newPassword, newName);
                //return to employee screen
                EmployeeScreen();
            }
            else
            {
                //if the user is not happy recall the function
                addEmployeeUI();
            }

        }
    }
}