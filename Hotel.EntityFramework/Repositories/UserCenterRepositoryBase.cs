using Lib.EntityFramework.EntityFramework;
using Lib.EntityFramework.EntityFramework.Repositories;
using LibMain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using Hotel.Core.Identity.Account;

namespace Hotel.EntityFramework.Repositories
{
    public abstract class UserCenterRepositoryBase<TEntity, TPrimaryKey> : ServiceStackRepositoryBase<UserCenterDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected UserCenterRepositoryBase(IDbContextProvider<UserCenterDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<AccountUser> GetUsersPager(int pageIndex, int pageSize)
        {
            using (var db = Context.OpenDbConnection())
            {
                var q = db.From<AccountUser>();                
                q = q.Skip((pageIndex - 1) * pageSize).Limit(pageSize).OrderByDescending(f => f.Email);
                return db.Select(q);
            }
        }
    }
    public abstract class UserCenterRepositoryBase<TEntity> : UserCenterRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected UserCenterRepositoryBase(IDbContextProvider<UserCenterDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
