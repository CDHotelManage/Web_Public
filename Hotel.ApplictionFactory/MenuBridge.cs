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
    public class MenuBridge
    {
        //根据数组查询菜单
        public static DataSet GetMenulist(string menu_ids)
        {
            IMenuAppService service = IocManager.Instance.Resolve<IMenuAppService>();
            var menuAttr = menu_ids.Split(',');
            List<Menu> userList = new List<Menu>();
            foreach (var menuid in menuAttr)
            {
                int id = 0;
                int.TryParse(menuid, out id);
                var menuList = service.GetMenulist(id);
                if (menuList != null)
                {
                    menuList.ForEach(x => userList.Add(ConvertFromDto(x)));                    
                }
            }

            if (userList != null)
            {
                return userList.ToDataSet<Menu>();
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public static Menu GetModel(int menu_id)
        {
            IMenuAppService service = IocManager.Instance.Resolve<IMenuAppService>();
            if (service == null)
            {
                return null; ;
            }
            else
            {
                var menuDto = service.GetModel(menu_id);
                return ConvertFromDto(menuDto);
            }
        }

        private static MenuDto ConvertFromBllEntity(Menu menu)
        {
            if (menu == null)
            {
                return null;
            }
            MenuDto accountDto = new MenuDto()
            {
                Id = menu.menu_id,
                imgurl = menu.imgurl,
                parent_id = menu.parent_id.Value,
                title = menu.title,
                sortId = menu.sortId.Value,
                url = menu.url,
                isable = menu.isable,
            };
            return accountDto;
        }

        private static Menu ConvertFromDto(MenuDto menuDto)
        {
            if (menuDto == null)
            {
                return null;
            }
            Menu user = new Menu()
            {
                menu_id = menuDto.Id,
                imgurl = menuDto.imgurl,
                parent_id = menuDto.parent_id,
                title = menuDto.title,
                sortId = menuDto.sortId,
                url = menuDto.url,
                isable = menuDto.isable,
            };
            return user;
        }
    }
}
