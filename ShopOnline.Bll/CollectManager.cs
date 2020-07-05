using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class CollectManager:ICollectManager
    {
        private readonly ICollectService _service;

        public CollectManager(ICollectService service) => _service = service;


        public async Task<int> AddCollect(CollectDto model) =>
            await _service.AddAsync(new Collect()
            {
                ProductId = model.ProductId,
                UserId = model.UserId
            });

        public async Task<int> UpdateCollect(CollectDto model)
        {
            var collect = await _service.QueryAsync(model.Id);
            collect.ProductId = model.ProductId;
            collect.UserId = model.UserId;

            return await _service.EditAsync(collect);

        }

        public async Task<CollectDto> QueryCollect(Guid userId)
        {
            var collect = await _service.QueryAsync(false, m => m.UserId.Equals(userId));

            if (collect == null) 
                return null;
            else
                return new CollectDto()
                {
                    Id = collect.Id,
                    ProductId = collect.ProductId,
                    UserId = collect.UserId,
                    
                };
        }

        public IQueryable<CollectDto> QueryAllCollect() =>
            _service.QueryAllAsync(true).Select(m => new CollectDto
            {
                Id=m.Id,
                CreateTime = m.CreateTime,
                ProductId = m.ProductId,
                UserName = m.User.UserName,
                UserId = m.UserId
                
            });
    }
}