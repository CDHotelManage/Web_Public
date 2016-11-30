using Hotel.Application.Account.Dto;
using Lib.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public interface IRoleMenuAppService : IApplicationService
    {
        List<RoleMenuDto> GetList(string roleID);
        List<RoleMenuDto> GetList(int meunuPID, string roleID);
    }
}
