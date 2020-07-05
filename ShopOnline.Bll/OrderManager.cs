using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<int> AddOrder(OrderInfoDto model)
        {
            return await _service.AddAsync(new OrderInfo()
            {
                PayState = model.PayState,
                DeliverySate = model.DeliverySate,
                UserDistributionId = model.UserDistributionId,
                ProductId = model.ProductId,
                UserId = model.UserId
        });
        }

        public async Task<int> UpdateOrder(OrderInfoDto model)
        {
            var order = await _service.QueryAsync(model.Id);

            order.PayState = order.PayState;
            order.DeliverySate = order.DeliverySate;
            order.UserDistributionId = model.UserDistributionId;
            order.UpdateTime=DateTime.Now;
            order.ProductId = model.ProductId;

            return await _service.EditAsync(order);
        }

        public async Task<OrderInfoDto> QueryOrder(Guid id)
        {
            var order=await _service.QueryAsync(id);
            return  new OrderInfoDto()
            {
                PayState = order.PayState,
                DeliverySate = order.DeliverySate,
                UserDistributionId = order.UserDistributionId,
                ProductId = order.ProductId,
                UserId = order.UserId
            };
        }

        public IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove)
        {
            if(isRemove)
                return _service.QueryAllAsync().Select(m => new OrderInfoDto()
                {
                    PayState = m.PayState,
                    DeliverySate = m.DeliverySate,
                    UserDistributionId = m.UserDistributionId,
                    ProductId = m.ProductId,
                    UserId = m.UserId,
                    CreateTime = m.CreateTime,
                    IsRemove = m.IsRemove
                });
            else
                return _service.QueryAllAsync().Where(m=>m.IsRemove==false).Select(m => new OrderInfoDto()
                {
                    PayState = m.PayState,
                    DeliverySate = m.DeliverySate,
                    UserDistributionId = m.UserDistributionId,
                    ProductId = m.ProductId,
                    UserId = m.UserId,
                    CreateTime = m.CreateTime,
                    IsRemove = m.IsRemove
                });
        }
    }
}