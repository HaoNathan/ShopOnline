﻿using System;
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
            var user = (UserDto)Session["User"];
            var result = await _manager.AddShoppingCart(new ShoppingCartDto()
            {
                UserId = user.Id,
                ProductId = Guid.Parse(id)
            });

            if (result == 1)
            {
                if (isBuy=="true")
                {
                    return RedirectToAction("Cart", "ShoppingCart");
                }
                else
                {
                    _msg=new MsgResult()
                    {
                        IsSuccess = true,
                        Info = "该商品已成功添加进您的购物车"
                    };
                }
            }

            return Json(_msg,JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> Cart()
        {
            var user =(UserDto)Session["User"];
           
            var card =await _manager.QueryShoppingCart(user.Id).ToListAsync();
            return View(card);
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