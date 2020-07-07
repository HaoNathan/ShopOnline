using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private  IProductManager _manager;
        private MsgResult _msg;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }
        // GET: Product
        public ActionResult GetProductList()
        {

            return View();
        }
    }
}