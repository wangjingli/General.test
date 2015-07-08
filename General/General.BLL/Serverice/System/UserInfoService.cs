using General.DAL;
using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.BLL
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public class UserInfoService : BaseService<UserInfo>, IUserInfoRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public UserInfoService() :
            base(RepositoryFactory.UserInfoRep)
        {
        }
    }
}
