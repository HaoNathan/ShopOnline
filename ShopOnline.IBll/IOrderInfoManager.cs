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

        /// <summary>
        /// 移除订单
        /// </summary>
        /// <param name="id">订单id</param>
        /// <returns></returns>
        Task<int> DeleteOrder(Guid id);

        /// <summary>
        ///更新支付状态
        /// </summary>
        /// <param name="id">订单id</param>
        /// <returns></returns>
        Task<int> UpdateOrderPayState(Guid id);

        /// <summary>
        /// 更新发货状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<int> UpdateOrderState(Guid id,bool state);

        /// <summary>
        /// 获取收件人的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserDistributionDto QueryOrderDistribution(Guid id);

        /// <summary>
        /// 购买后删除用户购物车中的商品
        /// </summary>
        /// <param name="id">用户主键</param>
        /// <returns></returns>
        Task<int> DeleteShoppingCard(Guid id);

        /// <summary>
        /// 查询用户订单中的商品
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        IQueryable<ShoppingCartDto> GetShoppingCarts(Guid id);

        /// <summary>
        /// 查询某一订单
        /// </summary>
        /// <param name="id">订单编号</param>
        /// <returns></returns>
        Task<OrderInfoDto> QueryOrder(Guid id);

        /// <summary>
        /// 查询某一订单
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        IQueryable<OrderInfoDto> QueryOrderByUserId(Guid id);

        /// <summary>
        /// 后台获取所有订单
        /// </summary>
        /// <param name="isRemove">是否需要将失效的订单查出</param>
        /// <returns></returns>
        IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove);
    }
}