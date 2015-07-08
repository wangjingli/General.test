using General.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 模型基类：
    /// id:唯一标识
    /// CreateTime:创建时间
    /// LastUpdateTime:最后修改时间
    /// Islock是否锁定
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseEntity()
        {
            id = CreateOnlyId.CreateId();//生成ID
            createTime = DateTime.Now;//创建时获取当前时间
            LastUpadateTime = DateTime.Now;//创建时获取当前时间
            IsLock = false;//默认值false 不锁定，默认激活
        }
        /// <summary>
        /// ID
        /// </summary>
        private string id;
        /// <summary>
        /// Id 标识
        /// </summary>
        [Key()]
        [Required()]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 是否锁定 true =锁定 false=不锁定
        /// </summary>
        private bool isLock;
        /// <summary>
        /// 是否锁定 true =锁定 false=不锁定
        /// </summary>
        [Required()]
        public bool IsLock
        {
            get { return isLock; }
            set { isLock = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required()]
        public DateTime CreateTime
        {
            get { return createTime; }
        }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        private DateTime lastUpadateTime;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Required()]
        public DateTime LastUpadateTime
        {
            get { return lastUpadateTime; }
            set { lastUpadateTime = value; }
        }
    }
}
