using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace General.Model
{
    /// <summary>
    /// 通用树形 数据模型基类
    /// </summary>
    /// <typeparam name="T">树实体对象</typeparam>
    public class BaseTreeEntity<T> : BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        protected BaseTreeEntity()
            : base()
        {
        }
        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 层级、深度、节点级别
        /// </summary>
        [Display(Name="层级")]
        public int Depth { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual T Parent { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        [Column("Parent_Id"),StringLength(40)]
        public string ParentId { get; set; }
        /// <summary>
        /// 子节点集合
        /// </summary>
        public virtual List<T> Children { get; set; }
    }
}
