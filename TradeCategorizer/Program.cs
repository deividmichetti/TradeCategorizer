using System;
using System.Collections.Generic;
using TradeCategorizer.Models;
using TradeCategorizer.Services;

namespace TradeCategorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var portfolio = new List<ITrade>
            {
                new Trade(2000000, "Private"),
                new Trade(400000, "Public"),
                new Trade(500000, "Public"),
                new Trade(3000000, "Public")
            };
                
            var tradeCategorizer = new TradeRiskCategorizer();
            var tradeCategories = tradeCategorizer.CategorizeTrades(portfolio);

            foreach (var category in tradeCategories)
            {
                Console.WriteLine(category);
            }
        }
    }
}
