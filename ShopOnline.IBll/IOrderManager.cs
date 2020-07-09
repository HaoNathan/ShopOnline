using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IOrderManager
    {
        /// <summary>
        /// 添加商品订单
        /// </summary>
        /// <returns></returns>
        Task<int> AddOrder(int isPay,OrderDto model);
        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <returns></returns>
        IQueryable<OrderDto> QueryAllOrder(Guid id);
    }
}