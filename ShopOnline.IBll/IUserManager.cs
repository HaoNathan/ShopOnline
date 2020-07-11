using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;

namespace ShopOnline.IBll
{
    public interface IUserManager
    {
        IQueryable<UserDto> GetAllUser();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        Task<UserDto> UserLogin(string userName,string userPwd);

        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        Task<UserDto> QueryUser(Guid id);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        Task<int> EditUser(bool editType,UserDto model);

        /// <summary>
        /// 判断是否重名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> IsExistUser(string name);

        /// <summary>
        /// 会员充值
        /// </summary>
        /// <para name="id">会员主键</para>
        /// <returns></returns>
        Task<int> GetMember(Guid id);

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> AddUser(UserDto model);

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        Task<int> UpdateUserState(Guid id,bool state);

    }
}