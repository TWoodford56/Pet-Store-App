using pets;

namespace lizard
{
    public class Lizard : Pets
    {
        //Constructor to allow values to be stored
        public Lizard(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}