namespace employeeCodes
{
    public class EmployeeCodes
    {
        //intialise following variables for the employee
        public string name;
        public string password;

        //constructor to help store those names
        public EmployeeCodes(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public override string ToString()
        {
            return $"{name}, {password}";
        }
    }
}