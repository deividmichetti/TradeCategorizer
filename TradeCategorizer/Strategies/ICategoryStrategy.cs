using TradeCategorizer.Models;

namespace TradeCategorizer.Strategies
{
    public interface ICategoryStrategy
    {
        string GetCategory(ITrade trade);
    }
}
