namespace GildedRose.Console.Strategies
{
    public abstract class DepreciatingQualityUpdateStrategyBase : QualityUpdateStrategyBase
    {
        protected override void UpdateQuality(Item item)
        {
            if (this.HasPositiveQuality(item.Quality))
            {
                var depreciationFactor = this.GetQualityDepreciationFactor(item);
                item.Quality = item.Quality - depreciationFactor;
            }
        }

        private int GetQualityDepreciationFactor(Item item)
        {
            if (PassedSellByDate(item))
            {
                return this.DepreciationFactor * 2;
            }

            return this.DepreciationFactor;
        }

        private static bool PassedSellByDate(Item item)
        {
            return item.SellIn < 0;
        }

        private bool HasPositiveQuality(int quality)
        {
            return quality > 0;
        }

        protected abstract int DepreciationFactor { get; }
    }
}
