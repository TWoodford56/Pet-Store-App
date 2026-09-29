using supplies;

namespace food
{
    public class Food : Supplies
    {
        //allows the following info to be stored within a Food OBject
        public Food(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}