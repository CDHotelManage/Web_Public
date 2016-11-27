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
    public class AccountBridge
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(AccountsUsers model)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                var accountDto = ConvertFromBllEntity(model);
                accountDto.AccountId = Guid.NewGuid().ToString();
                return service.Add(accountDto);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(AccountsUsers model)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
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
        public static bool Delete(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return false;
            }
            else
            {
                return service.Delete(id);
            }
        }
        /// <summary>
        /// 根据用户名和密码检查用户
        /// </summary>
        public static AccountsUsers CheckUser(string username, string pwd)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return null;
            }
            var account  = service.GetUsers(username);
            if((account != null)&&(pwd.Equals(account.Password)))
            {                
                return ConvertFromDto(account);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static AccountsUsers GetModel(string id)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return null;;
            }
            else
            {
                var accountDto = service.GetModel(id);
                return ConvertFromDto(accountDto);
            }
        }

        public static AccountsUsers GetModelByName(string name)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return null; ;
            }
            else
            {
                var accountDto = service.GetModelByName(name);
                return ConvertFromDto(accountDto);
            }
        }

        public static int GetCount()
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return 0; ;
            }
            else
            {
                return service.GetCount();
            }
        }

        public static IList<AccountsUsers> GetUsersPager(string sort, string order, int currentPage, int pageSize)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            if (service == null)
            {
                return null; ;
            }
            else
            {
                var list= service.GetUsersPager(sort,order, currentPage, pageSize);
                IList<AccountsUsers> userList = new List<AccountsUsers>();
                foreach(var item in list)
                {
                    userList.Add(ConvertFromDto(item));
                }
                return userList;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            IAccountAppService service = IocManager.Instance.Resolve<IAccountAppService>();
            var accountList  = service.GetList(strWhere);
            
            if(accountList != null)
            {
                List<AccountsUsers> userList = new List<AccountsUsers>();
                accountList.ForEach(x => userList.Add(ConvertFromDto(x)));
                return userList.ToDataSet<AccountsUsers>();
            }
            else
            {
                DataSet ds = new DataSet();
                return ds;
            }
        }



        private static AccountDto ConvertFromBllEntity(AccountsUsers accountUser)
        {
            if (accountUser == null)
            {
                return null;
            }
            AccountDto accountDto = new AccountDto()
            {
                Email = accountUser.Email,
                Phone = accountUser.Phone,
                Password = accountUser.Password,
                Sex = (accountUser.Sex == "男" ? true : false),
                AccountId = accountUser.UserID,
                TrueName = accountUser.TrueName,
                Activity = accountUser.Activity,
                Style = accountUser.Style.Value,
                UserName = accountUser.UserName,
                UserType = accountUser.UserType,
                LastLoginIP = accountUser.LastLoginIP,
                LastLoginTime = accountUser.LastLoginTime
            };
            return accountDto;
        }

        private static AccountsUsers ConvertFromDto(AccountDto accountDto)
        {
            if (accountDto == null)
            {
                return null;
            }
            AccountsUsers user = new AccountsUsers()
            {
                Email = accountDto.Email,
                Phone = accountDto.Phone,
                Password = accountDto.Password,
                Sex = accountDto.Sex ? "男" : "女",
                UserID = accountDto.AccountId,
                TrueName = accountDto.TrueName,
                Activity = accountDto.Activity,
                Style = accountDto.Style,
                UserName = accountDto.UserName,
                UserType = accountDto.UserType,
                LastLoginIP = accountDto.LastLoginIP,
                LastLoginTime = accountDto.LastLoginTime
            };
            return user;
        }
    }
}
