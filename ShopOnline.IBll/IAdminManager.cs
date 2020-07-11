using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.Model;

namespace ShopOnline.IBll
{
    public interface IAdminManager
    {
        /// <summary>
        /// 查询所有管理员
        /// </summary>
        /// <returns></returns>
        IQueryable<AdminDto> GetAllAdmin();

        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <param name="id">管理员Id</param>
        /// <returns></returns>
        Task<AdminDto> QueryAdmin(Guid id);

        Task<AdminDto>AdminLogin(AdminDto model);
        Task<int> InsertAdmin(AdminDto model);
        IQueryable<RolesDto> GetRoles();

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> UpdateAdmin(AdminDto model);

        /// <summary>
        /// 修改管理员状态
        /// </summary>
        /// <param name="state">状态</param>
        /// <param name="id">管理员主键</param>
        /// <returns></returns>
        Task<int> UpdateAdminState(string state,Guid id);
    }
}