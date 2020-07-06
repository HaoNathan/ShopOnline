using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IUserManager
    {
        IQueryable<UserDto> GetAllUser();

        Task<UserDto> UserLogin(string userName,string userPwd);
        Task<UserDto> QueryUser(Guid id);

        Task<int> EditUser(UserDto model);

        Task<bool> IsExistUser(string name);


        Task<int> AddUser(UserDto model);
    }
}