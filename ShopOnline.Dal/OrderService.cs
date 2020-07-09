using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class OrderService:BaseService<Order>,IOrderService
    {
        public OrderService() : base(new CSContext())
        {

        }
    }
}