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
        public IDbSet<Roles> Roles { get; set; }
        public IDbSet<RoleMenu> RoleMenus { get; set; }
        public IDbSet<AccountRoles> AccountRoles { get; set; }
        ///// <summary>
        ///// Users.
        ///// </summary>
        public IDbSet<AccountUser> Users { get; set; }

        public IDbSet<Menu> Menus { get; set; }

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
