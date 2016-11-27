using Hotel.Core.Identity.Account;
using Lib.EntityFramework.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.EntityFramework
{
    public class UserCenterDbContext: Lib.EntityFramework.EntityFramework.LibDbContext
    {
        //public IDbSet<UserLogin> UserLogins { get; set; }
        ///// <summary>
        ///// Users.
        ///// </summary>
       public IDbSet<AccountUser> Users { get; set; }

        public UserCenterDbContext()
            : base("Default")
        {

        }
        public UserCenterDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
