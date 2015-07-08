using General.Model;
using General.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.BLL
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class SystemRoleService : BaseService<SystemRole>, ISystemRoleRepository
    {
        public SystemRoleService()
            : base(RepositoryFactory.SystemRoleRep)
        {
        }
    }
}
