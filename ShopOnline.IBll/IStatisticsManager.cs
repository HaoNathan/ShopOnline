using System.Threading.Tasks;

namespace ShopOnline.IBll
{
    public interface IStatisticsManager
    {
        Task<int> GetProductCount();
    }
}