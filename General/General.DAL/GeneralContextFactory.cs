using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace General.DAL
{
    /// <summary>
    /// 上下文简单工厂
    /// </summary>
    public class GeneralContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns>返回 数据上下文</returns>
        public static GeneralDbContext GetCurrentContext()
        {
            GeneralDbContext context = CallContext.GetData("General") as GeneralDbContext;
            if (context == null)
            {
                context = new GeneralDbContext();
                CallContext.SetData("General", context);
            }
            return context;
        }
    }
}
