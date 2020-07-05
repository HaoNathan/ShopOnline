using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IOrderManager
    {
        Task<int> AddOrder(OrderInfoDto model);
        Task<int> UpdateOrder(OrderInfoDto MODEL);
        Task<OrderInfoDto> QueryOrder(Guid id);
        IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove);
    }
}