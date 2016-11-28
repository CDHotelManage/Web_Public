using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Business.Hotel
{
    [Alias("H_HotelInfo")]
    public class HotelInfo : Entity
    {
        public string HID { get; set; }
        public string HName { get; set; }
        public string HPhone { get; set; }
        public string HFax { get; set; }
        public string HAddress { get; set; }
        public float? HLocationX { get; set; }
        public float? HLocationY { get; set; }
        public int? Status { get; set; }
        public string Remark { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsDeleted { get; set; }        
    }
}
