using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace General.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        //[ViewPage]
        [Description("后台首页")]
        public ActionResult Index()
        {
            return Redirect("~/Backstage");
        }

        //public ActionResult Index(int id)
        //{

        //    ViewBag.id = id;
        //    return View(id);
        //    //return Redirect("~/Backstage");
        //}


        //public ActionResult Index(string id111)
        //{
        //    ViewBag.name = id111;
        //    return View(id111);
        //    //return Redirect("~/Backstage");
        //}

    }
}
