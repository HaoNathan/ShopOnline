using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class BusinessManager:IBusinessManager
    {
        private IBusinessService _service;

        public BusinessManager(IBusinessService service)
        {
            _service = service;
        }


        public async Task<int> AddBusiness(BusinessDto model)
        {
            return await _service.AddAsync(new Business()
            {
                ProductId = model.ProductId,
                TotalPrice = model.TotalPrice,
                Number = model.Number,
                PayTypeId = model.PayTypeId
            });
        }

        public async Task<int> UpdateBusiness(BusinessDto model)
        {
            var business = await _service.QueryAsync(model.Id);

            business.ProductId = model.ProductId;
            business.TotalPrice = model.TotalPrice;
            business.Number = model.Number;
            business.PayTypeId = model.PayTypeId;
            business.UpdateTime = DateTime.Now;

            return await _service.EditAsync(business);
        }

        public async Task<BusinessDto> QueryBusiness(Guid id)
        {
            var business= await _service.QueryAsync(id);
            return new BusinessDto()
            {
                TotalPrice = business.TotalPrice,
                Number = business.Number,
                PayTypeId = business.PayTypeId,
                ProductId = business.ProductId
            };
        }

        public IQueryable<BusinessDto> QueryAllBusiness()
        {
            return _service.QueryAllAsync(false).Select(m=>new BusinessDto()
            {
                TotalPrice = m.TotalPrice,
                Number = m.Number,
                IsRemove = m.IsRemove,
                CreateTime = m.CreateTime,
                PayTypeId = m.PayTypeId,
                ProductId = m.ProductId
            });
        }
    }
}