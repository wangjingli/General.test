using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 系统账户
    /// </summary>
    public class Account : BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Account()
            : base()
        {
        }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 账户密码
        /// </summary>
        public string LoginPwd { get; set; }
        /// <summary>
        /// 账户信息
        /// </summary>
        public virtual UserInfo Info { get; set; }
        /// <summary>
        /// 所属角色
        /// </summary>
        public virtual SystemRole Role { get; set; }
    }
}
