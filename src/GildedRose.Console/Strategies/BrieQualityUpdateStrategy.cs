namespace GildedRose.Console.Strategies
{
    public class BrieQualityUpdateStrategy : QualityUpdateStrategyBase, IQualityUpdateStrategy
    {
        public bool AcceptsItemName(string itemName)
        {
            return ItemTypes.Brie == itemName;
        }

        protected override void UpdateQuality(Item item)
        {
            if (this.QualityIsLessThanFifty(item.Quality))
            {
                item.Quality++;
            }
        }

        private bool QualityIsLessThanFifty(int quality)
        {
            return quality < 50;
        }
    }
}
