using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IOrderManager
    {
        Task<int> AddOrder(OrderDto model);
        Task<int> UpdateOrder(OrderDto MODEL);
        Task<OrderDto> QueryOrder(Guid id);
        IQueryable<OrderDto> QueryAllOrder(bool isRemove);
    }
}