using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class ProductCommentService:BaseService<ProductComment>,IProductCommentService
    {
        public ProductCommentService() : base(new CSContext())
        {

        }
    }
}