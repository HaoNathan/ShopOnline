using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly  IProductManager _manager;
        private MsgResult _msg;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }
        // GET: Product
        [HttpGet]
        public async Task< ActionResult> GetProductList(string searchName,int index)
        {
            if (index==1)
            {
                var data = await _manager.QueryProduct(searchName).ToListAsync();
                return View(data);

            }
            else
            {
                var data = await _manager.QueryProductByCategory(searchName).ToListAsync();
                return View(data);

            }

        }
        
        [HttpGet]
        public async Task<ActionResult>ProductInfo(string id)
        {
            var data = await _manager.QueryProduct(Guid.Parse(id));
            return View(data);
        }
    }
}