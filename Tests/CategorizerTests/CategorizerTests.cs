using System.Collections.Generic;
using TradeCategorizer.Models;
using TradeCategorizer.Services;
using Xunit;

namespace TradeCategorizerTests.CategorizerTests
{
    public class CategorizerTests
    {
        [Fact]
        public void TradeRiskCategorizer_ShouldCategorizePortfolioCorrectly()
        {
            var tradeCategorizer = new TradeRiskCategorizer();
            var portfolio = new List<ITrade>
            {
                new Trade(2000000, "Private"),
                new Trade(400000, "Public"),
                new Trade(500000, "Public"),
                new Trade(3000000, "Public")
            };

            // Act
            var result = tradeCategorizer.CategorizeTrades(portfolio);

            // Assert
            Assert.Equal(4, result.Count);
            Assert.Equal("HIGHRISK", result[0]);
            Assert.Equal("LOWRISK", result[1]);
            Assert.Equal("LOWRISK", result[2]);
            Assert.Equal("MEDIUMRISK", result[3]);
        }

        [Fact]
        public void TradeRiskCategorizer_ShouldHandleNullTradesInPortfolio()
        {
            // Arrange
            var tradeCategorizer = new TradeRiskCategorizer();
            var portfolio = new List<ITrade>
            {
                null,
                new Trade(500000, "Public")    
            };

            // Act
            var result = tradeCategorizer.CategorizeTrades(portfolio);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("ERROR: Trade is null", result[0]);
            Assert.Equal("LOWRISK", result[1]);
        }
    }
}


