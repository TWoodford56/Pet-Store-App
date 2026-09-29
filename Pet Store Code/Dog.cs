using pets;

namespace dog
{
    public class Dog : Pets
    {
        //allows the following info to be stored within a dog object
        public Dog(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}