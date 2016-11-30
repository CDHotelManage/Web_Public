using Hotel.Application.Account.Dto;
using Hotel.Core.Identity.Account;
using Lib.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public interface IMenuAppService: IApplicationService
    {
        List<MenuDto> GetMenulist(int menu_id);
        MenuDto GetModel(int menu_id);
    }
}
