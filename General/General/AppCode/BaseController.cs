using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace General.AppCode
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [AuthorizeFilterAttribute]
    public class BaseController : Controller
    {
        public BaseController()
        {

            //string path = Request.Path;
            //Reqest();
        }

        public void Reqest()
        {
            //【1】获取 完整url 
            //（协议名+域名+虚拟目录名+文件名+参数）
            string url = Request.Url.ToString();
            //【2】获取 虚拟目录名+页面名+参数：
            url = Request.RawUrl;
            //(或 
            url = Request.Url.PathAndQuery;
            //【3】获取 
            //虚拟目录名+页面名：
            url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            //(或 
            url = System.Web.HttpContext.Current.Request.Path;
            //【4】获取 域名：
            url = System.Web.HttpContext.Current.Request.Url.Host;
            //【5】获取 参数：
            url = System.Web.HttpContext.Current.Request.Url.Query;
            //【6】获取 端口：
            //Request.Url.Port


            ////二、当前controller、action的获取
            //RouteData.Route.GetRouteData(this.HttpContext).Values["controller"];
            //RouteData.Route.GetRouteData(this.HttpContext).Values["action"];
            ////或
            //RouteData.Values["controller"];
            //RouteData.Values["action"];

            ////如果在视图中可以用
            //ViewContext.RouteData.Route.GetRouteData(this.Context).Values["controller"];
            //ViewContext.RouteData.Route.GetRouteData(this.Context).Values["action"];
            ////或
            //ViewContext.RouteData.Values["controller"];
            //ViewContext.RouteData.Values["action"];
        }

        //protected override void Oninit

        /// <summary>
        /// 获取用户ID
        /// </summary>
        protected string SigninId
        {
            get
            {
                return User == null ? null : (User.Identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray())[0];
            }
        }
        /// <summary>
        /// 获取用户昵称
        /// </summary>
        protected string SigninName
        {
            get
            {
                return User == null ? null : (User.Identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray())[1];
            }
        }
        /// <summary>
        /// 获取用户邮箱
        /// </summary>
        protected string SigninEmail
        {
            get
            {
                return User == null ? null : (User.Identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray())[2];
            }
        }

    }
}