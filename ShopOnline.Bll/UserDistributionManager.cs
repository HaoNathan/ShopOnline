using System;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class UserDistributionManager:IUserDistributionManager
    {
        private readonly IUserDistributionService _service;


        public UserDistributionManager(IUserDistributionService service)
        {
            _service = service;
        }
        public async Task<int> AddUserDistribution(UserDistributionDto model)
        {
            return await _service.AddAsync(new UserDistribution()
            {
                ConsigneeAddress = model.ConsigneeAddress,
                ConsigneeName = model.ConsigneeName,
                ConsigneePhone = model.ConsigneePhone,
                UserId = model.UserId
            });
        }

        public async Task<UserDistributionDto> QueryUserDistribution(Guid id)
        {
            var data = await _service.QueryAsync(m => m.UserId.Equals(id));
            return new UserDistributionDto()
            {
                ConsigneeAddress = data.ConsigneeAddress,
                ConsigneeName = data.ConsigneeName,
                ConsigneePhone = data.ConsigneePhone,
                UserId = data.UserId
            };
        }

        public async Task<int> UpdateUserDistribution(UserDistributionDto model)
        {
            
            return  await _service.EditAsync(new UserDistribution()
            {
                ConsigneeAddress = model.ConsigneeAddress,
                ConsigneeName = model.ConsigneeName,
                ConsigneePhone = model.ConsigneePhone,
                UpdateTime = DateTime.Now
            });
            
        }
    }
}