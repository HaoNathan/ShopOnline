using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class ThirdCategoryService:BaseService<ThirdProductCategory>,IThirdCategoryService
    {
        public ThirdCategoryService() : base(new CSContext())
        {

        }
    }
}