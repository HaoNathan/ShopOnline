using System;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminService _service;

        public AdminManager(IAdminService service)
        {
            _service = service;
        }

        /// <summary>
        /// 查询所有管理员
        /// </summary>
        /// <returns></returns>
        public  IQueryable<AdminDto> GetAllAdmin()
        {
            return  _service.QueryAllAsync().Select(m=>new AdminDto()
            {
                Id = m.Id,
                RolesName = m.Roles.RolesName,
                AdminName = m.AdminName,
                CreateTime = m.CreateTime,
                IsRemove = m.IsRemove,
                ImagePath = m.ImagePath
            });
        }

        /// <summary>
        /// 查询单个管理员
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public async Task<AdminDto> QueryAdmin(Guid id)
        {
            var data= await _service.QueryAsync(id);
            return new AdminDto()
            {
                Id = data.Id,
                AdminName = data.AdminName,
                ImagePath = data.ImagePath
            };
        }

        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="model">登陆对象</param>
        /// <returns></returns>
        public  AdminDto AdminLogin(AdminDto model)
        {
            var data=  _service.QueryAllAsync(m => m.AdminName == model.AdminName
                         && m.AdminPassword == model.AdminPassword).FirstOrDefault();
            if (data==null)
            {
                return null;
            }
            return new AdminDto()
            {
                Id = data.Id,
                AdminName = data.AdminName,
                ImagePath = data.ImagePath
            };
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model">管理员实体</param>
        /// <returns></returns>
        public async Task<int> InsertAdmin(AdminDto model)
        {
            return await _service.AddAsync(new Admin()
            {
                AdminName = model.AdminName,
                AdminPassword = model.AdminPassword,
                RolesId =model.RolesId,
                ImagePath =model.ImagePath
            });
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<RolesDto> GetRoles()
        {
            IRolesService service = new RolesService();

            var data = service.QueryAllAsync().Select(m => new RolesDto()
            {
                Id = m.Id,
                RolesName = m.RolesName
            });

            return data;
        }

        public async Task<int> UpdateAdmin(AdminDto model)
        {
            var admin = await _service.QueryAsync(model.Id);

            if (!string.IsNullOrEmpty(model.ImagePath))
            {
                admin.ImagePath = model.ImagePath;
            }

            admin.AdminName = model.AdminName;
            admin.AdminPassword = model.AdminPassword;
            admin.RolesId = model.RolesId;
            admin.UpdateTime=DateTime.Now;
            var res= await _service.EditAsync(admin);
            return res;
        }
    }
}