using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _manager;
        private MsgResult _msg;

        public UserController(IUserManager manager)
        {
            _manager = manager;
        }
        // GET: User
        
        [HttpGet]
        public ActionResult LoginRegister()
        {
            return View();
        }
        public ActionResult GetCaptcha()
        {
            string strImgCode = string.Empty;

            //获取验证码图片
            byte[] byteImg = PublicHelper.GetImageCode(out strImgCode);

            //保存验证码
            Session["ImageCode"] = strImgCode;

            return File(byteImg, "image/jpeg");
        }
        [HttpPost]
        public async Task<JsonResult> Login(string userName,string userPwd,string remember)
        {
            _msg=new MsgResult();
            var result = await _manager.UserLogin(userName, userPwd);
            if (result==null)
            {
                _msg.IsSuccess = false;
                _msg.Info = "账号或密码错误失败";
            }
            else
            {
                Session["User"] = result;
                _msg.IsSuccess = true;
                _msg.Info = "欢迎回来";
                _msg.RedirectUrl = Url.Action("Index", "Home");
            }
            return Json(_msg);
        }

        [HttpPost]
        public async Task<JsonResult> Register(UserDto model)
        {
            _msg = new MsgResult();

            try
            {
                var result = await _manager.AddUser(model);
                if (result == 1)
                {
                    _msg.IsSuccess = true;
                    _msg.Info = "注册成功,尝试登陆吧";
                }
                else
                {
                    _msg.IsSuccess = false;
                    _msg.Info = "注册失败";
                }
            }
            catch (Exception e)
            {
                LogHelper log=new LogHelper(typeof(UserController));
                log.Error("新增用户错误",e);
            }

            return Json(_msg);
        }
    }
}