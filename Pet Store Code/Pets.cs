using cat;
using dog;
using fish;
using hamster;
using ipurchasables;
using lizard;
using snake;
using System.Data;
using System.Text;

namespace pets
{
    public class Pets : IPurchasables
    {
        //class which inherits the values of IPUrchasables
        public int price { get; protected set; }
        public bool purchasable{ get; protected set; }
        public string relatedAnimalorBreed{ get; protected set; }

        //creates a list of the possible pets
        public List<IPurchasables> petsList = new List<IPurchasables>();

        //fill the pets list 
        public void fill()
        {
            petsList.Add(new Dog(100, "Labrador", true));
            petsList.Add(new Cat(75, "Siamese", true));
            petsList.Add(new Dog(100, "Poodle", true));
            petsList.Add(new Cat(75, "British Shorthair", true));
            petsList.Add(new Dog(120, "Poodle", true));
            petsList.Add(new Cat(60, "Siamese", false));
            petsList.Add(new Lizard(200, "Gecko", true));
            petsList.Add(new Lizard(210, "Gecko", true));
            petsList.Add(new Lizard(200, "Chameleon", true));
            petsList.Add(new Fish(20, "Marlin", true));
            petsList.Add(new Fish(10, "Angelfish", true));
            petsList.Add(new Fish(30, "Koi Fish", true));
            petsList.Add(new Fish(20, "Marlin", true));
            petsList.Add(new Fish(10, "Angelfish", true));
            petsList.Add(new Fish(30, "Koi Fish", true));
            petsList.Add(new Fish(20, "Marlin", true));
            petsList.Add(new Fish(10, "Angelfish", true));
            petsList.Add(new Fish(30, "Koi Fish", true));
            petsList.Add(new Fish(10, "Angelfish", true));
            petsList.Add(new Hamster(30, "European Hamster", true));
            petsList.Add(new Hamster(20, "Dwarf Hamster", true));
            petsList.Add(new Hamster(10, "Chinese Hamster", true));
            petsList.Add(new Hamster(30, "European Hamster", true));
            petsList.Add(new Hamster(20, "Dwarf Hamster", true));
            petsList.Add(new Snake(500, "Cobra", true));
            petsList.Add(new Snake(300, "Grass Snake", true));
        }

        //get the price of the selected pet
        public int getPrice()
        {
            return price;
        }        
    }
}