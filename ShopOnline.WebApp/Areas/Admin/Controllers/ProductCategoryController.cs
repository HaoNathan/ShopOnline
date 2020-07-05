using System;
using System.Collections.Generic;
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
    public class ProductCategoryController : Controller
    {
        private readonly IFirstCategoryManager _manager;
        private MsgResult _msg;
        private readonly LogHelper _log=new LogHelper(typeof(ProductCategoryController));
        public ProductCategoryController(IFirstCategoryManager manager)
        {
            _manager = manager;
        }
        // GET: Admin/ProductCategory
        [HttpGet]
        public ActionResult FirstCategoryList()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetFirstCategoryList(int page, int limit, string categoryName, string createTime)
        {
                var data = _manager.GetAllCategory();

                if (!string.IsNullOrEmpty(categoryName))
                {
                    data = data.Where(m => m.CategoryName.Contains(categoryName));
                }
               
                if (!string.IsNullOrEmpty(createTime))
                {
                    var time= DateTime.Parse(createTime);
                    data = data.Where(m => m.CreateTime>time);
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
        public ActionResult AddFirstCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddFirstCategory(string categoryName)
        {
            _msg=new  MsgResult();
            try
            {
                var result = await _manager.AddCategory(categoryName);
                if (result==1)
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


        public async Task<JsonResult> UpdateProductState(string id,bool state)
        {
            try
            {
                _msg=new MsgResult();
                var result = await _manager.EditCategoryState(Guid.Parse(id), state);

                switch (result)
                {
                    case 1:
                        _msg.IsSuccess = true;
                        _msg.Info = "修改状态成功";
                        break;
                    default:
                        _msg.IsSuccess = false;
                        _msg.Info = "修改状态失败";
                        break;
                }
            }
            catch (Exception e)
            {
                LogHelper log=new LogHelper(typeof(ProductCategoryController));
                log.Error("修改一级商品类别错误",e);
            }

            return Json(_msg);

        }




    }
}