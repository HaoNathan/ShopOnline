using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class AdminService : BaseService<Admin>, IAdminService
    {
        public AdminService() : base(new CSContext())
        {

        }
    }
}