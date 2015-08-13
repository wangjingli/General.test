using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using General.Common;
using General.Areas.Backstage.Models;
using General.BLL;
using System.Web.Security;
using General.Model;

namespace General.Areas.Backstage.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccountController()
        {
            _UserInfoService = new UserInfoService();
            //_AccountService = new AccountService();
        }
        public UserInfoService _UserInfoService;
        //public AccountService _AccountService;

        //
        // GET: /Backstage/Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //ModelState.AddModelError("username","444");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AccountModels model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Session["VerificationCode"] == null || Session["VerificationCode"].ToString() != model.VerificationCode)
                {
                    ModelState.AddModelError("VerificationCode", "验证码错误，请重新输入");
                }
                else
                {
                    var userData = _UserInfoService.GetWhere(m => m.LoginName == model.UserName && m.IsLock == false).FirstOrDefault();
                    if (FormsAuthentication.Authenticate(model.UserName, model.PassWord))
                    {
                        SetCookie(model, userData);
                        return RedirectToUrl(returnUrl);
                    }
                    else
                    {
                        if (userData != null)
                        {
                            if (userData.LoginPwd == StringEncryptionHelp.Md5Encrypt(model.PassWord))
                            {
                                SetCookie(model, userData);
                                return RedirectToUrl(returnUrl);
                            }
                            else
                            {
                                ModelState.AddModelError("PassWord", "别瞎登录，密码不对");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("UserName", "sb，没有这个用户");
                        }
                    }
                }
            }
            return View(model);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            string verificationCode = CreateVerificationCode.CreateVerificationText(1);
            byte[] bytes = CreateVerificationCode.CreateVerificationImage(verificationCode, 90, 34);
            Session["VerificationCode"] = verificationCode;
            return File(bytes, @"image/jpeg");
        }

        /// <summary>
        /// 设置登录信息COOKIE
        /// </summary>
        /// <param name="model">页面登录账户实体</param>
        /// <param name="userObject">访问数据库实体</param>
        private void SetCookie(AccountModels model, UserInfo userObject)
        {
            //获取登录COOKIE
            HttpCookie cookie = FormsAuthentication.GetAuthCookie(model.UserName, false);
            if (userObject != null)
            {
                cookie = FormsAuthentication.GetAuthCookie(userObject.LoginName, false);
            }
            //cookie 加密 登录信息标识
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
            //新建 配置 登录信息标识
            FormsAuthenticationTicket newTicket = null;
            if (userObject != null)
            {
                newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, string.Format("{0}|{1}|{2}|{3}", userObject.Id, userObject.NickName, userObject.Email, string.Join(",", userObject.Role.Menu.Select(m => m.Code).ToArray())));
                //创建加密COOKIE
                cookie.Value = FormsAuthentication.Encrypt(newTicket);
                //FormsAuthentication.SetAuthCookie(model.UserName, false);
                //添加浏览器COOKIE
                base.Response.Cookies.Add(cookie);
            }
            else
            {
                newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name,
                ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, "0|超级管理员|" + System.Configuration.ConfigurationManager.AppSettings["NetName"].Trim().ToString() + "@admin.com" + "| ");
                //创建加密COOKIE
                cookie.Value = FormsAuthentication.Encrypt(newTicket);
                //FormsAuthentication.SetAuthCookie(model.UserName, false);
                //添加浏览器COOKIE
                base.Response.Cookies.Add(cookie);
            }

        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            //string username = (User.Identity as FormsIdentity).Ticket.UserData.Split("|".ToCharArray())[1];
            //HttpCookie cookies = Request.Cookies[username];
            //if (cookies != null)
            //{
            //    cookies.Expires = DateTime.Today.AddDays(-1);
            //    Response.Cookies.Add(cookies);
            //    Request.Cookies.Remove(username);
            //}

            //HttpCookie c = new HttpCookie(username);
            //c.Values.Add("1", "2");
            //c.Expires = DateTime.Now.AddYears(1);
            //Response.Cookies.Add(c);

            //Response.Redirect(Request.Url.PathAndQuery);
            return new HttpUnauthorizedResult();

        }


        /// <summary>
        /// 页面跳转
        /// </summary>
        /// <param name="returnUrl">跳转URL</param>
        /// <returns></returns>
        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
