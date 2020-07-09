using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IOrderInfoManager
    {
        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="model">订单实体</param>
        /// <returns></returns>
        Task<int> AddOrder(OrderInfoDto model);
        Task<int> UpdateOrder(OrderInfoDto model);
        Task<int> UpdateOrderState(Guid id,bool state);

        UserDistributionDto QueryOrderDistribution(Guid id);
        /// <summary>
        /// 购买后删除用户购物车中的商品
        /// </summary>
        /// <param name="id">用户主键</param>
        /// <returns></returns>
        Task<int> DeleteShoppingCard(Guid id);
        IQueryable<ShoppingCartDto> GetShoppingCarts(Guid id);
        Task<OrderInfoDto> QueryOrder(Guid id);
        IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove);
    }
}