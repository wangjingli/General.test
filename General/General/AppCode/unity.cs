using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Text.RegularExpressions;
using General.Model;
using System.ComponentModel;

namespace General.AppCode
{
    public class unity
    {
        /// <summary>
        /// 获取程序集下的所有Action
        /// </summary>
        /// <returns></returns>
        public List<ActionPermission> GetAllActionByAssembly()
        {

            var result = new List<ActionPermission>();

            var types = Assembly.Load("General").GetTypes();

            foreach (var type in types)
            {
                if (type.BaseType.Name == "BaseController")//如果是Controller
                {
                    var members = type.GetMethods();
                    var Properties = type.GetProperties();
                    //object[] attrs = Properties.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                    //if (attrs.Length > 0)
                    //    ap.Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;

                    foreach (var member in members)
                    {

                        if (member.ReturnType.Name == "ActionResult")//如果是Action
                        {
                            var ap = new ActionPermission();

                            ap.ActionName = member.Name;
                            ap.ControllerName = member.DeclaringType.Name.Substring(0, member.DeclaringType.Name.Length - 10); // 去掉“Controller”后缀
                            //{Name = "HomeController" FullName = "General.Areas.Backstage.Controllers.HomeController"}
                            Regex rg = new Regex("(?<=(Areas.))[\\S]+(?=(.Controllers))", RegexOptions.Multiline | RegexOptions.Singleline);

                            ap.AreaName = rg.Match(member.DeclaringType.FullName).Value;
                            string Description = "";
                            object[] attrs = member.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                            if (attrs.Length > 0)
                                Description = (attrs[0] as System.ComponentModel.DescriptionAttribute).Description;

                            string[] DescriptionArr = Description.Split('/');
                            for (int i = 0; i < DescriptionArr.Length; i++)
                            {
                                switch (i)
                                {
                                    case 0:
                                        ap.FirstPath = DescriptionArr[0];
                                        ap.FirstPath_Spell = ChineseToSpell.ConvertToAllSpell(DescriptionArr[0]);
                                        break;
                                    case 1:
                                        ap.SecoundPath = DescriptionArr[1];
                                        ap.SecoundPath_Spell = ChineseToSpell.ConvertToAllSpell(DescriptionArr[1]);
                                        break;
                                    case 2:
                                        ap.Description = DescriptionArr[2];
                                        ap.Description_Spell = ChineseToSpell.ConvertToAllSpell(DescriptionArr[2]);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            result.Add(ap);
                        }
                    }
                }
            }
            return result;
        }
        //private KeyValuePair<string, int> getPropertyDesc(System.Reflection.MethodInfo type)
        //{
        //    var descriptionAttribute = (DescriptionAttribute)(type.GetCustomAttributes(false).FirstOrDefault(x => x is DescriptionAttribute));
        //    if (descriptionAttribute == null) return new KeyValuePair<string, int>();
        //    return new KeyValuePair<string, int>(descriptionAttribute.Description, descriptionAttribute.TypeId);
        //}

    }
    /// <summary>
    /// 针对MVC的Action的权限
    /// </summary>
    public class ActionPermission
    {
        /// <summary>
        /// ActionName
        /// </summary>
        public virtual string ActionName { get; set; }

        /// <summary>
        /// 控制器
        /// </summary>
        public virtual string ControllerName { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public virtual string AreaName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 描述 拼音
        /// </summary>
        public virtual string Description_Spell { get; set; }

        /// <summary>
        /// 顶级目录
        /// </summary>
        public virtual string FirstPath { get; set; }
        /// <summary>
        /// 顶级目录 拼音
        /// </summary>
        public virtual string FirstPath_Spell { get; set; }


        /// <summary>
        /// 第二目录
        /// </summary>
        public virtual string SecoundPath { get; set; }

        /// <summary>
        /// 第二目录 拼音
        /// </summary>
        public virtual string SecoundPath_Spell { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public virtual string Pater { get; set; }

        ///// <summary>
        ///// 角色列表
        ///// </summary>
        //public virtual ISet<Role> Roles { get; set; }
    }
}