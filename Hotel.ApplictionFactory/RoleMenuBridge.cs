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
    public class RoleMenuBridge
    {
        public static DataSet GetList(string roleId)
        {
            IRoleMenuAppService service = IocManager.Instance.Resolve<IRoleMenuAppService>();
            if (service == null)
            {
                return null;
            }
            else
            {
                var list = service.GetList(roleId);
                if(list != null)
                {
                    List<RoleMenu> userList = new List<RoleMenu>();
                    list.ForEach(x => userList.Add(ConvertFromDto(x)));
                    return userList.ToDataSet<RoleMenu>();
                }
                else
                {
                    DataSet ds = new DataSet();
                    return ds;
                }
            }
        }

        public static DataSet GetList(string meunuPId, string roleId)
        {
            IRoleMenuAppService service = IocManager.Instance.Resolve<IRoleMenuAppService>();
            if (service == null)
            {
                return null;
            }
            else
            {
                int pid = 0;
                int.TryParse(meunuPId, out pid);
                var list = service.GetList(pid, roleId);
                if (list != null)
                {
                    List<RoleMenu> userList = new List<RoleMenu>();
                    list.ForEach(x => userList.Add(ConvertFromDto(x)));
                    return userList.ToDataSet<RoleMenu>();
                }
                else
                {
                    DataSet ds = new DataSet();
                    return ds;
                }
            }
        }

        public static DataSet GetSingleOrderByMenuId(string meunuPId, string roleId)
        {
            IRoleMenuAppService service = IocManager.Instance.Resolve<IRoleMenuAppService>();
            if (service == null)
            {
                return null;
            }
            else
            {
                int pid = 0;
                int.TryParse(meunuPId, out pid);
                var list = service.GetList(pid, roleId);
                list = list.OrderBy(x=>x.Menu_id).ToList();
                if ((list != null)&&(list.Count > 0))
                {
                    List<RoleMenu> userList = new List<RoleMenu>();
                    userList.Add(ConvertFromDto(list[0]));
                    return userList.ToDataSet<RoleMenu>();
                }
                else
                {
                    DataSet ds = new DataSet();
                    return ds;
                }
            }
        }

        private static RoleMenuDto ConvertFromBllEntity(RoleMenu menu)
        {
            if (menu == null)
            {
                return null;
            }
            var  accountDto = new RoleMenuDto()
            {
                Menu_id = menu.Menu_id.Value,
                Menu_pid = menu.Menu_pid.Value,
                RoleID = menu.RoleID
            };
            return accountDto;
        }

        private static RoleMenu ConvertFromDto(RoleMenuDto menuDto)
        {
            if (menuDto == null)
            {
                return null;
            }
            var user = new RoleMenu()
            {
                Menu_id = menuDto.Menu_id,
                Menu_pid = menuDto.Menu_pid,
                RoleID = menuDto.RoleID
            };
            return user;
        }
    }
}
