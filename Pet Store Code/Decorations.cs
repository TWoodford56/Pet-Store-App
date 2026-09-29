using supplies;

namespace decorations
{
    public class Decorations : Supplies
    {
        //allows the following variables to be stored within an ENclosure Object
        public Decorations(int price, string relatedAnimalorBreed, bool purchasable)
        {
            this.price = price;
            this.relatedAnimalorBreed = relatedAnimalorBreed;
            this.purchasable = purchasable;
        }
    }
}