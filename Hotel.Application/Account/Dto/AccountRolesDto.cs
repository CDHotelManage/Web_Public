using LibMain.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account.Dto
{
    public class AccountRolesDto: EntityDto
    {
        public int Id { get; set; }
        public string HotelID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RoleID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}
