namespace ipurchasables
{
    public interface IPurchasables
    {
        //basic interface to be referenced
        int price { get; }

        //can be manipulated if you want to display something without it being able to buy yet, e.g. upcoming release of new dog bed
        bool purchasable { get; }
        string relatedAnimalorBreed { get; }
        int getPrice();

        void fill(); 
    }
}