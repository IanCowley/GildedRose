namespace GildedRose.Console.Strategies
{
    public class BackStagePassesQualityUpdateStrategy : QualityUpdateStrategyBase, IQualityUpdateStrategy
    {
        public bool AcceptsItemName(string itemName)
        {
            return ItemTypes.BackStagePasses == itemName;
        }

        protected override void UpdateQuality(Item item)
        {
            if (this.SellByDateHasPassed(item.SellIn))
            {
                item.Quality = 0;
                return;
            }

            var appreciationFactor = this.GetQualityAppreciationFactor(item);
            item.Quality += appreciationFactor;
        }

        private int GetQualityAppreciationFactor(Item item)
        {
            if (this.HasFiveDaysOrLessToSell(item.SellIn))
            {
                return 3;
            }

            if (this.HasTenDaysOrLessToSell(item.SellIn))
            {
                return 2;
            }

            return 1;
        }

        private bool SellByDateHasPassed(int sellIn)
        {
            return sellIn < 1;
        }

        private bool HasFiveDaysOrLessToSell(int sellIn)
        {
            return sellIn <= 5;
        }

        private bool HasTenDaysOrLessToSell(int sellIn)
        {
            return sellIn <= 10;
        }
    }
}
