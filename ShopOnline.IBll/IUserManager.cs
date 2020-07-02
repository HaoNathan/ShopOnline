using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IUserManager
    {
        IQueryable<UserDto> GetAllUser();

        Task<UserDto> QueryUser();

        Task<int> EditUser();

        Task<int> AddUser();
    }
}