using Lib.EntityFramework.EntityFramework;
using Lib.EntityFramework.EntityFramework.Repositories;
using LibMain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BusinessEntityFramework.Repositories
{
    public abstract class BusinessRepositoryBase<TEntity, TPrimaryKey> : ServiceStackRepositoryBase<BusinessDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BusinessRepositoryBase(IDbContextProvider<BusinessDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        
    }
    public abstract class BusinessRepositoryBase<TEntity> : BusinessRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BusinessRepositoryBase(IDbContextProvider<BusinessDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
