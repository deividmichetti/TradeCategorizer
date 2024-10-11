using TradeCategorizer.Models;

namespace TradeCategorizer.Strategies
{
    public class MediumRiskStrategy : ICategoryStrategy
    {
        public string GetCategory(ITrade trade)
        {
            if (trade == null)
            {
                return "ERROR: Trade is null";
            }

            if (trade.Value > 1000000 && trade.ClientSector == "Public")
            {
                return "MEDIUMRISK";
            }

            return "ERROR: No matching rule in MediumRiskStrategy";
        }
    }
}
