using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        private readonly IOrderInfoManager _manager;
        private MsgResult _msg;

        public OrderController(IOrderInfoManager manager)
        {
            _manager = manager;
        }

        public async Task<ActionResult> OrderList()
        {
            var user = (UserDto)Session["User"];
            IDictionary<string,object>dc=new Dictionary<string, object>();
            var distribution = _manager.QueryOrderDistribution(user.Id);
            var products =await  _manager.GetShoppingCarts(user.Id).ToListAsync();
            int money=0;
            foreach (var item in products)
            {
                money += item.Number * Convert.ToInt32(item.ProductPrice);
            }

            dc.Add("distribution", distribution);
            dc.Add("ProductList",products);
            dc.Add("money",money);

            return View(dc);
        }
        [HttpPost]
        public async Task<JsonResult> AddOrder(OrderInfoDto model)
        {
            var user = (UserDto)Session["User"];

            model.UserId = user.Id;

            var  result=await _manager.AddOrder(model);

            if (result == 1)
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "购买成功"
                };

                await _manager.DeleteShoppingCard(user.Id);

            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = false,
                    Info = "购买失败"
                };
            }
            return Json(_msg);
        }
    }
}