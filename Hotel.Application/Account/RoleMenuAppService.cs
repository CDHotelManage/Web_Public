using Hotel.Application.Account.Dto;
using Hotel.Core.Identity.Account;
using Lib.Application.Services;
using LibMain.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Account
{
    public class RoleMenuAppService: ApplicationService,IRoleMenuAppService
    {
        private readonly IRepository<RoleMenu> _roleMenuRepository;
        public RoleMenuAppService(IRepository<RoleMenu> roleMenuRepository)
        {
            _roleMenuRepository = roleMenuRepository;
        }
        public List<RoleMenuDto> GetList(string roleID)
        {
            var list = new List<RoleMenuDto>();
            if (string.IsNullOrEmpty(roleID))
            {
                return list;
            }
            else
            {
                var roleMenuList = _roleMenuRepository.Select(x => x.RoleID == roleID);
                roleMenuList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public List<RoleMenuDto> GetList(int meunuPID, string roleID)
        {
            var list = new List<RoleMenuDto>();
            if (string.IsNullOrEmpty(roleID))
            {
                return list;
            }
            else
            {
                var roleMenuList = _roleMenuRepository.Select(x => x.RoleID == roleID && x.Menu_pid == meunuPID);
                roleMenuList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        private static RoleMenuDto ConvertFromRepositoryEntity(RoleMenu roleMenu)
        {
            if (roleMenu == null)
            {
                return null;
            }
            var roleMenuDto = new RoleMenuDto
            {
                HotelID = roleMenu.HotelID,
                RoleID = roleMenu.RoleID,
                Menu_id = roleMenu.Menu_id.Value,
                Menu_pid = roleMenu.Menu_pid.Value
            };
            

            return roleMenuDto;
        }

        private static RoleMenu ConvertFromDto(RoleMenuDto roleMenuDto)
        {
            if (roleMenuDto == null)
            {
                return null;
            }
            var roleMenu = new RoleMenu
            {
                HotelID = roleMenuDto.HotelID,
                RoleID = roleMenuDto.RoleID,
                Menu_id = roleMenuDto.Menu_id,
                Menu_pid = roleMenuDto.Menu_pid
            };
            
            return roleMenu;
        }
    }
}
