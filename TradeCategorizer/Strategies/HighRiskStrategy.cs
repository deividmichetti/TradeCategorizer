using TradeCategorizer.Models;


namespace TradeCategorizer.Strategies
{
    public class HighRiskStrategy : ICategoryStrategy
    {
        public string GetCategory(ITrade trade)
        {
            if (trade == null)
            {
                return "ERROR: Trade is null";
            }

            if (trade.Value > 1000000 && trade.ClientSector == "Private")
            {
                return "HIGHRISK";
            }

            return "ERROR: No matching rule in HighRiskStrategy";
        }
    }
}
