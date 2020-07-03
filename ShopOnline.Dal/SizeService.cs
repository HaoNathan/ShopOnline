using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class SizeService:BaseService<Size>,ISizeService
    {
        public SizeService() : base(new CSContext())
        {

        }
    }
}