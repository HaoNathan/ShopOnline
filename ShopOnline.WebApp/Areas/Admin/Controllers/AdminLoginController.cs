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

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: Admin/AdminLogin
        private readonly IAdminManager _manager;

        private MsgResult _msg;
        public AdminLoginController(IAdminManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminDto model)
        {
            _msg = new MsgResult();
            var data =  _manager.AdminLogin(model);

            if (data==null)
            {
                _msg.IsSuccess = false;
                _msg.Info = "用户名或密码错误";
                return Json(_msg);
            }

            _msg.Info = "正在为您跳转";
            _msg.IsSuccess = true;
            Session["Admin"] = data;
            return Json(_msg);


        }

    }
}