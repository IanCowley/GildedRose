using System.Linq;

namespace GildedRose.Console.Strategies
{
    // If I had more than a couple of hours this and all of the strategies would have been found through a DI container, but with the advice of not going too far I have opted to not set up a bootstrapper and DI etc..
    // Also, I would have loved to reduce the duplication of magic names, but the kata said don't change the properties or pretty much anything about item, 
    // so I found the best I could do was to at least pack them off into a constants file, the best solution would have been to make items typed or at least own their own strategy.

    public class QualityUpdateStrategyRepository
    {
        private static readonly IQualityUpdateStrategy[] allQualityUpdateStrategies = { new StandardQualityUpdateStrategy(), new BrieQualityUpdateStrategy(), new BackStagePassesQualityUpdateStrategy() };
        
        public IQualityUpdateStrategy FindQualityUpdateStrategyForItem(Item item)
        {
            return allQualityUpdateStrategies.FirstOrDefault(x => x.AcceptsItemName(item.Name));
        }
    }
}
