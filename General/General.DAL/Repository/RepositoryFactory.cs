using General.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.DAL
{
    /// <summary>
    /// 服务 简单工厂
    /// </summary>
    public static class RepositoryFactory
    {
        #region 系统必备：2015年6月8日 11:44:25
        /// <summary>
        /// 账户信息
        /// </summary>
        public static IAccountRepository AccountRep { get { return new AccountRepository(); } }


        /// <summary>
        /// 系统菜单
        /// </summary>
        public static ISystemMenuRepository SystemMenuRep { get { return new SystemMenuRepository(); } }

        /// <summary>
        /// 系统角色
        /// </summary>
        public static ISystemRoleRepository SystemRoleRep { get { return new SystemRoleRepository(); } }
        /// <summary>
        /// 账户用户信息
        /// </summary>
        public static IUserInfoRepository UserInfoRep { get { return new UserInfoRepository(); } }
        #endregion

    }
}
