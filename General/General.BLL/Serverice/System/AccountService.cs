using General.DAL;
using General.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.BLL
{
    public class AccountService : BaseService<Account>, IAccountRepository
    {
        public AccountService()
            : base(RepositoryFactory.AccountRep)
        {
        }
    }
}
