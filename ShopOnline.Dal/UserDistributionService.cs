using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class UserDistributionService:BaseService<UserDistribution>,IUserDistributionService
    {
        public UserDistributionService() : base(new CSContext())
        {

        }
    }
}