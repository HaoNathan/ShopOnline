using System;
using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class OrderManager:IOrderManager
    {
        private readonly IOrderService _service;

        public OrderManager(IOrderService service)
        {
            _service = service;
        }
        public async Task<int> AddOrder(OrderDto model)
        {
            var result= await _service.AddAsync(new Order()
            {
                OrderId = model.OrderId,
                ProductId =model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice
            });

            if (result==1)
            {
                IProductService service = new ProductService();
                var product = await service.QueryAsync(model.ProductId);
                product.ProductNumber -= Convert.ToInt32(model.Quantity);
                return await service.EditAsync(product);

            }

            return result;

        }
    }
}