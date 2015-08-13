using System.Web;
using System.Web.Optimization;

namespace General.Web
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //mvc 4 解除 过滤 .MIN.JS 文件
            BundleTable.Bundles.IgnoreList.Clear();
            BundleTable.Bundles.IgnoreList.Ignore(".min.js", OptimizationMode.Always);
            //自定义后台JS
            bundles.Add(new ScriptBundle("~/Compression/js/AppBackstage").Include(
                        "~/Content/AppBackstage.js"));
            //jQuery
            bundles.Add(new ScriptBundle("~/Compression/js/jquery").Include(
                        "~/Scripts/UI/Bootstrap/js/jquery-2.0.3.min.js"));//jquery-1.11.1.min.js

            //jQuery 表单验证
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Plug-JS/jqueryValidate/jquery.unobtrusive*",
                        "~/Scripts/Plug-JS/jqueryValidate/jquery.validate*"));
            // 后台 bootstrap ui 
            bundles.Add(new ScriptBundle("~/Compression/js/Bootstrap").Include(
                        "~/Scripts/UI/Bootstrap/js/bootstrap.min.js",//bootstrap.*
                        "~/Scripts/UI/Bootstrap/js/generalAdmin.min.js"));
            //后台CSS
            bundles.Add(new StyleBundle("~/Compression/css/Bootstrap").Include(
                "~/Scripts/UI/Bootstrap/css/bootstrap.min.css",
                "~/Scripts/UI/Bootstrap/css/font-awesome.min.css",
                "~/Scripts/UI/Bootstrap/css/weather-icons.min.css",
                "~/Scripts/UI/Bootstrap/css/fontsCss.css",
                "~/Scripts/UI/Bootstrap/css/generalAdmin.min.css"));

            #region 作废
            ////Easy ui JS
            //bundles.Add(new ScriptBundle("~/Compression/js/easyui").Include(
            //            "~/Scripts/Plug-UI/Easyui/jquery.easyui.js",
            //            "~/Scripts/Plug-UI/Easyui/locale/easyui-lang-zh_CN.js"));
            ////Easy ui CSS
            //bundles.Add(new StyleBundle("~/Compression/css/easyui").Include("~/Scripts/Plug-UI/Easyui/themes/icon.css"));
            #endregion
        }
    }
}