using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class FirstCategoryService:BaseService<FirstProductCategory>,IFirstCategoryService
    {
        public FirstCategoryService() : base(new CSContext())
        {

        }
    }
}