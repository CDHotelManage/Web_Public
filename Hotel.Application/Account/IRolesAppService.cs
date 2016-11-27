using Hotel.Application.Account.Dto;
using Lib.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public interface IRolesAppService : IApplicationService
    {
        bool Add(RolesDto model);
        int Update(RolesDto model);
        int Delete(int accountRolesId);
        RolesDto GetModel(int accountRolesId);
        List<RolesDto> GetList(string strWhere);
        List<RolesDto> GetListByTitle(string title);
        int GetMaxId();
        RolesDto GetSingleOrderByRoleId();
    }
}
