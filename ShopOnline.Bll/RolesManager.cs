using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class RolesManager:IRolesManager
    {
        private readonly IRolesService _service;

        public RolesManager(IRolesService service)
        {
            _service = service;
        }


        public async Task<int> AddRoles(RolesDto model)
        {
            return await _service.AddAsync(new Roles()
            {
                RolesName = model.RolesName
            });
        }

        public IQueryable<RolesDto> GetAllRoles()
        {
            return  _service.QueryAllAsync(false).Select(m=>new RolesDto()
            {
                RolesName = m.RolesName,
                Id = m.Id,
                CreateTime = m.CreateTime,
                IsRemove = m.IsRemove
            });
        }
    }
}