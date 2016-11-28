using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Business.Hotel
{
    public class HotelFullInfo:HotelInfo
    {
        public bool? IsAdmin { get; set; }
    }
}
