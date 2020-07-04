using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IBusinessManager
    {
        Task<int> AddBusiness();
        Task<int> UpdateBusiness();
        Task<BusinessDto> QueryBusiness(Guid id);
        IQueryable<BusinessDto> QueryAllBusiness();
    }
}