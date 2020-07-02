using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.Model;

namespace ShopOnline.IBll
{
    public interface IAdminManager
    {
        IQueryable<AdminDto> GetAllAdmin();
        Task<AdminDto> QueryAdmin(Guid id);
        AdminDto AdminLogin(AdminDto model);
        Task<int> InsertAdmin(AdminDto model);
        IQueryable<RolesDto> GetRoles();
        Task<int> UpdateAdmin(AdminDto model);
        Task<int> UpdateAdminState(string state,Guid id);
    }
}