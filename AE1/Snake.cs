using pets;

namespace snake
{
    public class Snake : Pets
    {
        //allows the following info to be stored within a dog object
        public Snake(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}