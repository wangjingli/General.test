using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 用户详细资料
    /// </summary>
    public class UserInfo : BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfo()
            : base()
        {
        }
        /// <summary>
        /// 性别 男/女
        /// </summary>
        [StringLength(2), Display(Name = "性别")]
        public string Sex
        {
            get;
            set;
            //{
            //    if (value == "男" || value == "女")
            //    {
            //        Sex = value;
            //    }
            //}
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [Display(Name = "联系电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Display(Name = "昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        [Display(Name = "QQ")]
        public string QQ { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "昵称")]
        public int Age
        {
            get;
            set;
            //{
            //    if (int.TryParse(value.ToString(), out value) && value > 17 && value <= 100)
            //    {
            //        Age = value;
            //    }
            //    else
            //    {
            //        Age = 18;
            //    }
            //}
        }
    }
}
