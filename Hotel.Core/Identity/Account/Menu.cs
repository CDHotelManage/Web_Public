using LibMain.Domain.Entities;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Identity.Account
{
    [Alias("Menu")]
    public class Menu : Entity
    {
        public string title { get; set; }
        public int? parent_id { get; set; }
        public string url { get; set; }
        public string imgurl { get; set; }
        public int? sortId { get; set; }
        public bool? isable { get; set; }
    }
}
