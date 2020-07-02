using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class RolesService:BaseService<Roles>,IRolesService
    {
        public RolesService() : base(new CSContext())
        {

        }
    }
}