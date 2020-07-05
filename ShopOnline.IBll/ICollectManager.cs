using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface ICollectManager
    {
        Task<int> AddCollect(CollectDto model);
        Task<int> UpdateCollect(CollectDto model);
        Task<CollectDto> QueryCollect(Guid userId);
        IQueryable<CollectDto> QueryAllCollect();
    }
}