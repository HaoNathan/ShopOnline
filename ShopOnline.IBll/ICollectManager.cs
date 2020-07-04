using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface ICollectManager
    {
        Task<int> AddCollect();
        Task<int> UpdateCollect();
        Task<CollectDto> QueryCollect();
        IQueryable<CollectDto> QueryAllCollect();
    }
}