using pets;

namespace cat
{
    public class Cat : Pets
    {
        //Constructor to allow values to be stored in the objects
        public Cat(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}