using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "角色名称是必填项")]
        [MaxLength(100, ErrorMessage = "不能超过100个字符")]
        public string RoleName { get; set; }
        /// <summary>
        /// 角色描述/说明
        /// </summary>
        [Required(ErrorMessage = "角色描述是必填项")]
        [MaxLength(200, ErrorMessage = "不能超过200个字符")]
        public string Description { get; set; }

        /// <summary>
        /// 所拥有菜单选项
        /// </summary>
        public virtual List<SystemMenu> Menu { get; set; }

        /// <summary>
        /// 所拥有菜单选项
        /// </summary>
        public virtual List<SystemButton> Button { get; set; }


    }
}
