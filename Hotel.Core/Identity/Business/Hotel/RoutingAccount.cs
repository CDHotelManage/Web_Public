using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Business.Hotel
{
    [Alias("H_RoutingAccount")]
    public class RoutingAccount: Entity
    {
        public string HID { get; set; }
        public string AccountID { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
