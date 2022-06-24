using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CoreMVCCategoryProduct.Controllers
{
    public class BaseController : Controller
    {
        protected string CookieKey = "CultureInfo";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string CultureName = "";
            if (HttpContext.Request.Cookies.Keys.Contains(CookieKey))    //看Cookie是否有儲存使用者之前選取的語系
            {
                CultureName = HttpContext.Request.Cookies[CookieKey];
            }
            else
            {
                CultureName = Request.Headers["Accept-Language"][0].Split(",")[0];  //最後看瀏覽器的喜好語言設定
                SetCookie(CultureName);
            }
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CultureName);
            base.OnActionExecuting(context);
        }
        public ActionResult SetLanguage(string CultureName)
        {
            SetCookie(CultureName);
            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);
            //return RedirectToAction("Index", "Products");
        }

        private void SetCookie(string CultureName)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(30);
            HttpContext.Response.Cookies.Delete(CookieKey);
            HttpContext.Response.Cookies.Append(CookieKey, CultureName, option);
        }
    }
}