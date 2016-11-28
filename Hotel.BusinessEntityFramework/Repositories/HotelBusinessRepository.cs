using Hotel.Core.Identity.Business.Hotel;
using Lib.EntityFramework.EntityFramework;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.BusinessEntityFramework.Repositories
{
    public class HotelBusinessRepository: BusinessRepositoryBase<HotelInfo>
    {
        public HotelBusinessRepository(IDbContextProvider<BusinessDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<HotelFullInfo> GetAllHotelInfo(string accountId)
        {
            List<HotelFullInfo> results = new List<HotelFullInfo>();
            using (var db = Context.OpenDbConnection())
            {
                var q = db.From<HotelInfo>();
                q = q.Join<HotelInfo, RoutingAccount>((a, e) => a.HID == e.HID && (a.Status >= 1 && a.Status<=2) 
                && e.AccountID == accountId &&a.IsDeleted== false && e.IsDeleted==false);
                results = db.Select<HotelFullInfo>(q);
            }
            return results;
        }
    }
}
