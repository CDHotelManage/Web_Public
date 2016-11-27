using Hotel.Application.Account.Dto;
using Hotel.Core.Identity.Account;
using LibMain.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public class RolesAppService: IRolesAppService
    {
        private readonly IRepository<Roles> _userRepository;
        public RolesAppService(IRepository<Roles> userRepository)
        {
            _userRepository = userRepository;
        }
        public bool Add(RolesDto model)
        {
            if (model == null)
            {
                return false;
            }
            else
            {
                var account = ConvertFromDto(model);
                return _userRepository.Insert(account) > 0;
            }
        }

        public int Update(RolesDto model)
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

        public RolesDto GetModel(int accountRolesId)
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

        public List<RolesDto> GetList(string strWhere)
        {
            List<RolesDto> list = new List<RolesDto>();
            var accountList = _userRepository.GetAll();
            if (accountList != null)
            {
                accountList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public List<RolesDto> GetListByTitle(string title)
        {
            List<RolesDto> list = new List<RolesDto>();
            var accountList = _userRepository.GetAll();
            if (accountList != null)
            {
                accountList.FindAll(x =>x.Title == title).ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public int GetMaxId()
        {
            return _userRepository.Count();
        }

        public RolesDto GetSingleOrderByRoleId()
        {
            var accountList = _userRepository.GetAll();
            if ((accountList != null)&&(accountList.Count > 0))
            {
                var list = accountList.OrderBy(x=>x.HotelID).ThenBy(x=>x.RoleID).ToList();
                return ConvertFromRepositoryEntity(list[0]);
            }
            else
            {
                return null;
            }
        }

        private static RolesDto ConvertFromRepositoryEntity(Roles accountRoles)
        {
            if (accountRoles == null)
            {
                return null;
            }
            var rolesDto = new RolesDto
            {
                Id = accountRoles.Id,                
                HotelID = accountRoles.HotelID,
                RoleID = accountRoles.RoleID,
                Title = accountRoles.Title,
                Description = accountRoles.Description
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

        private static Roles ConvertFromDto(RolesDto rolesDto)
        {
            if (rolesDto == null)
            {
                return null;
            }
            var accountRole = new Roles
            {
                Id = rolesDto.Id,
                HotelID = rolesDto.HotelID,
                RoleID = rolesDto.RoleID,
                Title = rolesDto.Title,
                Description = rolesDto.Description
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
