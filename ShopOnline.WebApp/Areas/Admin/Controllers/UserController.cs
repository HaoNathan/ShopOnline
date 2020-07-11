using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.Dal;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnline.WebApp.Filter;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    [AdminAuthorize()]
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
        public async Task<JsonResult> UpdateUserState(string id ,bool state)
        {
            var result = await _manager.UpdateUserState(Guid.Parse(id), state);
            if (result==1)
            {
                _msg=new MsgResult()
                {
                    IsSuccess = true,
                    Info = "修改状态成功"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "修改状态成功"
                };
            }
            return Json(_msg);
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

        public async Task<ActionResult> UpdateUserInfo(string id)
        {
            var user = await _manager.QueryUser(Guid.Parse(id));

            return View(user);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateUserInfo(UserDto model,string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                model.ImagePath = imageUrl;
            }

            var result = await _manager.EditUser(false,model);

            if (result == 1)
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "修改状态成功"
                };
            }
            else
            {
                _msg = new MsgResult()
                {
                    IsSuccess = true,
                    Info = "修改状态成功"
                };
            }
            return Json(_msg);
        }



    }
}