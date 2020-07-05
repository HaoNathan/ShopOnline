using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IShoppingCartManager
    {
        Task<int> AddShoppingCart(ShoppingCartDto model);
        Task<int> UpdateShoppingCart(ShoppingCartDto model);
        Task<ShoppingCartDto> QueryShoppingCart(Guid id);
        IQueryable<ShoppingCartDto> QueryAllShoppingCart();

    }
}