using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;

namespace ShopOnline.WebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private readonly IOrderInfoManager _manager;

        public OrderController(IOrderInfoManager manager)
        {
            _manager = manager;
        }

        public async Task<ActionResult> OrderList(string productId)
        {
            var product = await _manager.GetProduct(Guid.Parse(productId));
            return View(product);
        }
    }
}