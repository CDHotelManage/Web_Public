using Hotel.Core.Identity.Account;
using Hotel.Core.Identity.Business.Hotel;
using Lib.EntityFramework.EntityFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BusinessEntityFramework
{
    public class BusinessDbContext : Lib.EntityFramework.EntityFramework.LibDbContext
    {
        //public IDbSet<UserLogin> UserLogins { get; set; }
        ///// <summary>
        ///// Users.
        ///// </summary>
        public IDbSet<HotelInfo> Hotels { get; set; }

        public IDbSet<RoutingAccount> RoutingAccounts { get; set; }

        public BusinessDbContext()
            : base("Default")
        {

        }
        public BusinessDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
    }
}
