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
using ShopOnline.WebApp.Filter;

namespace ShopOnline.WebApp.Controllers
{
    [UserAuthorize]
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        private readonly IShoppingCartManager _manager;
        private MsgResult _msg;
        public ShoppingCartController(IShoppingCartManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// 添加进购物车
        /// </summary>
        /// <param name="id">商品Id</param>
        /// <param name="isBuy">是否立即购买</param>
        /// <returns></returns>
        public async Task<ActionResult> AddCart(string id,string isBuy)
        {
            try
            {
                var user = (UserDto)Session["User"];

                var shopCart = _manager.IsExist(Guid.Parse(id));

                if (shopCart == null)
                {
                    var result = await _manager.AddShoppingCart(new ShoppingCartDto()
                    {
                        UserId = user.Id,
                        ProductId = Guid.Parse(id)
                    });

                    if (result == 1)
                    {
                        if (isBuy == "true")
                            return RedirectToAction("Cart", "ShoppingCart");
                        else
                            _msg = new MsgResult()
                            {
                                IsSuccess = true,
                                Info = "该商品已成功添加进您的购物车"
                            };
                    }
                }
                else
                {
                    var res = await _manager.UpdateShoppingCart(shopCart);

                    if (res == 1)
                    {
                        _msg = new MsgResult()
                        {
                            IsSuccess = true,
                            Info = "该商品已存在于您的购物车,已为您更新数量"
                        };
                    }
                    else
                    {
                        _msg = new MsgResult()
                        {
                            IsSuccess = false,
                            Info = "更新数量失败"
                        };
                    }
                }

            }
            catch (Exception e)
            {
               return RedirectToAction("Index", "Home");
            }

            return Json(_msg,JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Cart()
        {
            try
            {
                var user = (UserDto)Session["User"];

                var card = await _manager.QueryShoppingCart(user.Id).ToListAsync();
                return View(card);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public async Task<JsonResult> UpdateCartState(string id)
        {
            var result = await _manager.DeleteShoppingCart(Guid.Parse(id));
            if (result==1)
            {
                _msg=new  MsgResult()
                {
                    IsSuccess = true,
                    Info = "移除成功"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = false,
                    Info = "移除失败"
                };
            }
            return Json(_msg);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateCartNum(string id,int number)
        {
            var result = await _manager.UpdateShoppingCart(Guid.Parse(id),number);
            if (result == 1)
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "修改成功"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = false,
                    Info = "修改失败"
                };
            }
            return Json(_msg);
        }
    }
}