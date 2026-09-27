using pets;

namespace hamster
{
    public class Hamster : Pets
    {
        //allows the following info to be stored within a dog object
        public Hamster(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}