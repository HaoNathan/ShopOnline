using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IBusinessManager
    {
        Task<int> AddBusiness(BusinessDto model);
        Task<int> UpdateBusiness(BusinessDto model);
        Task<BusinessDto> QueryBusiness(Guid id);
        IQueryable<BusinessDto> QueryAllBusiness();
    }
}