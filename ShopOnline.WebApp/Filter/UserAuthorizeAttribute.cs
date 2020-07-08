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
       
            //base.OnAuthorization(filterContext);
           
        
        public UserAuthorizeAttribute(string strLoginUrl = "~/Home/Index")
        {
            this._LoginUrl = strLoginUrl;
        }

        #region 字段
        //登录地址
        private string _LoginUrl = string.Empty;
        #endregion

        #region 属性

        #endregion


        /// <summary>
        /// 重写系统自带的授权认证方法
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {

                if (filterContext.HttpContext.Request.Cookies["userId"] != null &&
                    filterContext.HttpContext.Request.Cookies["imagePath"] != null)
                {
                    var user = new UserDto()
                    {
                        Id = Guid.Parse(filterContext.HttpContext.Request.Cookies["userId"].Value.ToString()),
                    };
                    filterContext.HttpContext.Session["User"] = user;
                }
                
            }
        }

    }
}