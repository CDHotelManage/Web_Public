using LibMain.Application.Services.Dto;
using LibMain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account.Dto
{
    public class RolesDto: EntityDto
    {
        public string HotelID { get; set; }
        public string RoleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
