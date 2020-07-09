using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
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
        /// <summary>
        /// 个人信息及订单查看
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> OrderList()
        {
            var user = (UserDto)Session["User"];
            IUserManager manager=new UserManager(new UserService());
            var member= await manager.QueryUser(user.Id);
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
            dc.Add("member", member.IsMember);

            return View(dc);
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
                var orderInfo = await _manager.QueryAllOrder(false)
                    .Where(m => m.UserId.Equals(user.Id))
                    .OrderByDescending(m => m.CreateTime).FirstOrDefaultAsync();

                IOrderManager manager = new OrderManager(new OrderService());

                var data =await _manager.GetShoppingCarts(user.Id).ToListAsync();

                if (orderInfo != null)
                {
                    foreach (var item in data)
                    {
                        await manager.AddOrder(orderInfo.PayState,new OrderDto()
                        {
                            OrderId = orderInfo.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Number.ToString(),
                            UnitPrice = item.ProductPrice

                        });
                    }
                }

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

        [HttpPost]
        public async Task<JsonResult> UpdatePayState(string id)
        {
            var result = await _manager.UpdateOrderPayState(Guid.Parse(id));
            if (result==1)
            {
                _msg=new MsgResult()
                {
                    IsSuccess = true,
                    Info = "订单支付状态以成功更新"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = false,
                    Info = "订单支付状态更新失败"
                };
            }

            return Json(_msg);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteOrder(string id)
        {
            var result = await _manager.DeleteOrder(Guid.Parse(id));
            if (result == 1)
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "订单已成功移除"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = false,
                    Info = "订单支移除失败"
                };
            }
            return Json(_msg);
        }
    }
}