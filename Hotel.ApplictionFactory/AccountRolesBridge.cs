using CdHotelManage.Model;
using Hotel.Application.Account;
using Hotel.Application.Account.Dto;
using Hotel.ApplictionFactory.Extensions;
using LibMain.Dependency;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ApplictionFactory
{
    public class AccountRolesBridge
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(AccountsUserRoles model)
        {
            IAccountRolesAppService service = IocManager.Instance.Resolve<IAccountRolesAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                var accountDto = ConvertFromBllEntity(model);
                return service.Add(accountDto);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(AccountsUserRoles model)
        {
            IAccountRolesAppService service = IocManager.Instance.Resolve<IAccountRolesAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                var accountDto = ConvertFromBllEntity(model);
                return service.Update(accountDto) > 0;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(string accountRolesId)
        {
            IAccountRolesAppService service = IocManager.Instance.Resolve<IAccountRolesAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                return service.Delete(accountRolesId) > 0;
            }
        }

        public static AccountsUserRoles GetModel(string accountID,string hotelID)
        {
            IAccountRolesAppService service = IocManager.Instance.Resolve<IAccountRolesAppService>();
            if (service == null)
            {
                return null;
            }
            else
            {
                var dto = service.GetModel(hotelID, accountID);
                return ConvertFromDto(dto);
            }
        }


        private static AccountRolesDto ConvertFromBllEntity(AccountsUserRoles accountRoles)
        {
            if (accountRoles == null)
            {
                return null;
            }
            AccountRolesDto accountDto = new AccountRolesDto()
            {
                Id = accountRoles.Id,
                AccountID = accountRoles.UserID,
               HotelID = accountRoles.HotelID,
               RoleID  = accountRoles.RoleID,
               CreateTime = accountRoles.CreateTime,
               UpdateTime = accountRoles.UpdateTime
            };
            return accountDto;
        }

        private static AccountsUserRoles ConvertFromDto(AccountRolesDto rolesDto)
        {
            if (rolesDto == null)
            {
                return null;
            }
            AccountsUserRoles user = new AccountsUserRoles()
            {
                Id = rolesDto.Id,
                UserID = rolesDto.AccountID,
                HotelID = rolesDto.HotelID,
                RoleID = rolesDto.RoleID,
                CreateTime = rolesDto.CreateTime,
                UpdateTime = rolesDto.UpdateTime
            };
            return user;
        }
    }
}
