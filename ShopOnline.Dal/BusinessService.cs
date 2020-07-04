using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class BusinessService:BaseService<Business>,IBusinessService
    {
        public BusinessService() : base(new CSContext())
        {

        }
    }
}