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
        public async Task< ActionResult> ProductList()
        {
            await GetCategoryList();

            return View();
        }

        [HttpGet]
        public JsonResult GetProductList(int page, int limit, string productName, string  firstCategoryId,string secondCategoryId, string createTime)
        {
            try
            {
                var data = _manager.GetAllProducts();

                if (!string.IsNullOrEmpty(productName)) data = data.Where(m => m.ProductName.Contains(productName));

                if (!string.IsNullOrEmpty(firstCategoryId))
                {
                    Guid category = Guid.Parse(firstCategoryId);
                    data = data.Where(m => m.FirstProductCategoryId.Equals(category));
                }
                if (!string.IsNullOrEmpty(secondCategoryId))
                {
                    Guid category = Guid.Parse(secondCategoryId);

                    data = data.Where(m => m.SecondProductCategoryId.Equals(category));
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
            catch (Exception e)
            {
                LogHelper log=new LogHelper(typeof(ProductController));
                log.Error("查询商品错误",e);
            }

            return Json(_msg=new MsgResult(){Info = "error"});
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

        [HttpPost]
        public async Task<JsonResult> UpdateProductState(Guid id,bool state)
        {
            try
            {
                var res = await _manager.UpdateProductState(id,state);
                if (res == 1)
                {
                    _msg = new MsgResult
                    {
                        Info = "修改成功",
                        IsSuccess = true
                    };
                }
                else
                {
                    _msg = new MsgResult
                    {
                        Info = "修改失败",
                        IsSuccess = false
                    };
                }
            }
            catch (Exception e)
            {
                LogHelper log = new LogHelper(typeof(ProductController));
                log.Error("修改商品错误", e);
            }

            return Json(_msg);
        }


        [HttpPost]
        [ValidateInput(false)]
        public async Task<JsonResult> UpdateProducts(ProductDto model)
        {
            try
            {
                var res = await _manager.EditProduct(model);
                if (res == 1)
                {
                    _msg = new MsgResult
                    {
                        Info = "修改成功",
                        IsSuccess = true
                    };
                }
                else
                {
                    _msg = new MsgResult
                    {
                        Info = "修改失败",
                        IsSuccess = false
                    };
                }
            }
            catch (Exception e)
            {
                LogHelper log=new LogHelper(typeof(ProductController));
                log.Error("修改商品错误",e);
            }

            return Json(_msg);
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