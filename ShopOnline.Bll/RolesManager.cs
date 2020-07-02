using System.Threading.Tasks;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Bll
{
    public class RolesManager:IRolesManager
    {
        private readonly IRolesService _manager;

        public RolesManager(IRolesService manager)
        {
            _manager = manager;
        }


        public async Task<int> AddRoles(RolesDto model)
        {
            return await _manager.AddAsync(new Roles()
            {
                RolesName = model.RolesName
            });
        }

    }
}