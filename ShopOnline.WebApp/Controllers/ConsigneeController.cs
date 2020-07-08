using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.IBll;
using ShopOnline.IDal;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Controllers
{
    /// <summary>
    /// 主要用于获取收件人信息和添加信息
    /// </summary>
    public class ConsigneeController : Controller
    {
        private readonly IUserDistributionManager _manager;
        private MsgResult _msg;

        public ConsigneeController(IUserDistributionManager manager)
        {
            _manager = manager;
        }
        // GET: Consignee
        [HttpPost]
        public async Task<JsonResult> GetConsigneeInfo()
        {
            var user = (UserDto) Session["User"];
            var result = await _manager.QueryUserDistribution(user.Id);
           
            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> AddConsigneeInfo(UserDistributionDto model)
        {
            _msg=new MsgResult();
            var user = (UserDto)Session["User"];
            model.UserId = user.Id;
            var result = await _manager.AddUserDistribution(model);

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
            return Json(_msg);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateConsigneeInfo(UserDistributionDto model)
        {
            _msg = new MsgResult();

            var result = await _manager.UpdateUserDistribution(model);
            if (result==1)
            {
                _msg.IsSuccess = true;
                _msg.Info = "修改成功";
            }
            else
            {
                _msg.IsSuccess = false;
                _msg.Info = "修改失败";
            }
            return Json(_msg);
        }
    }
}