using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class CollectService:BaseService<Collect>,ICollectService
    {
        public CollectService() : base(new CSContext())
        {

        }
    }
}