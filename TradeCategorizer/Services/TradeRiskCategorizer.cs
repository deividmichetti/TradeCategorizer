using System.Collections.Generic;
using TradeCategorizer.Models;
using TradeCategorizer.Strategies;

namespace TradeCategorizer.Services
{
    public class TradeRiskCategorizer
    {
        private readonly List<ICategoryStrategy> _strategies;

        public TradeRiskCategorizer()
        {
            _strategies = new List<ICategoryStrategy>
            {
                new LowRiskStrategy(),
                new MediumRiskStrategy(),
                new HighRiskStrategy()
            };
        }

        public List<string> CategorizeTrades(List<ITrade> portfolio)
        {
            var tradeCategories = new List<string>();

            foreach (var trade in portfolio)
            {
                var category = "";
                foreach (var strategy in _strategies)
                {
                    category = strategy.GetCategory(trade);
                    if (!category.StartsWith("ERROR")) break;
                }

                tradeCategories.Add(category);
            }

            return tradeCategories;
        }
    }
}
