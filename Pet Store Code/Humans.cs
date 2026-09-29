using uiManager;

namespace humans
{
    abstract class Humans
    {
        //Variables for reference within the classes
        public bool loggedIn;
        public bool returning = false;

        //sets out the following functions to be referenced within sub classes
        public virtual bool logIn(string name, UIManager u)
        {
            return loggedIn;
        }

        public virtual void logOut()
        {
            Console.WriteLine("You have logged out");
        }

        public virtual void addEmployee(string password, string name)
        {
            Console.WriteLine("Employee added");
        }

        public virtual void removeEmployee(string password, string name)
        {
            Console.WriteLine("Employee removed");
        }

        public virtual void addCustomer(string name)
        {
            Console.WriteLine("Customer added");
        }

        public virtual void removeCustomer(string name)
        {
            Console.WriteLine("Customer Removed");
        }

        public virtual bool cusLogIn(string name)
        {
            return returning;
        }

    }
}