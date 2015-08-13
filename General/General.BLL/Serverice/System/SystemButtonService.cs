using General.DAL;
using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.BLL
{
    /// <summary>
    /// 系统菜单服务
    /// </summary>
    public class SystemButtonService : BaseService<SystemButton>, ISystemButtonRepository
    {
        public SystemButtonService()
            : base(RepositoryFactory.SystemButtonRep)
        {
        }
    }
}
