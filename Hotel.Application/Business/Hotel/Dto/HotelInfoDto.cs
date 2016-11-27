using LibMain.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Business.Hotel.Dto
{
    public class HotelInfoDto: EntityDto
    {
        public string HID { get; set; }
        public string HName { get; set; }
        public string HPhone { get; set; }
        public string HFax { get; set; }
        public string HAddress { get; set; }
        public float HLocationX { get; set; }
        public float HLocationY { get; set; }
        public int Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
    }
}
