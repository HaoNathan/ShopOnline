using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class ProductService:BaseService<Product>,IProductService
    {
        public ProductService() : base(new CSContext())
        {

        }
    }
}