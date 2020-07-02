using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class SecondCategoryService:BaseService<SecondProductCategory>,ISecondCategoryService
    {
        public SecondCategoryService() : base(new CSContext())
        {

        }
    }
}