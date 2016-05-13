namespace GildedRose.Console.Strategies
{
    public abstract class QualityUpdateStrategyBase
    {
        public void Update(Item item)
        {
            this.UpdateQuality(item);
            item.SellIn--;
        }

        protected abstract void UpdateQuality(Item item);
    }
}
