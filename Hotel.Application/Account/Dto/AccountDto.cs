using LibMain.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account.Dto
{
    public class AccountDto : EntityDto<long>
    {
        public string AccountId { get; set; }
        public string Account { get; set; }
        public string VerifyCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TrueName { get; set; }
        public bool Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public bool Activity { get; set; }
        public string UserType { get; set; }
        public int Style { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
    }
}
