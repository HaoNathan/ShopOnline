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
        Task<int> AddOrder(OrderDto model);
    }
}