using pets;

namespace fish
{
    public class Fish : Pets
    {
        //allows the following info to be stored within a dog object
        public Fish(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}