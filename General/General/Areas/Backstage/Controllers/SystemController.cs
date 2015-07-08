using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using General.Model;
using General.BLL;
using System.Data.Linq;
using System.Data.Common;
using System.Data.SqlClient;
using General.DAL;
using System.Xml.Linq;
using General.Common;

namespace General.Areas.Backstage.Controllers
{
    [Authorize]
    public class SystemController : BaseController
    {

        private SystemMenuService _SystemMenuService = new SystemMenuService();
        //
        // GET: /Backstage/System/

        public ActionResult Index()
        {
            return View();
        }

        #region 系统菜单
        /// <summary>
        /// 获取菜单 默认
        /// </summary>
        /// <param name="menuName"></param>
        /// <returns></returns>
        public ActionResult Menu(string menuName)
        {
            return View(GetMenuList(menuName));
        }

        /// <summary>
        /// 获取菜单 ajax
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenu(string menuName)
        {
            List<SystemMenu> result = GetMenuList(menuName);
            DataGrid grid = new DataGrid();
            grid.total = result.Count;
            grid.rows = result.Select(m => new
            {
                Id = m.Id,
                Title = m.Title,
                Code = m.Code,
                Url = m.Url,
                Depth = m.Depth,
                Icon = m.BIcon,
                ParentId = m.Parent == null ? "" : m.Parent.Id
            }).ToList();

            return Json(grid, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取菜单 执行
        /// </summary>
        /// <param name="MenuName"></param>
        /// <returns></returns>
        public List<SystemMenu> GetMenuList(string MenuName)
        {
            List<SystemMenu> _MenuList = new List<SystemMenu>();
            List<SystemMenu> _MenuList_result = new List<SystemMenu>();


            if (!string.IsNullOrEmpty(MenuName))
                _MenuList = _SystemMenuService.GetWhere(m => m.Title == MenuName).ToList();
            else
                _MenuList = _SystemMenuService.GetAll().ToList();

            foreach (SystemMenu m in _MenuList)
            {
                if (!_MenuList_result.Contains(m))
                {
                    _MenuList_result.Add(m);
                    if (m.Children != null && m.Children.Count > 0)
                    {
                        _MenuList_result.AddRange(m.Children);
                    }
                }
            }
            return _MenuList_result;
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult InitSystemMenu()
        {
            try
            {
                XElement xml = XElement.Load(Server.MapPath("~/") + "App_Data/TreeMenu.xml");
                //SystemMenu menu = new SystemMenu();
                init_list(xml);
                return Json(new { Code = "1", msg = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { Code = "1", msg = error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 初始化菜单递归
        /// </summary>
        /// <param name="xml"></param>
        private void init_list(XElement xml)
        {
            foreach (var item in xml.Elements())
            {
                if (item.Attribute("Code") != null && item.Attribute("Code").Value != "")
                {
                    string code = item.Attribute("Code").Value;
                    SystemMenu _menu = _SystemMenuService.GetWhere(m => m.Code.ToLower() == code.ToLower()).FirstOrDefault();
                    if (_menu != null)
                    {
                        //修改
                        init(item, _menu);
                        _SystemMenuService.Edit(_menu);
                    }
                    else
                    {
                        //添加
                        _menu = new SystemMenu();
                        init(item, _menu);
                        _SystemMenuService.Add(_menu);
                    }
                    _SystemMenuService.Save();
                    init_list(item);
                }
            }
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="item"></param>
        /// <param name="_menu"></param>
        public void init(XElement item, SystemMenu _menu)
        {
            _menu.Title = item.Attribute("Title") == null ? "" : item.Attribute("Title").Value;
            _menu.EIcon = item.Attribute("EasyuiIcon") == null ? "" : item.Attribute("EasyuiIcon").Value;
            _menu.BIcon = item.Attribute("BootstrapIcon") == null ? "" : item.Attribute("BootstrapIcon").Value;
            _menu.Url = item.Attribute("Url") == null ? "" : item.Attribute("Url").Value;
            _menu.Code = item.Attribute("Code") == null ? "" : item.Attribute("Code").Value;
            string parterCode = item.Parent == null ? "" : item.Parent.Attribute("Code") == null ? "" : item.Parent.Attribute("Code").Value;

            SystemMenu _menuParter = _SystemMenuService.GetWhere(m => m.Code == parterCode).FirstOrDefault();
            if (_menuParter != null)
            {
                _menu.Depth = _menuParter.Depth + 1;
                _menu.Path = _menuParter.Path + _menu.Id + ",";
                _menu.Parent = _menuParter;
            }
            else
            {
                _menu.Depth = 1;
                _menu.Path = _menu.Id + ",";
            }

        }
        #endregion

        /// <summary>
        /// 角色
        /// </summary>
        /// <returns></returns>
        public ActionResult Role()
        {

            return View();
        }

        [HttpGet]
        public ActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoleAdd(string RoleName, string Description)
        {
            return Json(new { Code = RoleName + Description }, JsonRequestBehavior.AllowGet);
        }
    }
}
