﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _manager;
        private MsgResult _msg;

        public UserController(IUserManager manager)
        {
            _manager = manager;
        }

        // GET: Admin/User
        [HttpGet]
        public ActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUserList(int page, int limit, string userName, string phone, string createTime)
        {

            var data = _manager.GetAllUser();

            if (!string.IsNullOrEmpty(userName)) data = data.Where(m => m.UserName.Contains(userName));

            if (!string.IsNullOrEmpty(phone))
            {
                data = data.Where(m => m.Phone.Equals(phone));
            }

            if (!string.IsNullOrEmpty(createTime))
            {
                var time = DateTime.Parse(createTime);
                data = data.Where(m => m.CreateTime > time);
            }

            var dataCount = data.Count();
            var newData = data.ToList().Skip((page - 1) * limit).Take(limit);


            var jsonResult = new
            {
                code = 0,
                count = dataCount,
                data = newData
            };

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }




        [HttpPost]
        public JsonResult UpdateUserState()
        {
            return Json(null);
        }
    }
}