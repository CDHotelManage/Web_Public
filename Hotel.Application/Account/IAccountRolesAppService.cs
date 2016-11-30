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
    public interface IAccountRolesAppService : IApplicationService
    {
        bool Add(AccountRolesDto model);
        int Update(AccountRolesDto model);
        int Delete(string accountRolesId);
        AccountRolesDto GetModel(string HID, string accountID);

    }
}
