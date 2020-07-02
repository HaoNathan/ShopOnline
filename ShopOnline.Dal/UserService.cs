using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class UserService:BaseService<User>,IUserService
    {
        public UserService() : base(new CSContext())
        {

        }
    }
}