using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Common
{
    /// <summary>
    /// Easyui Grid 数据 模型
    /// </summary>
    public class DataGrid
    {
        /// <summary>
        /// 分页总数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 分页显示行数据
        /// </summary>
        public object rows { get; set; }
        /// <summary>
        /// 页脚统计
        /// </summary>
        public object footer { get; set; }
    }
}
