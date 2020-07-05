using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ProductCategoryThirdController : Controller
    {
        // GET: Admin/ProductCategoryThird
        private readonly IThirdCategoryManager _manager;
        private MsgResult _msg;
        private readonly LogHelper _log = new LogHelper(typeof(ProductCategoryController));
        public ProductCategoryThirdController(IThirdCategoryManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public ActionResult ThirdCategoryList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetThirdCategoryList(int page, int limit, string categoryName, string createTime)
        {
            var data = _manager.GetAllCategory();

            if (!string.IsNullOrEmpty(categoryName))
            {
                data = data.Where(m => m.CategoryName.Contains(categoryName));
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
        [HttpGet]
        public ActionResult AddThirdCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddThirdCategory(string categoryName)
        {
            _msg = new MsgResult();
            try
            {
                var result = await _manager.AddCategory(categoryName);
                if (result == 1)
                {
                    _msg.IsSuccess = true;
                    _msg.Info = "添加成功";
                }
                else
                {
                    _msg.IsSuccess = false;
                    _msg.Info = "添加失败";
                }
            }
            catch (Exception e)
            {
                _log.Error("添加以及商品分类错误", e);
            }

            return Json(_msg);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateCategoryState(string id, bool state)
        {
            var result = await _manager.EditCategoryState(Guid.Parse(id), state);

            _msg = new MsgResult();

            switch (result)
            {
                case 1:
                    _msg.IsSuccess = true;
                    _msg.Info = "修改成功";
                    break;
                default:
                    _msg.IsSuccess = false;
                    _msg.Info = "修改失败";
                    break;
            }

            return Json(_msg);
        }
    }
}