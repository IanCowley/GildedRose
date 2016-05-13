using System.Linq;

namespace GildedRose.Console.Strategies
{
    public class ConjuredManQualityUpdateStrategy : DepreciatingQualityUpdateStrategyBase, IQualityUpdateStrategy
    {
        public bool AcceptsItemName(string itemName)
        {
            return new[] {
                        ItemTypes.ConjuredManaCake
                    }
                    .Contains(
                    itemName);
        }

        protected override int DepreciationFactor
        {
            get
            {
                return 2;
            }
        }
    }
}
