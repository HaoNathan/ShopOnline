using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.Model;

namespace ShopOnline.IBll
{
    public interface IRolesManager
    {
        Task<int> AddRoles(RolesDto model);
        IQueryable<RolesDto> GetAllRoles();

    }
}