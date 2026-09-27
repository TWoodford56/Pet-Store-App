using supplies;

namespace toys
{
    public class Toys : Supplies
    {
        //allows the following variables to be stored within an ENclosure Object
        public Toys(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}