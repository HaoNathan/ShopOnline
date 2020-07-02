using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.WebApp.Common
{
    public class MsgResult
    {
        public bool IsSuccess { get; set; } = false;
        public string RedirectUrl { get; set; }
        public object Data { get; set; }
        public string Info { get; set; }
    }
}