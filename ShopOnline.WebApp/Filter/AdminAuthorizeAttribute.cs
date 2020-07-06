using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnline.Dto;
using ShopOnline.WebApp.Common;

namespace ShopOnline.WebApp.Filter
{
    public class AdminAuthorizeAttribute: AuthorizeAttribute
    {
        public AdminAuthorizeAttribute(string strLoginUrl = "~/Admin/AdminLogin/Login")
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
            //base.OnAuthorization(filterContext);

            #region 排除验证
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }
            #endregion

            #region 授权认证
            var varHttpContext = filterContext.HttpContext;

            //判断Session中是否有数据
            if (varHttpContext.Session["Admin"] == null || !(varHttpContext.Session["Admin"] is AdminDto))
            {
                //判断请求的类型 Ajax请求,XMLHttpRequest
                if (varHttpContext.Request.IsAjaxRequest())
                {
                    //中断
                    filterContext.Result = new JsonResult()
                    {
                        Data = new MsgResult()
                        {
                            IsSuccess = false,

                            Info = "登录过期！"
                        }
                    };
                }
                else
                {
                    varHttpContext.Session["Admin"] = varHttpContext.Request.Url.AbsoluteUri;

                    //设置Result的值，请求立即终止，立即跳转中断器
                    filterContext.Result = new RedirectResult(this._LoginUrl);
                }
            }
            else
            {
                return;
            }
            #endregion
        }
    }
}