using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnline.WebApp.Filter;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Controllers
{
    [UserAuthorize]
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
        public  ActionResult LoginRegister()
        {
            return View();
        }

        
        [HttpGet]
        public async Task< ActionResult> EditUserInfo()
        {
            var data =(UserDto)Session["User"];
            if (data==null)
            {
                return RedirectToAction("index", "Home");
            }
            var user = await _manager.QueryUser(data.Id);
            return View(user);
        }
        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                var newName = Guid.NewGuid().ToString("n") + file.FileName;
                var filePath = Server.MapPath("~/Upload/User/");
                file.SaveAs(Path.Combine(filePath, newName));
                var displayPath = "/Upload/User/" + newName;
                return Json(new { code = 0, data = displayPath, Info = "添加成功" });
            }

            return Json(new { code = -1, msg = "error", data = "" });
        }
        [HttpPost]
        public async Task<JsonResult> EditUserInfo(UserDto model)
        {
            _msg= new MsgResult();
            model.UserPassword = new Md5().MD5Encrypt(model.UserPassword);
            var result = await _manager.EditUser(model);
            if (result==1)
            {
                _msg.IsSuccess = true;
                _msg.Info = "修改成功";
            }
            else
            {
                _msg.IsSuccess = false;
                _msg.Info = "修改失败";
            }
            return Json(_msg);
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
                    cookie.Expires=DateTime.Now.AddDays(30);
                    Response.AppendCookie(cookie);

                    HttpCookie cookie2 = new HttpCookie("imagePath");
                    cookie2.Value = result.ImagePath;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.AppendCookie(cookie2);

                    Session["User"] = result;
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