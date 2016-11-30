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
    public class RolesBridge
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(AccountsRoles model)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
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
        public static bool Update(AccountsRoles model)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
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
        public static bool Delete(int accountRolesId)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                return service.Delete(accountRolesId) > 0;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AccountsRoles GetModel(string accountRolesId)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            if (service == null)
            {
                return null;
            }
            else
            {
                var rolesDto = service.GetModel(accountRolesId);
                return ConvertFromDto(rolesDto);
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            var accountList = service.GetList(strWhere);

            if (accountList != null)
            {
                List<AccountsRoles> userList = new List<AccountsRoles>();
                accountList.ForEach(x => userList.Add(ConvertFromDto(x)));
                return userList.ToDataSet<AccountsRoles>();
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }


        public static DataSet GetListByTitle(string title)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            var accountList = service.GetListByTitle(title);

            if (accountList != null)
            {
                List<AccountsRoles> userList = new List<AccountsRoles>();
                accountList.ForEach(x => userList.Add(ConvertFromDto(x)));
                return userList.ToDataSet<AccountsRoles>();
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }

        public static int GetMaxId()
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            if (service == null)
            {
                return 0;
            }
            else
            {
                return service.GetMaxId();
            }
        }

        public static DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            IRolesAppService service = IocManager.Instance.Resolve<IRolesAppService>();
            var rolesDto = service.GetSingleOrderByRoleId();

            if (rolesDto != null)
            {
                List<AccountsRoles> userList = new List<AccountsRoles>();
                userList.Add(ConvertFromDto(rolesDto));
                return userList.ToDataSet<AccountsRoles>();
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }


        private static RolesDto ConvertFromBllEntity(AccountsRoles accountRoles)
        {
            if (accountRoles == null)
            {
                return null;
            }
            RolesDto accountDto = new RolesDto()
            {
                Id = accountRoles.Id,
                HotelID = accountRoles.HotelID,
                RoleID = accountRoles.RoleID,
                Description = accountRoles.Description,
                Title = accountRoles.Title
            };
            return accountDto;
        }

        private static AccountsRoles ConvertFromDto(RolesDto rolesDto)
        {
            if (rolesDto == null)
            {
                return null;
            }
            AccountsRoles user = new AccountsRoles()
            {
                Id = rolesDto.Id,
                HotelID = rolesDto.HotelID,
                RoleID = rolesDto.RoleID,
                Description = rolesDto.Description,
                Title = rolesDto.Title
            };
            return user;
        }
    }
}
