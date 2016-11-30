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
    public class MenuAppService: ApplicationService, IMenuAppService
    {
        private readonly IRepository<Menu> _menuRepository;
        public MenuAppService(IRepository<Menu> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<MenuDto> GetMenulist(int menu_id)
        {
            List<MenuDto> list = new List<MenuDto>();
            var menuList = _menuRepository.Select(x => x.Id == menu_id);
            if (menuList != null)
            {
                menuList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public MenuDto GetModel(int menu_id)
        {
            var menu = _menuRepository.Single(a => (a.Id == menu_id));
            return ConvertFromRepositoryEntity(menu);
        }

        private static MenuDto ConvertFromRepositoryEntity(Menu menu)
        {
            if (menu == null)
            {
                return null;
            }
            var menuDto = new MenuDto
            {
                Id = menu.Id,
                imgurl = menu.imgurl,
                parent_id = menu.parent_id.Value,
                title = menu.title,
                sortId = menu.sortId.Value,
                url = menu.url,
                isable = menu.isable.Value,
            };

            return menuDto;
        }

        private static Menu ConvertFromDto(MenuDto accountDto)
        {
            if (accountDto == null)
            {
                return null;
            }
            var menu = new Menu
            {
                Id = accountDto.Id,
                imgurl = accountDto.imgurl,
                parent_id = accountDto.parent_id,
                title = accountDto.title,
                sortId = accountDto.sortId,
                url = accountDto.url,
                isable = accountDto.isable,
            };
            
            return menu;
        }
    }
}
