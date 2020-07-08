using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dal;
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
            IProductService service2=new  ProductService();
            var product =await service2.QueryAsync(model.ProductId);
            return await _service.AddAsync(new ShoppingCart()
            {
                ProductId = model.ProductId,
                ColorId = product.ColorId,
                SizeId = product.SizeId,
                Number = 1,
                UserId = model.UserId
            });
        }

        public async Task<int> UpdateShoppingCart(Guid id,int number)
        {
            var shoppingCart = await _service.QueryAsync(id);

            shoppingCart.Number = number;
            shoppingCart.UpdateTime=DateTime.Now;

            return await _service.EditAsync(shoppingCart);
        }

        public async Task<int> DeleteShoppingCart(Guid id)
        {
            var card = await _service.QueryAsync(id);
            card.IsRemove = true;
            return await _service.EditAsync(card);
        }

        public  IQueryable<ShoppingCartDto> QueryShoppingCart(Guid id)
        {
            return  _service.QueryAllAsync(m=>m.UserId.Equals(id)&&m.IsRemove==false).Select(m=>new ShoppingCartDto()
            {
                ProductId = m.ProductId,
                ColorId = m.ColorId,
                SizeId = m.SizeId,
                Number = m.Number,
                Id = m.Id,
                ProductImagePath = m.Product.ProductImagePath,
                ProductName = m.Product.ProductName,
                ProductPrice = m.Product.ProductPrice
            });
           
        }

        public IQueryable<ShoppingCartDto> QueryAllShoppingCart()
        {
            return _service.QueryAllAsync().Where(m=>m.IsRemove==false)
                .Select(m => new ShoppingCartDto()
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