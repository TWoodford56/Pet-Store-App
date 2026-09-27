using supplies;

namespace health
{
    public class Health : Supplies
    {
        //allows the following variables to be stored within an ENclosure Object
        public Health(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}