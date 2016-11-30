using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Account
{
    [Alias("RoleMenu")]
    public class RoleMenu : Entity
    {
        public string HotelID { get; set; }
        public string RoleID  {get;set;}
        public int? Menu_id { get; set; }
        public int? Menu_pid { get; set; }
    }
}
