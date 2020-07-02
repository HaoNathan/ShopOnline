using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesManager _manager;
        private MsgResult msg;
        public RolesController(IRolesManager manager)
        {
            _manager = manager;
        }
        // GET: Admin/Roles
        [HttpGet]
        public ActionResult RolesList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddRoles()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetRolesList()
        {
                var data = _manager.GetAllRoles();
                var dataCount = data.Count();

                var jsonResult = new
                {
                    code = 0,
                    count = dataCount,
                    data
                };

                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public async Task<ActionResult> AddRoles(string rolesName)
        {
            var result = await _manager.AddRoles(new RolesDto()
            {
                RolesName = rolesName
            });
            msg = new MsgResult();

            if (result == 1)
            {
                msg.IsSuccess = true;
                msg.Info = "新增成功";
            }

            return Json(msg);
        }
    }
}