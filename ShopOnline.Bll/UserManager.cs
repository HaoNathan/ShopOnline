using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class UserManager:IUserManager
    {
        private readonly IUserService _service;

        public UserManager(IUserService service)
        {
            _service = service;
        }
        public IQueryable<UserDto> GetAllUser()
        {
            return _service.QueryAllAsync(false).Select(m=>new UserDto()
            {
                Id =m.Id,
                CreateTime = m.CreateTime,
                IsRemove = m.IsRemove,
                IsMember = m.IsMember,
                UserName = m.UserName,
                UserPassword = m.UserPassword,
                Email = m.Email,
                Phone = m.Phone,
                ImagePath = m.ImagePath,
                UpdateTime = DateTime.Now
            });
        }

        public async Task<UserDto> UserLogin(string userName,string userPwd)
        {
            var user= await _service.QueryAsync(false,m => m.UserName.Equals(userName) 
                                   && m.UserPassword.Equals(userPwd));

            if (user==null)
                return null;

            return new UserDto()
            {
                Id = user.Id,
                ImagePath = user.ImagePath,
                UserName = user.UserName,
                IsMember = user.IsMember
            };
        }

        public async Task<UserDto> QueryUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> EditUser(UserDto model)
        {
            var user = await _service.QueryAsync(model.Id);
            user.UserName = model.UserName;
            user.UserPassword = model.UserPassword;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.ImagePath = model.ImagePath;
            user.UpdateTime = DateTime.Now;

            return await _service.EditAsync(user);

        }

        public async Task<int> AddUser(UserDto model)
        {
            return await _service.AddAsync(new User()
            {
                UserName = model.UserName,
                UserPassword = model.UserPassword,
                Email = model.Email,
                Phone = model.Phone,
                ImagePath = model.ImagePath
            });
        }
    }
}