using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Filter
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
       
     
        /// <summary>
        /// 重写系统自带的授权认证方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Session["User"] == null&& !(filterContext.HttpContext.Session["User"] is UserDto))
            {

                if (filterContext.HttpContext.Request.Cookies["userId"] != null &&
                    filterContext.HttpContext.Request.Cookies["imagePath"] != null)
                {
                    var user = new UserDto()
                    {
                        Id = Guid.Parse(filterContext.HttpContext.Request.Cookies["userId"].Value),
                    };
                    filterContext.HttpContext.Session["User"] = user;
                }
               

            }
        }

    }
}