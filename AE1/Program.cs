using customers;
using pets;
using supplies;
using uiManager;
using workers;
using hash;

namespace program
{
    class Program
    {
        public static void Main(string[] args)
        {
            string customerCSV = Path.Combine(AppContext.BaseDirectory, "Customers.csv");
            string EmpCodesCSV = Path.Combine(AppContext.BaseDirectory, "EmployeeCodes.csv");
            //Pass the class references and begin the program with ui.run()
            UIManager ui = new UIManager(new Workers(), new Customers(), new Pets(),new Supplies(),customerCSV,EmpCodesCSV);
            ui.run();
        }
    }
}