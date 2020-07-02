using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;

namespace ShopOnline.Bll
{
    public class UserManager:IUserManager
    {
        public IQueryable<UserDto> GetAllUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDto> QueryUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> EditUser()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddUser()
        {
            throw new System.NotImplementedException();
        }
    }
}