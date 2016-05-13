using System.Linq;

namespace GildedRose.Console.Strategies
{
    public class StandardQualityUpdateStrategy : QualityUpdateStrategyBase, IQualityUpdateStrategy
    {
        public bool AcceptsItemName(string itemName)
        {
            return new[] {
                        ItemTypes.ConjuredManaCake, 
                        ItemTypes.DexterityVest, 
                        ItemTypes.ElixirMongoose
                    }
                    .Contains(
                    itemName);
        }

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
                return 2;
            }

            return 1;
        }

        private static bool PassedSellByDate(Item item)
        {
            return item.SellIn < 0;
        }

        private bool HasPositiveQuality(int quality)
        {
            return quality > 0;
        }
    }
}
