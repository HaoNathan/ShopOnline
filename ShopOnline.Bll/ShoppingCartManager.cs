using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class ShoppingCartManager:IShoppingCartManager
    {
        private IShoppingCartService _service;

        public ShoppingCartManager(IShoppingCartService service)
        {
            _service = service;
        }
        public async Task<int> AddShoppingCart()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateShoppingCart()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ShoppingCartDto> QueryShoppingCart(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ShoppingCartDto> QueryAllShoppingCart()
        {
            throw new System.NotImplementedException();
        }

    }
}