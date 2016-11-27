using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Account
{
    [Alias("Account")]
    public class AccountUser : Entity<long>
    { 
        public string AccountId{get;set;}
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TrueName { get; set; }
        public bool? Sex { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Activity { get; set; }
        public string UserType { get; set; }
        public int? Style { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
    }
}
