using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class ShoppingCartService:BaseService<ShoppingCart>,IShoppingCartService
    {
        public ShoppingCartService() : base(new CSContext())
        {

        }
    }
}