using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class ShoppingCartManager:IShoppingCartManager
    {
        private readonly IShoppingCartService _service;

        public ShoppingCartManager(IShoppingCartService service)
        {
            _service = service;
        }
        public async Task<int> AddShoppingCart(ShoppingCartDto model)
        {
            return await _service.AddAsync(new ShoppingCart()
            {
                ProductId = model.ProductId,
                ColorId = model.ColorId,
                SizeId = model.SizeId,
                Number = model.Number,
                UserId = model.UserId
            });
        }

        public async Task<int> UpdateShoppingCart(ShoppingCartDto model)
        {
            var shoppingCart = await _service.QueryAsync(model.Id);

            shoppingCart.ProductId = model.ProductId;
            shoppingCart.ProductId = model.ProductId;
            shoppingCart.ColorId = model.ColorId;
            shoppingCart.SizeId = model.SizeId;
            shoppingCart.Number = model.Number;
            shoppingCart.UserId = model.UserId;
            shoppingCart.UpdateTime=DateTime.Now;

            return await _service.EditAsync(shoppingCart);
        }

        public async Task<ShoppingCartDto> QueryShoppingCart(Guid id)
        {
            var shoppingCart= await _service.QueryAsync(id);
            return new ShoppingCartDto()
            {
                ProductId = shoppingCart.ProductId,
                ColorId = shoppingCart.ColorId,
                SizeId = shoppingCart.SizeId,
                Number = shoppingCart.Number,
                UserId = shoppingCart.UserId,
                Id = shoppingCart.Id
            };
        }

        public IQueryable<ShoppingCartDto> QueryAllShoppingCart()
        {
            return _service.QueryAllAsync(true).Select(m => new ShoppingCartDto()
            {
                ProductId = m.ProductId,
                ColorId = m.ColorId,
                SizeId = m.SizeId,
                Number = m.Number,
                UserId = m.UserId,
                Id = m.Id,
                IsRemove = m.IsRemove,
                CreateTime = m.CreateTime
            });
        }

    }
}