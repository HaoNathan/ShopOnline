using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.WebApp.Filter;

namespace ShopOnline.WebApp.Controllers
{
    
    [UserAuthorize()]
    public class HomeController : Controller
    {
        private readonly IProductManager _manager;

        public HomeController(IProductManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// 首页推荐商品
        /// </summary>
        /// <returns>泛型字典</returns>
        public async Task<ActionResult> Index()
        {
            List<ProductDto> list = new List<ProductDto>();
            List<ProductDto> list2 = new List<ProductDto>();
            List<ProductDto> list3 = new List<ProductDto>();
            List<ProductDto> list4 = new List<ProductDto>();

            list = await _manager.QueryProductByCategory(2, "唇部").Take(3).ToListAsync();
            list2 = await _manager.QueryProductByCategory(2, "面部").Take(3).ToListAsync();
            list3 = await _manager.QueryProductByCategory(2, "女士香水系列").Take(3).ToListAsync();
            list4 = await _manager.QueryProductByCategory(2, "限量礼盒").Take(3).ToListAsync();

            IDictionary<string, object> test = new Dictionary<string, object>();
            
            test.Add("T1", list);
            test.Add("T2", list2);
            test.Add("T3", list3);
            test.Add("T4", list4);
            return View(test);

        }





    }
}