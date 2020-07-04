using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class BusinessManager:IBusinessManager
    {
        private IBusinessService _service;

        public BusinessManager(IBusinessService service)
        {
            _service = service;
        }


        public async Task<int> AddBusiness()
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateBusiness()
        {
            throw new NotImplementedException();
        }

        public async Task<BusinessDto> QueryBusiness(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BusinessDto> QueryAllBusiness()
        {
            throw new NotImplementedException();
        }
    }
}