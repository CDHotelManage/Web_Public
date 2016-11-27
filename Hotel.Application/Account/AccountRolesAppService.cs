using Lib.Application.Services;
using Hotel.Application.Account.Dto;
using Hotel.Core.Identity.Account;
using LibMain.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.EntityFramework.Repositories;
using Common;

namespace Hotel.Application.Account
{
    public class AccountRolesAppService: IAccountRolesAppService
    {
        private readonly IRepository<AccountRoles> _userRepository;
        public AccountRolesAppService(IRepository<AccountRoles> userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Add(AccountRolesDto model)
        {
            if (model == null)
            {
                return false;
            }
            else
            {
                var account = ConvertFromDto(model);
                return _userRepository.Insert(account) >0;
            }
        }

        public int Update(AccountRolesDto model)
        {
            if (model == null)
            {
                return 0;
            }
            else
            {
                var accountRole = ConvertFromDto(model);
                return _userRepository.UpdateNonDefaults(accountRole, x => x.Id == accountRole.Id);
            }
        }

        public int Delete(int accountRolesId)
        {
            if (accountRolesId <= 0)
            {
                return 0;
            }
            else
            {
                return _userRepository.DeleteById(accountRolesId);
            }
        }

        public AccountRolesDto GetModel(int accountRolesId)
        {
            var accountUser = _userRepository.Single(a => (a.Id == accountRolesId));
            if (accountUser == null)
            {
                return null;
            }
            else
            {
                return ConvertFromRepositoryEntity(accountUser);
            }
        }



        private static AccountRolesDto ConvertFromRepositoryEntity(AccountRoles accountRoles)
        {
            if (accountRoles == null)
            {
                return null;
            }
            var rolesDto = new AccountRolesDto
            {
                Id = accountRoles.Id,
                AccountID = accountRoles.AccountID,
                HotelID = accountRoles.HotelID,
                RoleID = accountRoles.RoleID
            };
            if (accountRoles.CreateTime != null)
            {
                rolesDto.CreateTime = accountRoles.CreateTime.Value;
            }
            else
            {
                rolesDto.CreateTime = DateTime.MinValue;
            }

            if (accountRoles.UpdateTime != null)
            {
                rolesDto.UpdateTime = accountRoles.UpdateTime.Value;
            }
            else
            {
                rolesDto.UpdateTime = DateTime.MinValue;
            }

            return rolesDto;
        }

        private static AccountRoles ConvertFromDto(AccountRolesDto rolesDto)
        {
            if (rolesDto == null)
            {
                return null;
            }
            var accountRole = new AccountRoles
            {
                Id = rolesDto.Id,
                AccountID = rolesDto.AccountID,
                HotelID = rolesDto.HotelID,
                RoleID = rolesDto.RoleID
            };
            if ((rolesDto?.CreateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                accountRole.CreateTime = rolesDto.CreateTime;
            }
            if ((rolesDto?.UpdateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                accountRole.UpdateTime = rolesDto.UpdateTime;
            }
            return accountRole;
        }
    }
}
