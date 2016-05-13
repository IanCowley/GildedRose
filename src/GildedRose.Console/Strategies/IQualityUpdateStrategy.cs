namespace GildedRose.Console.Strategies
{
    public interface IQualityUpdateStrategy
    {
        bool AcceptsItemName(string itemName);

        void Update(Item item);
    }
}
