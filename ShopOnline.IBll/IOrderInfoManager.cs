using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IOrderInfoManager
    {
        Task<int> AddOrder(OrderInfoDto model);
        Task<int> UpdateOrder(OrderInfoDto model);
        Task<int> UpdateOrderState(Guid id,bool state);

        Task<OrderInfoDto> QueryOrder(Guid id);
        IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove);
    }
}