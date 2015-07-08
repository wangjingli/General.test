using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SystemMenu : BaseTreeEntity<SystemMenu>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemMenu()
            : base()
        {
        }
        /// <summary>
        /// 菜单标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Easyui 图标
        /// </summary>
        public string EIcon { get; set; }
        /// <summary>
        /// bootstrap 图标
        /// </summary>
        public string BIcon { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 菜单代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 所拥有按钮代码
        /// </summary>
        public virtual string ButtonCode { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public virtual List<SystemRole> Role { get; set; }

    }
}
