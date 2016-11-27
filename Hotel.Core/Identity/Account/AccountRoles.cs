using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Account
{
    [Alias("AccountRoles")]
    public class AccountRoles : Entity
    {
        [AutoIncrement]
        public override int Id
        {
            get
            {
                return base.Id;
            }

            set
            {
                base.Id = value;
            }
        }
        public string HotelID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RoleID { get; set; }

        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
