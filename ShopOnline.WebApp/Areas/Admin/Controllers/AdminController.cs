using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admint
        private readonly IAdminManager _manager;

        private MsgResult _msg;
        public AdminController(IAdminManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// 加载admin数据集
        /// </summary>
        /// <returns></returns>
         [HttpGet]
        public async Task< ActionResult> AdminList()
        {
            var rolesList = await _manager.GetRoles().ToListAsync();
            ViewBag.RolesList = new SelectList(rolesList, "Id", "RolesName");
            return View();
        }
        [HttpGet]
        public  JsonResult GetAdminList(int page, int limit, string adminName, string rolesId, string createTime)
        {
            var data =  _manager.GetAllAdmin();

            if (!string.IsNullOrEmpty(adminName))
            {
                data = data.Where(m => m.AdminName.Contains(adminName));
            }
            if (!string.IsNullOrEmpty(rolesId))
            {
                data = data.Where(m => m.RolesId.ToString().Equals(rolesId));
            }
            if (!string.IsNullOrEmpty(createTime))
            {
                data = data.Where(m => m.CreateTime.ToString("yyyy-MM-dd").Equals(createTime));
            }

            var dataCount = data.Count();
            var newData = data.ToList().Skip((page-1) * limit).Take(limit);

            var jsonResult = new        
            {
                code = 0,
                count=dataCount,
                data=newData
            };

            return Json(jsonResult,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 新增管理员页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task< ActionResult> AddAdmin()
        {
            var data = await _manager.GetRoles().ToListAsync();
            ViewBag.RolesList = new SelectList(data, "Id", "RolesName");
            return View();
        }

        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="model">管理员对象</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddAdmin(AdminDto model)
        {
            _msg=new MsgResult();

            model.ImagePath = "/Upload/Admin/th1.png";

            var result = await _manager.InsertAdmin(model);

            if (result==1)
            {
                _msg.IsSuccess = true;
                _msg.Info = "新增成功";
            }
            else
            {
                _msg.IsSuccess = false;
                _msg.Info = "新增失败";
            }

            return Json(_msg);
        }

        [HttpGet]
        public async Task< ActionResult> UpdateAdmin(Guid id)
        {
            var admin = await _manager.QueryAdmin(id);
            var data = await _manager.GetRoles().ToListAsync();
            ViewBag.RolesList = new SelectList(data, "Id", "RolesName");
            return View(admin);
        }

        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase file)
        {
            if (file!=null&&!string.IsNullOrEmpty(file.FileName))
            {
                var newName = Guid.NewGuid().ToString("n") + file.FileName;
                var filePath = Server.MapPath("~/Upload/Admin/");
                file.SaveAs(Path.Combine(filePath,newName));
                var displayPath = "/Upload/Admin/" + newName;
                return Json(new { code = 0,data=displayPath,Info="添加成功" });
            }

            return Json(new{code=-1,msg="error",data=""} );
        }

        [HttpPost]
        public async Task<JsonResult> UpdateAdmin(AdminDto model,string imageUrl)
        {
            _msg=new MsgResult();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                 model.ImagePath = imageUrl;
            }

            var res = await _manager.UpdateAdmin(model);

            if (res==1)
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

        [HttpGet]
        public async Task< ActionResult> UpdateAdmins(Guid id)
        {
            var admin = await _manager.QueryAdmin(id);
            var data = await _manager.GetRoles().ToListAsync();
            ViewBag.RolesList = new SelectList(data, "Id", "RolesName");
            return View(admin);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateAdminState(string stateId,string adminId)
        {
            try
            {
                _msg = new MsgResult();
                var result = await _manager.UpdateAdminState(stateId, Guid.Parse(adminId));

                if (result == 1)
                {
                    _msg.IsSuccess = true;
                    _msg.Info = "操作成功";
                }
                else
                {
                    _msg.IsSuccess = false;
                    _msg.Info = "error";
                }

            }
            catch (Exception e)
            {
                LogHelper log = new LogHelper(typeof(AdminController));
                log.Error("修改管理员状态错误信息", new Exception(e.Message));
            }

            return Json(_msg, JsonRequestBehavior.AllowGet);
        }
    }
}