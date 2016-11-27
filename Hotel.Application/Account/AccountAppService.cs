using Lib.Application.Services;
using LibMain.Application.Services.Dto;
using LibMain.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Core.Identity.Account;
using Hotel.Application.Account.Dto;
using LibMain.Dependency;
using Hotel.EntityFramework.Repositories;
using Common;

namespace Hotel.Application.Account
{
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IRepository<AccountUser, long> _userRepository;
        public AccountAppService(IRepository<AccountUser, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Add(AccountDto model)
        {
            if (model == null)
            {
                return false;
            }
            else
            {
                var account = ConvertFromDto(model);
                if(string.IsNullOrEmpty(account.AccountId) )
                {
                    account.AccountId = Guid.NewGuid().ToString();
                }
                return _userRepository.Insert(account) != null;
            }
        }

        public AccountDto GetUsers(string account)
        {
            var accountUser = _userRepository.Single(a => (a.Email == account || a.Phone == account));
            if (accountUser == null)
            {
                return null;
            }
            else
            {
                return ConvertFromRepositoryEntity(accountUser);
            }
        }

        
        public int Update(AccountDto model)
        {
            if (model == null)
            {
                return 0;
            }
            else
            {
                var account = ConvertFromDto(model);
                return _userRepository.UpdateNonDefaults(account,x => x.AccountId == account.AccountId);
            }
        }
        public bool Delete(string accountId)
        {
            if(string.IsNullOrEmpty(accountId))
            {
                return false;
            }
            else
            {
                var account = _userRepository.Single(a => (a.AccountId == accountId));
                _userRepository.Delete(account);
                return true;
            }
        }

        public AccountDto GetModel(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                return null;
            }
            else
            {
                var account = _userRepository.Single(a => (a.AccountId == accountId));                
                return ConvertFromRepositoryEntity(account);
            }
        }

        public AccountDto GetBasicInfo(AccountDto model)
        {
            if ((model == null) || (string.IsNullOrEmpty(model.AccountId)))
            {
                return null;
            }
            else
            {
                var account = _userRepository.Single(a => (a.AccountId == model.AccountId));
                return ConvertFromRepositoryEntity(account);
            }
        }

        public AccountDto GetModelByName(string name)
        {
            var account = _userRepository.Single(a => (a.UserName == name));
            return ConvertFromRepositoryEntity(account);
        }

        public int GetCount()
        {
           return _userRepository.Count();
        }
        public IList<AccountDto> GetUsersPager(string sort, string order, int currentPage, int pageSize)
        {
            UserCenterRepositoryBase<AccountUser,long>  repository = IocManager.Instance.Resolve<UserCenterRepositoryBase<AccountUser,long>>();
            var accountList = repository.GetUsersPager(currentPage, pageSize);
            List<AccountDto> list = new List<AccountDto>();
            if (accountList != null)
            {
                accountList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public List<AccountDto> GetList(string strWhere)
        {
            List<AccountDto> list = new List<AccountDto>();
            var accountList = _userRepository.GetAll();
            if (accountList != null)
            {
                accountList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }

        public RegisterActionResult RegisteAccont(AccountDto model)
        {
            var user = _userRepository.Single(a => (a.Email == model.Account) ||(a.Phone == model.Account));
            if(user != null)
            {
                return RegisterActionResult.IsRegisted;
            }

            if(!VerifyRegisterCode(model.VerifyCode, model.Account))
            {
                return RegisterActionResult.FieldInvalidVerifyCode;
            }

            if (!Function.ValidatePassword(model.Password))
            {
                return RegisterActionResult.PasswordRuleError;
            }
            bool isEmail = false;
            bool isMobilePhone = false;
            if (Function.ValidateEmail(model.Account))
            {
                isEmail = true;
            }
            else if (Function.ValidateMobilePhone(model.Account))
            {
                isMobilePhone = true;
            }
            if(!isEmail&&!isMobilePhone)
            {
                return RegisterActionResult.AccountRuleError;
            }

            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;

            if (isEmail)
            {
                model.Email = model.Account;
            }
            else if(isMobilePhone)
            {
                model.Phone = model.Account;
            }
            else
            {
                return RegisterActionResult.AccountRuleError;
            }
            var ret = this.Add(model);
            if(ret)
            {
                return RegisterActionResult.Success;
            }
            else
            {
                return RegisterActionResult.Failed;
            }
        }
       

        private bool VerifyRegisterCode(string code, string account)
        {
            

            return true;
        }



        private static AccountDto ConvertFromRepositoryEntity(AccountUser accountUser)
        {
            if(accountUser == null)
            {
                return null;
            }
            var accountDto = new AccountDto
            {
                Email = accountUser.Email,
                Phone = accountUser.Phone,
                Password = accountUser.Password,
                Sex = accountUser.Sex.Value,
                AccountId = accountUser.AccountId,
                TrueName = accountUser.TrueName,
                Activity = accountUser.Activity.Value,
                Style = accountUser.Style.Value,
                UserName = accountUser.UserName,
                UserType = accountUser.UserType,
                CreateTime = accountUser.CreateTime.Value,
                UpdateTime = accountUser.UpdateTime.Value,
                LastLoginIP = accountUser.LastLoginIP
            };
            if (accountUser.LastLoginTime != null)
            {
                accountDto.LastLoginTime = accountUser.LastLoginTime.Value;
            }
            else
            {
                accountDto.LastLoginTime = DateTime.MinValue;
            }

            return accountDto;
        }

        private static AccountUser ConvertFromDto(AccountDto accountDto)
        {
            if(accountDto == null)
            {
                return null;
            }
            var account = new AccountUser
            {
                Email = accountDto.Email,
                Phone = accountDto.Phone,
                Password = accountDto.Password,
                Sex = accountDto.Sex,
                AccountId = accountDto.AccountId,
                TrueName = accountDto.TrueName,
                Activity = accountDto.Activity,
                Style = accountDto.Style,
                UserName = accountDto.UserName,
                UserType = accountDto.UserType,               
                LastLoginIP = accountDto.LastLoginIP
            };
            if ((accountDto?.LastLoginTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                account.LastLoginTime = accountDto.LastLoginTime;
            }
            if ((accountDto?.CreateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                account.CreateTime = accountDto.CreateTime;
            }
            if ((accountDto?.UpdateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                account.UpdateTime = accountDto.UpdateTime;
            }
            return account;
        }
    }
}
