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
    public class OrderInfoManager : IOrderInfoManager
    {
        private readonly IOrderInfoService _service;

        public OrderInfoManager(IOrderInfoService service)
        {
            _service = service;
        }

        public async Task<int> AddOrder(OrderInfoDto model)
        {
            return await _service.AddAsync(new OrderInfo()
            {
                PayState = model.PayState,
                UserId = model.UserId,
                Phone = model.Phone,
                Address = model.Address,
                AcceptName = model.AcceptName,
                TotalPrice = model.TotalPrice,
                PayType = model.PayType
            });
            
        }

        public async Task<int> UpdateOrder(OrderInfoDto model)
        {
            var order = await _service.QueryAsync(model.Id);

            order.PayState = order.PayState;
            order.DeliverySate = order.DeliverySate;
            order.UpdateTime = DateTime.Now;

            return await _service.EditAsync(order);
        }

        public async Task<int> UpdateOrderState(Guid id, bool state)
        {
            var order = await _service.QueryAsync(id);
            order.DeliverySate = state;

            return await _service.EditAsync(order);
        }

        public  UserDistributionDto QueryOrderDistribution(Guid id)
        {
            IUserDistributionService service=new UserDistributionService();

            var data =  service.QueryAllAsync(m =>!m.IsRemove
                                                   && m.UserId.Equals(id)).FirstOrDefault();
            if (data==null)
            {
                return null;
            }

            return new UserDistributionDto()
            {
                ConsigneePhone = data.ConsigneePhone,
                ConsigneeName = data.ConsigneeName,
                ConsigneeAddress = data.ConsigneeAddress
            };
        }

        public async Task<int> DeleteShoppingCard(Guid id)
        {
            IShoppingCartService service=new ShoppingCartService();
            var data = service.QueryAllAsync(m => !m.IsRemove && m.UserId.Equals(id)).ToList();

            foreach (var item in data)
            {

                item.IsRemove = true;
                await service.EditAsync(item);

            }

            return 0;
        }

        public IQueryable<ShoppingCartDto> GetShoppingCarts(Guid id)
        {
            IShoppingCartService service = new ShoppingCartService();
            return service.QueryAllAsync(m => m.UserId.Equals(id) && !m.IsRemove)
                .Select(m => new ShoppingCartDto()
                {
                    Id = m.Id,
                    ProductImagePath = m.Product.ProductImagePath,
                    ProductName = m.Product.ProductName,
                    ProductPrice = m.Product.ProductPrice,
                    Number = m.Number,
                    ProductId = m.ProductId

                });
        }

        public async Task<OrderInfoDto> QueryOrder(Guid id)
        {
            var order = await _service.QueryAsync(id);
            return new OrderInfoDto()
            {
                PayState = order.PayState,
                DeliverySate = order.DeliverySate,

                UserId = order.UserId
            };
        }

        public IQueryable<OrderInfoDto> QueryAllOrder(bool isRemove)
        {
            if (isRemove)
                return _service.QueryAllAsync().Select(m => new OrderInfoDto()
                {
                    PayState = m.PayState,
                    Id = m.Id,
                    DeliverySate = m.DeliverySate,
                    PayType = m.PayType,
                    TotalPrice = m.TotalPrice,
                    Phone = m.Phone,
                    Address = m.Address,
                    UserId = m.UserId,
                    CreateTime = m.CreateTime,
                    IsRemove = m.IsRemove,
                    AcceptName = m.AcceptName
                });
            else
                return _service.QueryAllAsync().Where(m => m.IsRemove == false).Select(m => new OrderInfoDto()
                {
                    Id=m.Id,
                    PayState = m.PayState,
                    DeliverySate = m.DeliverySate,
                    PayType = m.PayType,
                    TotalPrice = m.TotalPrice,
                    Phone = m.Phone,
                    Address = m.Address,
                    UserId = m.UserId,
                    CreateTime = m.CreateTime,
                    IsRemove = m.IsRemove,
                    AcceptName = m.AcceptName
                });
        }
    }
}