using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Bll;
using ShopOnline.IBll;
using ShopOnline.WebApp.Common;
using ShopOnlineTools;

namespace ShopOnline.WebApp.Areas.Admin.Controllers
{
    public class ProductAttributesController : Controller
    {
        // GET: Admin/ProductAttributes
        private IProductAttributesManager _manager;
        private MsgResult _msg;

        public ProductAttributesController(IProductAttributesManager manager)
        {
            _manager = manager;
        }

        /// <summary>
        /// 添加商品属性
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> AddAttributes(string sizeName, string colorName)
        {
            try
            {
                _msg = new MsgResult();

                if (await _manager.IsExist(sizeName))
                {
                    _msg.IsSuccess = false;
                    _msg.Info = "【" + sizeName + "】已存在";
                    return Json(_msg);
                }else if (await _manager.IsExistColor(colorName))
                {
                    _msg.IsSuccess = false;
                    _msg.Info = "【" + colorName + "】已存在";
                    return Json(_msg);
                }

                var result1 =await _manager.AddSize(sizeName);
                var result2 = await _manager.AddColor(colorName);

                if (result1==1&&result2==1)
                {
                    _msg.IsSuccess = true;
                    var color = await _manager.QueryColor(new Guid(),colorName);
                    var size = await _manager.QuerySize(new Guid(), sizeName);
                    _msg.Info = "新增成功";
                    _msg.Data = new {colorId=color.Id,sizeId=size.Id };
                }
                else
                {
                    _msg.IsSuccess = true;
                    _msg.Info = null;
                }

            }
            catch (Exception e)
            {
                LogHelper log = new LogHelper(typeof(ProductController));
                log.Error("添加商品属性错误", e);
            }

            return Json(_msg);
        }
    }
}