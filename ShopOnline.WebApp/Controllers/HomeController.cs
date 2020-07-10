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
        /// <summary>
        /// 大师匠心页面
        /// </summary>
 
        public ActionResult Master()
        {
            
            return View();

        }
        public async Task<ActionResult> Skincare()
        {
            IDictionary<string,object>dic=new Dictionary<string, object>();

            var data = await _manager.QueryProductByCategory(2, "【黑钥匙】护肤系列").Take(3).ToListAsync();
            var data2 =await _manager.QueryProductByCategory(2, "光钥新肌护肤系列").ToListAsync();
            var data3 =await _manager.QueryProductByCategory(2, "清洁防晒系列").ToListAsync();
            var data4 = await _manager.QueryProductByCategory(2, "男士综合护肤系列").ToListAsync();

            dic.Add("list1",data);
            dic.Add("list2", data2);
            dic.Add("list3", data3);
            dic.Add("list4", data4);

            return View(dic);

        }
        public async Task<ActionResult> Cosmetics()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            var data =await _manager.QueryProductByCategory(2, "唇部").ToListAsync();
            var data2 =await _manager.QueryProductByCategory(2, "面部").ToListAsync();
            var data3 =await _manager.QueryProductByCategory(2, "眼部").ToListAsync();

            dictionary.Add("list1", data);
            dictionary.Add("list2", data2);
            dictionary.Add("list3", data3);

            return View(dictionary);
       

        }

        public async Task<ActionResult> Perfume()
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();

            var data = await _manager.QueryProductByCategory(2, "女士香水系列").ToListAsync();
            var data2 = await _manager.QueryProductByCategory(2, "男士香水系列").ToListAsync();
           

            dictionary.Add("list1", data);
            dictionary.Add("list2", data2);
         

            return View(dictionary);
        }






    }
}