using System;
using System.Collections.Generic;
using System.Text;

namespace General.Common
{
    /// <summary>
    /// 创建唯一标识
    /// </summary>
    public static class CreateOnlyId
    {
        /// <summary>
        /// 创建标识
        /// 格式：年月日时分秒毫秒 + 六位随机码
        /// 解释：yyyyMMddHHmmssfff + Guid.NewGuid().ToString().Substring(0,6)
        /// </summary>
        /// <returns>生成唯一ID</returns>
        public static string CreateId()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff") + Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
