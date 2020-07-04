using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class OrderService:BaseService<OrderInfo>,IOrderService
    {
        private OrderService() : base(new CSContext())
        {

        }
    }
}