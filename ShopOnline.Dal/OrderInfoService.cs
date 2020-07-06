using ShopOnline.IDal;
using ShopOnline.Model;

namespace ShopOnline.Dal
{
    public class OrderInfoService:BaseService<OrderInfo>,IOrderInfoService
    {
        public OrderInfoService() : base(new CSContext())
        {

        }
    }
}