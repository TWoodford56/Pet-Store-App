using supplies;

namespace enclosure
{
    public class Enclosure : Supplies
    {
        //allows the following variables to be stored within an ENclosure Object
        public Enclosure(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}