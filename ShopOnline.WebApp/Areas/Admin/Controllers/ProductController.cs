using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product

        [HttpGet]
        public ActionResult ProductList()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetProductList(int limit)
        {
            return Json(null);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public JsonResult AddProduct(ProductDto model)
        {
            return Json(null);
        }
    }
}