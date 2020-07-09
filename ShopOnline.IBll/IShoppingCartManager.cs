using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IShoppingCartManager
    {
        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 
        Task<int> AddShoppingCart(ShoppingCartDto model);

        /// <summary>
        /// 查询用户购物车中是否有同一商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShoppingCartDto IsExist(Guid id);

        /// <summary>
        /// 修改商品数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<int> UpdateShoppingCart(Guid id, int number);

        /// <summary>
        /// 修改商品数量(有重复)
        /// </summary>
        /// <returns></returns>
        Task<int> UpdateShoppingCart(ShoppingCartDto model);

        /// <summary>
        /// 删除购物车中的商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteShoppingCart(Guid id);

        /// <summary>
        /// 查询用户购物车中的商品
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        IQueryable<ShoppingCartDto> QueryShoppingCart(Guid id);


        IQueryable<ShoppingCartDto> QueryAllShoppingCart();

    }
}