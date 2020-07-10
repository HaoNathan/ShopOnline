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
    public class OrderManager : IOrderManager
    {
        private readonly IOrderService _service;

        public OrderManager(IOrderService service)
        {
            _service = service;
        }

        public async Task<int> AddOrder(int isPay,OrderDto model)
        {
            var result = await _service.AddAsync(new Order()
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice
            });

            if (result == 1&&isPay==1)
            {
                IProductService service = new ProductService();
                var product = await service.QueryAsync(model.ProductId);
                product.ProductNumber -= Convert.ToInt32(model.Quantity);
                return await service.EditAsync(product);

            }

            return result;

        }

        public IQueryable<OrderDto> QueryAllOrder(Guid id)
        {
            return _service.QueryAllAsync(m => !m.IsRemove
                                               && m.OrderId.Equals(id))
                .Select(m => new OrderDto()
                {
                    OrderId = m.OrderId,
                    ProductId = m.ProductId,
                    Quantity = m.Quantity,
                    UnitPrice = m.UnitPrice
                });
        }

    }
}