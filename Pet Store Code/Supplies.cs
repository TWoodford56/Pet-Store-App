using enclosure;
using food;
using ipurchasables;
using health;
using toys;
using decorations;

namespace supplies
{
    public class Supplies : IPurchasables
    {
        //intialises variables inherited from IPUrchasables
        public int price { get; protected set; }
        public bool purchasable { get; protected set; }
        public string relatedAnimalorBreed { get; protected set; }

        //creates list of supplies
        public List<IPurchasables> suppliesList = new List<IPurchasables>();

        //gets the price of the Supplies
        public int getPrice()
        {
            return price;
        }

        //fills the list of supplies
        public void fill()
        {
            suppliesList.Add(new Enclosure(100, "Dog", true));
            suppliesList.Add(new Enclosure(20, "Cat", true));
            suppliesList.Add(new Enclosure(40, "Dog", true));
            suppliesList.Add(new Enclosure(60, "Snake", true));
            suppliesList.Add(new Enclosure(40, "Fish", true));
            suppliesList.Add(new Food(50, "Cat", true));
            suppliesList.Add(new Food(100, "Dog", true));
            suppliesList.Add(new Food(10, "Fish", true));
            suppliesList.Add(new Health(50, "Cat", true));
            suppliesList.Add(new Health(100, "Dog", true));
            suppliesList.Add(new Toys(10, "Snake", true));
            suppliesList.Add(new Toys(50, "Hamster", true));
            suppliesList.Add(new Toys(100, "Dog", true));
            suppliesList.Add(new Decorations(10, "Fish", true));
            suppliesList.Add(new Decorations(50, "Cat", true));
            suppliesList.Add(new Decorations(100, "Dog", true));
            suppliesList.Add(new Decorations(10, "Fish", true));
        }
    }
}