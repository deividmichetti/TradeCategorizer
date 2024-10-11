using TradeCategorizer.Models;
using TradeCategorizer.Strategies;
using Xunit;

namespace TradeCategorizer.Tests
{
    public class StrategyTests
    {
        [Fact]
        public void LowRiskStrategy_ShouldReturnLowRisk_WhenTradeIsPublicAndBelowThreshold()
        {
            // Arrange
            var strategy = new LowRiskStrategy();
            var trade = new Trade(500000, "Public");

            // Act
            var result = strategy.GetCategory(trade);

            // Assert
            Assert.Equal("LOWRISK", result);
        }

        [Fact]
        public void MediumRiskStrategy_ShouldReturnMediumRisk_WhenTradeIsPublicAndAboveThreshold()
        {
            // Arrange
            var strategy = new MediumRiskStrategy();
            var trade = new Trade(2000000, "Public");

            // Act
            var result = strategy.GetCategory(trade);

            // Assert
            Assert.Equal("MEDIUMRISK", result);
        }

        [Fact]
        public void HighRiskStrategy_ShouldReturnHighRisk_WhenTradeIsPrivateAndAboveThreshold()
        {
            // Arrange
            var strategy = new HighRiskStrategy();
            var trade = new Trade(2000000, "Private");

            // Act
            var result = strategy.GetCategory(trade);

            // Assert
            Assert.Equal("HIGHRISK", result);
        }

        [Fact]
        public void LowRiskStrategy_ShouldReturnError_WhenTradeIsNull()
        {
            // Arrange
            var strategy = new LowRiskStrategy();

            // Act
            var result = strategy.GetCategory(null);

            // Assert
            Assert.Equal("ERROR: Trade is null", result);
        }
    }
}
