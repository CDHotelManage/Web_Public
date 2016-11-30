using LibMain.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account.Dto
{
    public class RoleMenuDto:EntityDto
    {
        public string HotelID { get; set; }
        public string RoleID { get; set; }
        public int Menu_id { get; set; }
        public int Menu_pid { get; set; }
    }
}
