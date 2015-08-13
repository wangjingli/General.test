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
using Webdiyer.WebControls.Mvc;
using System.Linq.Expressions;
using General.Common.LinqHelper;
using General.AppCode;
using System.ComponentModel;


namespace General.Areas.Backstage.Controllers
{




    [Authorize]
    public class SystemController : BaseController
    {
        /// <summary>
        /// 系统菜单业务类
        /// </summary>
        private SystemMenuService _SystemMenuService = new SystemMenuService();
        /// <summary>
        /// 系统按钮业务类
        /// </summary>
        private SystemButtonService _SystemButtonService = new SystemButtonService();
        /// <summary>
        /// 系统角色业务类
        /// </summary>
        private SystemRoleService _SystemRoleService = new SystemRoleService();
        /// <summary>
        /// 系统用户业务类
        /// </summary>
        private UserInfoService _UserInfoService = new UserInfoService();

        private AccountService _AccountService = new AccountService();



        /// <summary>
        /// 系统设置父级
        /// </summary>
        /// <returns></returns>
        [Description("系统设置")]
        public ActionResult _System()
        {
            return View();
        }

        /// <summary>
        /// 角色按钮父级
        /// </summary>
        /// <returns></returns>
        [Description("系统设置/菜单管理Pro")]
        public ActionResult _SystemRole()
        {
            return View();
        }

        /// <summary>
        /// 系统设置父级
        /// </summary>
        /// <returns></returns>
        [Description("系统设置/系统菜单")]
        public ActionResult _SystemMenu()
        {
            return View();
        }

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
        /// 查询菜单 ajax
        /// </summary>
        /// <returns></returns>
        [Description("系统设置/系统菜单/查询菜单")]
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
        [Description("系统设置/系统菜单/初始化菜单")]
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



        public IList<ActionPermission> QueryActionPlist(string query, int start, int limit, out long total)
        {
            IList<ActionPermission> allActions = new unity().GetAllActionByAssembly();

            total = (from a in allActions
                     where a.ActionName.ToLower().Contains(query.ToLower())
                     select a).Count();

            var result = (from a in allActions
                          where a.ActionName.ToLower().Contains(query.ToLower())
                          select a).Skip(start).Take(limit);

            return new List<ActionPermission>(result);
        }

        #endregion

        #region 系统角色
        /// <summary>
        /// 角色
        /// </summary>
        /// <returns></returns>
        [ViewPageAttribute]
        public ActionResult Role(FormCollection keys, int? id)
        {
            PagedList<SystemRole> list = RoleList(keys, true, id, 5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Table", list);
            }

            return View(list);
        }

        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Description("系统设置/系统菜单/查询角色")]
        public PagedList<SystemRole> RoleList(FormCollection keys, bool pager, int? index, int? size)
        {
            Expression<Func<SystemRole, bool>> criteria1 = PredicateBuilder.True<SystemRole>();
            if (!string.IsNullOrEmpty(keys["Keyword"]))
            {
                var _key = keys["Keyword"];
                criteria1 = criteria1.And(r => r.RoleName.Contains(_key));
                criteria1 = criteria1.Or(r => r.Description.Contains(_key));
            }
            PagedList<SystemRole> list = selectRole(criteria1, pager, index, size);
            return list;
        }


        public PagedList<SystemRole> selectRole(Expression<Func<SystemRole, bool>> criteria1, bool pager, int? index, int? size)
        {
            PagedList<SystemRole> list;
            if (pager)
            {
                list = _SystemRoleService.GetWhere(criteria1).OrderBy(r => r.RoleName).ToPagedList(index ?? 1, size == null ? 5 : int.Parse(size.ToString()));
            }
            else
            {
                list = (PagedList<SystemRole>)_SystemRoleService.GetWhere(criteria1).OrderBy(r => r.RoleName).ToList();
            }

            return list;
        }

        public List<SystemRole> selectRole(Expression<Func<SystemRole, bool>> criteria1)
        {
            List<SystemRole> list;
            list = _SystemRoleService.GetWhere(criteria1).OrderBy(r => r.RoleName).ToList();
            return list;
        }

        /// <summary>
        /// 角色修改-视图
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public ActionResult EditRole(string roleid)
        {
            if (!string.IsNullOrEmpty(roleid))
            {
                SystemRole role;
                Expression<Func<SystemRole, bool>> criteria1 = PredicateBuilder.True<SystemRole>();
                criteria1 = criteria1.And(r => r.Id.Equals(roleid));
                List<SystemRole> list = selectRole(criteria1);
                role = list.FirstOrDefault();
                return View(role);
            }
            return View();
            //return Json(new { Code = "1", msg = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 执行角色修改
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("系统设置/系统菜单/修改角色")]
        public ActionResult EditRole(string roleid, string roleName, string Description)//string roleid
        {
            try
            {
                if (!string.IsNullOrEmpty(roleid))
                {
                    SystemRole role;
                    Expression<Func<SystemRole, bool>> criteria1 = PredicateBuilder.True<SystemRole>();
                    criteria1 = criteria1.And(r => r.Id.Equals(roleid));
                    List<SystemRole> list = selectRole(criteria1);
                    role = list.FirstOrDefault();
                    if (role != null && !string.IsNullOrEmpty(roleName) && !string.IsNullOrEmpty(Description))
                    {
                        criteria1 = PredicateBuilder.True<SystemRole>();
                        criteria1 = criteria1.And(r => r.RoleName.Equals(roleName));
                        criteria1 = criteria1.And(r => r.Id != roleid);
                        list = selectRole(criteria1);
                        SystemRole roleCheck = list.FirstOrDefault();
                        if (roleCheck == null)
                        {
                            role.RoleName = roleName;
                            role.Description = Description;
                            _SystemRoleService.Edit(role);
                            _SystemMenuService.Save();
                            return Json(new { Code = "1", msg = "修改成功" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { Code = "-3", msg = "已存在相同的角色名称" }, JsonRequestBehavior.AllowGet);
                        }
                    }

                }
                return Json(new { Code = "-1", msg = "修改异常" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { Code = "-2", msg = "修改异常:" + error.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RoleAdd(string RoleName, string Description)
        {
            try
            {
                if (!string.IsNullOrEmpty(RoleName) && !string.IsNullOrEmpty(Description))
                {
                    SystemRole role = _SystemRoleService.GetWhere(r => r.RoleName == RoleName).FirstOrDefault();
                    if (role != null)
                    {
                        //_role = role;
                        //_role.Description = Description;
                        //_SystemRoleService.Edit(role);
                        //_SystemMenuService.Save();
                        return Json(new { Code = "-3", msg = "已经存在同样的角色名称" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        role = new SystemRole();
                        role.RoleName = RoleName;
                        role.Description = Description;
                        role.Depth = 1;
                        role.Path = role.Id + ",";


                        _SystemRoleService.Add(role);
                        _SystemMenuService.Save();
                        return Json(new { Code = "2", msg = "添加成功" }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { Code = "-2", msg = "请检查输入" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {
                return Json(new { Code = "-1", msg = "添加异常：" + error.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        #endregion

        #region 角色菜单
        /// <summary>
        /// 角色权限
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <returns></returns>
        public ActionResult RoleMenu(string roleid)
        {

            if (!string.IsNullOrEmpty(roleid))
            {
                List<SystemMenu> menuList = _SystemMenuService.GetAll().ToList();
                SystemRole role = _SystemRoleService.GetKey(roleid);
                //ViewBag.RoleMenu = string.Join(";", role.Menu.Select(r => r.Id).ToArray()).Trim();
                ViewBag.RoleMenu = role.Menu.ToList();
                ViewBag.RoleName = role.RoleName;
                ViewBag.RoleID = role.Id;
                return View(menuList);
            }
            return View();
        }

        /// <summary>
        /// 保存菜单权限配置
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <param name="arrayMune">菜单集合</param>
        /// <returns></returns>
        public ActionResult SaveRoleMenu(string roleid, List<RoleMenuOrButtonModel> arrayMune)//string roleid, IList<RoleMenuModel> menuArray
        {
            try
            {
                SystemRole role = _SystemRoleService.GetKey(roleid);
                List<SystemMenu> menuList = _SystemMenuService.GetAll().ToList();
                if (role != null)
                {
                    role.Menu.Clear();
                    //arrayMune若为null则实例化一个空对象
                    foreach (RoleMenuOrButtonModel model in arrayMune == null ? new List<RoleMenuOrButtonModel>() : arrayMune)
                    {
                        Predicate<SystemMenu> match = delegate(SystemMenu m) { if (m.Id == model.Menu) { return true; } else { return false; } };
                        SystemMenu menu = menuList.Find(match); //_SystemMenuService.GetKey(model.Menu);
                        role.Menu.Add(menu);
                    }
                    _SystemRoleService.Edit(role);
                    _SystemRoleService.Save();
                    return Json(new { Code = 1, msg = "保存成功" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Code = -1, msg = "保存失败" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception error)
            {
                return Json(new { Code = -1, msg = "保存失败：" + error.Message }, JsonRequestBehavior.AllowGet);
            }


        }


        public class RoleMenuOrButtonModel
        {
            public string Menu { get; set; }
            public string Button { get; set; }

        }


        #endregion

        #region 角色按钮




        /// <summary>
        /// 系统菜单增强版
        /// </summary>
        /// <returns></returns>
        [ViewPageAttribute]
        [Description("系统设置/菜单管理Pro/系统菜单增强版")]
        public ActionResult MenuPro()
        {
            List<ActionPermission> allActions = new unity().GetAllActionByAssembly();
            List<ActionPermission> newActions = new List<ActionPermission>();

            newActions = (from a in allActions
                          orderby a.FirstPath_Spell, a.SecoundPath_Spell
                          select a).ToList();

            //allActions.OrderBy(a => a.FirstPath);
            //allActions.Sort();

            //List<Article> list = GetArticleList();
            //allActions.Sort((x, y) =>
            //{
            //    int value = x.FirstPath_Spell.CompareTo(y.FirstPath_Spell);
            //    if (value == 0)
            //        value = x.FirstPath_Spell.CompareTo(y.FirstPath_Spell);
            //    return value;
            //});
            //foreach (ActionPermission ap in allActions)
            //{

            //}



            string hasButtons = "";

            List<SystemButton> listButton = _SystemButtonService.GetAll().ToList();

            foreach (SystemButton button in listButton)
            {
                hasButtons += button.AreaName + "." + button.ControllerName + "." + button.ActionName + "|";
            }

            ViewBag.hasButtons = hasButtons;
            return View(newActions);
        }

        /// <summary>
        /// 配置角色按钮
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <returns></returns>
        [ViewPageAttribute]
        [Description("系统设置/菜单管理Pro/配置角色按钮")]
        public ActionResult RoleButton(string roleid)
        {
            if (!string.IsNullOrEmpty(roleid))
            {
                IList<ActionPermission> allActions = new unity().GetAllActionByAssembly();
                SystemRole role = _SystemRoleService.GetKey(roleid);

                List<ActionPermission> hasButtons = new List<ActionPermission>();
                List<SystemButton> listButton = role.Button.ToList();
                foreach (SystemButton button in listButton)
                {
                    ActionPermission ap = new AppCode.ActionPermission();
                    ap.ActionName = button.ActionName;
                    ap.AreaName = button.AreaName;
                    ap.ControllerName = button.ControllerName;
                    ap.Description = button.Description;
                    hasButtons.Add(ap);
                }
                ViewBag.hasButtons = hasButtons;
                ViewBag.RoleName = role.RoleName;
                ViewBag.RoleID = role.Id;
                return View(allActions);
            }
            return View();
        }

        /// <summary>
        /// 初始化按钮
        /// </summary>
        /// <returns></returns>
        [Description("系统设置/菜单管理Pro/初始化按钮")]
        public ActionResult InitSystemButton()
        {
            List<SystemButton> btnlist = new List<SystemButton>();
            IList<ActionPermission> allActions = new unity().GetAllActionByAssembly();
            foreach (ActionPermission ap in allActions)
            {
                //这种方法会产生垃圾数据，比如废弃的action或controller、area会一直存在Systembutton表
                SystemButton btn = new SystemButton();
                btn = _SystemButtonService.GetWhere(b => b.ButtonCode == ap.AreaName + "." + ap.ControllerName + "." + ap.ActionName).FirstOrDefault();
                if (btn == null)
                {
                    btn = new SystemButton();
                    btn.ActionName = ap.ActionName;
                    btn.AreaName = ap.AreaName;
                    btn.ControllerName = ap.ControllerName;
                    btn.Description = ap.Description;
                    btn.Title = ap.Description;
                    btn.ButtonCode = ap.AreaName + "." + ap.ControllerName + "." + ap.ActionName;
                    _SystemButtonService.Add(btn);
                    _SystemButtonService.Save();
                }
                else
                {
                    btn.Description = ap.Description;
                    btn.Title = ap.Description;
                    _SystemButtonService.Save();
                }
            }

            return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);

        }


        /// <summary>
        /// 保存菜单权限配置
        /// </summary>
        /// <param name="roleid">角色ID</param>
        /// <param name="arrayMune">菜单集合</param>
        /// <returns></returns>
        public ActionResult SaveRoleButton(string roleid, List<RoleMenuOrButtonModel> array)
        {
            try
            {
                SystemRole role = _SystemRoleService.GetKey(roleid);
                List<SystemButton> buttonList = _SystemButtonService.GetAll().ToList();
                if (role != null)
                {
                    role.Button.Clear();
                    //arrayMune若为null则实例化一个空对象
                    foreach (RoleMenuOrButtonModel model in array == null ? new List<RoleMenuOrButtonModel>() : array)
                    {
                        Predicate<SystemButton> match = delegate(SystemButton m) { if (m.ButtonCode.ToLower() == model.Button.ToLower()) { return true; } else { return false; } };
                        SystemButton button = buttonList.Find(match);
                        role.Button.Add(button);
                    }
                    _SystemRoleService.Edit(role);
                    _SystemRoleService.Save();
                    return Json(new { Code = 1, msg = "保存成功" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { Code = -1, msg = "保存失败" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception error)
            {
                return Json(new { Code = -1, msg = "保存失败：" + error.Message }, JsonRequestBehavior.AllowGet);
            }


        }


        /// <summary>
        /// 检测是否含有按钮
        /// </summary>
        /// <returns></returns>
        //public bool hasButton(List<SystemButton> buttons,string buttonCode) 
        //{

        //}

        #endregion

        #region 系统用户

        /// <summary>
        /// 系统角色
        /// </summary>
        /// <returns></returns>
        [ViewPageAttribute]
        public ActionResult SystemUser(FormCollection keys, int? id)
        {
            //查询所有角色
            var RoleList = _SystemRoleService.GetAll();
            var selectlist = new SelectList(RoleList, "Id", "RoleName");
            ViewData["RoleList"] = selectlist;


            PagedList<UserInfo> list = UserList(keys, true, id, 5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Table_SystemUser", list);
            }

            return View(list);
        }
        public ActionResult selectRoleForUser(string userid, string roleid)
        {
            string _Code = "1", _msg = "分配角色成功";
            SystemRole role = _SystemRoleService.GetKey(roleid);
            try
            {
                UserInfo user = _UserInfoService.GetKey(userid);
                if (role == null)
                {
                    _Code = "-1"; _msg = "角色不存在" + userid + roleid;
                }
                else if (user == null)
                {
                    _Code = "-2"; _msg = "用户不存在";
                }
                else
                {
                    user.Role = role;
                    _UserInfoService.Edit(user);
                    _UserInfoService.Save();
                }
            }
            catch (Exception error)
            {
                _Code = "-2"; _msg = "异常：" + error.Message;
            }

            return Json(new { Code = _Code, msg = _msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public PagedList<UserInfo> UserList(FormCollection keys, bool pager, int? index, int? size)
        {
            Expression<Func<UserInfo, bool>> criteria1 = PredicateBuilder.True<UserInfo>();
            if (!string.IsNullOrEmpty(keys["Keyword"]))
            {
                var _key = keys["Keyword"];
                criteria1 = criteria1.And(r => r.NickName.Contains(_key));
            }
            PagedList<UserInfo> list = selectUser(criteria1, pager, index, size);
            return list;
        }


        public PagedList<UserInfo> selectUser(Expression<Func<UserInfo, bool>> criteria1, bool pager, int? index, int? size)
        {
            PagedList<UserInfo> list;
            if (pager)
            {
                list = _UserInfoService.GetWhere(criteria1).OrderBy(r => r.NickName).ToPagedList(index ?? 1, size == null ? 5 : int.Parse(size.ToString()));
            }
            else
            {
                list = (PagedList<UserInfo>)_UserInfoService.GetWhere(criteria1).OrderBy(r => r.NickName).ToList();
            }

            return list;
        }

        public List<UserInfo> selectUser(Expression<Func<UserInfo, bool>> criteria1)
        {
            List<UserInfo> list;
            list = _UserInfoService.GetWhere(criteria1).OrderBy(r => r.NickName).ToList();
            return list;
        }

        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(UserInfo info)
        {
            int result = 0;
            bool isExists = checkUser2(info.LoginName, 0);
            if (!isExists)
            {
                //Account account = new Account();
                //account.UserName = "111";
                //account.LoginPwd = StringEncryptionHelp.Md5Encrypt("111");
                //account.Info = info;
                //_AccountService.Add(account);
                info.LoginPwd = StringEncryptionHelp.Md5Encrypt(info.LoginPwd);
                _UserInfoService.Add(info);
                _UserInfoService.Save();
            }
            return Json(new { valid = result }, JsonRequestBehavior.AllowGet);
        }

        //检查昵称是否已存在
        public ActionResult checkUser(string LoginName)
        {
            bool result = true;
            Expression<Func<UserInfo, bool>> criteria1 = PredicateBuilder.True<UserInfo>();
            if (!string.IsNullOrEmpty(LoginName))
            {
                criteria1 = criteria1.And(r => r.LoginName.Equals(LoginName));
            }
            List<UserInfo> list = selectUser(criteria1);
            result = list.Count > 0 ? false : true;
            return Json(new { valid = result }, JsonRequestBehavior.AllowGet);
        }

        //检查昵称是否已存在
        public bool checkUser2(string LoginName, int i)
        {
            bool result = true;
            Expression<Func<UserInfo, bool>> criteria1 = PredicateBuilder.True<UserInfo>();
            if (!string.IsNullOrEmpty(LoginName))
            {
                criteria1 = criteria1.And(r => r.LoginName.Equals(LoginName));
            }
            List<UserInfo> list = selectUser(criteria1);
            result = list.Count > 0 ? true : false;
            return result;
        }
        /// <summary>
        /// 批量删除系统用户
        /// </summary>
        /// <returns></returns>
        public ActionResult deleteUsers(List<UserInfo> userList)
        {
            try
            {
                if (userList != null && userList.Count > 0)
                {
                    List<UserInfo> _list = new List<UserInfo>();
                    Expression<Func<UserInfo, bool>> criteria = PredicateBuilder.False<UserInfo>();
                    foreach (UserInfo info in userList)
                    {
                        criteria = criteria.Or(r => r.Id.Equals(info.Id));
                    }
                    _list = selectUser(criteria);

                    _UserInfoService.RemoveRange(_list);
                    _UserInfoService.Save();
                    return Json(new { code = 1, msg = "删除成功.数量：" + _list.Count }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception error)
            {
                string errmsg = error.Message;
            }
            return Json(new { code = -1, msg = "删除失败" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
