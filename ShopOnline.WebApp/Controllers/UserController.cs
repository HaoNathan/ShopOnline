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
        public async Task<ActionResult> LoginRegister()
        {
            try
            {
                var userId =Request.Cookies["userId"].Value;
                var user = await _manager.QueryUser(Guid.Parse(userId));
                return View(user);
            }
            catch (Exception e)
            {
                    return View();
            }
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
            userPwd=new Md5().MD5Encrypt(userPwd);
            var result = await _manager.UserLogin(userName, userPwd);
            if (result==null)
            {
                _msg.IsSuccess = false;
                _msg.Info = "账号或密码错误失败";
            }
            else
            {
                if (remember=="on")
                {
                    HttpCookie cookie = new HttpCookie("userId");
                    cookie.Value = result.Id.ToString();
                    Response.AppendCookie(cookie);
                }
                else
                {
                    Session["User"] = result;
                }
                _msg.IsSuccess = true;
                _msg.Info = "欢迎回来";
                _msg.RedirectUrl = Url.Action("Index", "Home");
            }
            return Json(_msg);
        }

        [HttpPost]
        public async Task<JsonResult> Register(UserDto model,string codeImage)
        {
            _msg = new MsgResult();
            var captcha = Session["ImageCode"].ToString();
            if (!captcha.Equals(codeImage))
            {
                _msg.IsSuccess = false;
                _msg.Info = "验证码错误";
                return Json(_msg);
            }

            model.UserPassword = new Md5().MD5Encrypt(model.UserPassword);
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

        [HttpPost]
        public async Task<JsonResult> CheckUserName(string userName)
        {
            _msg=new MsgResult();
            var result = await _manager.IsExistUser(userName);
            if (result)
            {
                _msg.IsSuccess = true;
                _msg.Info = "该昵称已存在";
            }
            return Json(_msg);
        }
    }
}