using General.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using General.Model;
using General.BLL;
using General.AppCode;

using System.Reflection;
using System.Text.RegularExpressions;
using System.ComponentModel;


namespace General.Areas.Backstage.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        /// <summary>
        /// 账户服务
        /// </summary>
        private UserInfoService _UserInfoService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public HomeController()
        {
            _UserInfoService = new UserInfoService();
        }

        //
        // GET: /Backstage/Home/

        


        [ViewPageAttribute]
        public ActionResult Index()
        {
            //Reqest();

            //XElement root = XElement.Load(Server.MapPath("~/") + "App_Data\\TreeMenu.xml");
            ViewBag.SigninName = SigninName;
            ViewBag.SigninId = SigninId;
            ViewBag.SigninEmail = SigninEmail;
            //1获取当前所有权限菜单
            ViewBag.ActionMenu = "";
            if (SigninId != "0")
            {
                //如果不是超级管理员，获取当前用户
                UserInfo user = _UserInfoService.GetKey(SigninId);
                ViewBag.ActionMenu = string.Join(";", user.Role.Menu.Select(m => m.Code).ToArray());
            }
            Session.Add("ActionMenu", ViewBag.ActionMenu);


            //long total = 0;
            //QueryActionPlist("s", 1, 20, out total);
            return View();
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






    }
}
