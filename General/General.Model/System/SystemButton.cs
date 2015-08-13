using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 系统菜单
    /// </summary>
    public class SystemButton : BaseEntity
    {
        /// <summary>
        /// 按钮标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 按钮代码
        /// </summary>
        public string ButtonCode { get; set; }

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
        /// 按钮说明/描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 所属角色
        /// </summary>
        public virtual List<SystemRole> Role { get; set; }

    }
}
