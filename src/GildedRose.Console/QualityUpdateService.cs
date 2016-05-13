using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    // If I had more than a couple of hours this would have been found through a DI container, but with the advice of not going too far I have opted to not set up a bootstrapper and DI etc..

    public class QualityUpdateService
    {
        private readonly QualityUpdateStrategyRepository qualityUpdateStrategyRepository;

        public QualityUpdateService()
        {
            this.qualityUpdateStrategyRepository = new QualityUpdateStrategyRepository();
        }

        public void UpdateQuality(Item item)
        {
            var qualityUpdateStrategy = this.qualityUpdateStrategyRepository.FindQualityUpdateStrategyForItem(item);

            if (qualityUpdateStrategy != null)
            {
                qualityUpdateStrategy.Update(item);
            }
        }
    }
}
