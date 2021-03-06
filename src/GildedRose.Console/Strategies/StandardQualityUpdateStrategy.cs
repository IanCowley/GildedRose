﻿using System.Linq;

namespace GildedRose.Console.Strategies
{
    public class StandardQualityUpdateStrategy : DepreciatingQualityUpdateStrategyBase, IQualityUpdateStrategy
    {
        public bool AcceptsItemName(string itemName)
        {
            return new[] {
                        ItemTypes.DexterityVest, 
                        ItemTypes.ElixirMongoose
                    }
                    .Contains(
                    itemName);
        }

        protected override int DepreciationFactor
        {
            get
            {
                return 1;
            }
        }
    }
}
