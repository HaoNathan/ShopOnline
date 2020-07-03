using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private readonly IProductManager _manager;
        private MsgResult _msg;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public ActionResult ProductList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetProductList(int page, int limit, string productName, string categoryId)
        {
            var data = _manager.GetAllProducts();

            if (!string.IsNullOrEmpty(productName))
            {
                data = data.Where(m => m.ProductName.Contains(productName));
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                data = data.Where(m => m.FirstProductCategoryId.ToString().Equals(categoryId));
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
        public async Task< ActionResult> AddProduct()
        {
            await GetCategoryList();
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> UpdateProduct(Guid id)
        {
            await GetCategoryList();
            var data = await _manager.QueryProduct(id);
            return View(data);
        }

        public async Task  GetCategoryList()
        {
            var firstCategoryList = await _manager.GetFirstCategoryList().ToListAsync();
            var secondCategoryList = await _manager.GetSecondCategoryList().ToListAsync();
            var thirdCategoryList = await _manager.GetThirdCategoryList().ToListAsync();

            ViewBag.FirstCategoryList = new SelectList(firstCategoryList, "Id", "CategoryName");
            ViewBag.SecondCategoryList = new SelectList(secondCategoryList, "Id", "CategoryName");
            ViewBag.ThirdCategoryList = new SelectList(thirdCategoryList, "Id", "CategoryName");
        }

        [HttpPost]
        public JsonResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null && !string.IsNullOrEmpty(file.FileName))
            {
                var newName = Guid.NewGuid().ToString("n") + file.FileName;
                var filePath = Server.MapPath("~/Upload/Product/");
                file.SaveAs(Path.Combine(filePath, newName));
                var displayPath = "/Upload/Product/" + newName;
                return Json(new { code = 0, data = displayPath, Info = "添加成功" });
            }

            return Json(new { code = -1, msg = "error", data = "" });
        }
        [HttpPost]
        [ValidateInput(false)]
        public async Task<JsonResult> AddProduct(ProductDto model)
        {
            var result = await _manager.AddProduct(model);
            if (result==1)
            {
                _msg = new MsgResult
                {
                    Info = "新增成功",
                    IsSuccess = true
                };
            }
            else
            {
                _msg = new MsgResult
                {
                    Info = "新增成功",
                    IsSuccess = true
                };
            }

            return Json(_msg);
        }
        
    }
}