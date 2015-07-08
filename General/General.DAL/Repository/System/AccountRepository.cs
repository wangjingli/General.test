using General.DAL;
using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.DAL
{
    /// <summary>
    /// 账户服务
    /// </summary>
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccountRepository()
            : base()
        {
        }
    }
}
