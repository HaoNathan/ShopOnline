using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class OrderManager:IOrderManager
    {
        private IOrderService _service;

        public OrderManager(IOrderService service)
        {
            _service = service;
        }


        public async Task<int> AddOrder(OrderDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateOrder()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto> QueryOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<OrderDto> QueryAllOrder()
        {
            throw new NotImplementedException();
        }
    }
}