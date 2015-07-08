using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 系统角色
    /// </summary>
    public class SystemRole : BaseTreeEntity<SystemRole>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SystemRole()
            : base()
        {
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述/说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 所拥有菜单选项
        /// </summary>
        public virtual List<SystemMenu> Menu { get; set; }


    }
}
