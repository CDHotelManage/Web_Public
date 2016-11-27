using Hotel.Application.Account.Dto;
using Lib.Application.Services;
using LibMain.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public interface IAccountAppService : IApplicationService
    {
        AccountDto GetUsers(string account);
        bool Add(AccountDto model);
        int Update(AccountDto model);
        bool Delete(string accountId);
        AccountDto GetModel(string accountId);
        AccountDto GetModelByName(string name);
        AccountDto GetBasicInfo(AccountDto model);
        int GetCount();
        IList<AccountDto> GetUsersPager(string sort, string order, int currentPage, int pageSize);

        List<AccountDto> GetList(string strWhere);
        RegisterActionResult RegisteAccont(AccountDto model);
    }
}
