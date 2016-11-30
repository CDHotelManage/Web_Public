using Hotel.Application.Business.Hotel.Dto;
using Hotel.BusinessEntityFramework.Repositories;
using Hotel.Core.Identity.Business.Hotel;
using Hotel.Enum;
using Lib.Application.Services;
using LibMain.Dependency;
using LibMain.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Business.Hotel
{
    public class HotelAppService: ApplicationService, IHotelAppService
    {
        private readonly IRepository<HotelInfo> _hotelRepository;
        private readonly IRepository<RoutingAccount> _routingAccountRepository;
        public HotelAppService(IRepository<HotelInfo> hotelRepository, IRepository<RoutingAccount> routingAccountRepository)
        {
            _hotelRepository = hotelRepository;
            _routingAccountRepository = routingAccountRepository;
        }
        public HotelInfoDto GetHotelInfo(HotelInfoDto model)
        {
            if ((model == null) || (string.IsNullOrEmpty(model.HID)))
            {
                return null;
            }
            var accountUser = _hotelRepository.Single(a => (a.HID == model.HID));
            if (accountUser == null)
            {
                return null;
            }
            else
            {
                return ConvertFromRepositoryEntity(accountUser);
            }
        }

        public HotelInfoDto GetHotelInfo(string HID)
        {
            if(string.IsNullOrEmpty(HID))
            {
                return null;
            }
            var accountUser = _hotelRepository.Single(a => (a.HID == HID));
            if (accountUser == null)
            {
                return null;
            }
            else
            {
                return ConvertFromRepositoryEntity(accountUser);
            }
        }
        public List<HotelInfoDto> GetAllHotelInfo(HotelInfoDto model)
        {
            List<HotelInfoDto> list = new List<HotelInfoDto>();
            if ((model == null)||(string.IsNullOrEmpty(model.AccountID)))
            {
                return list;
            }
            var repository = (HotelBusinessRepository)IocManager.Instance.Resolve(typeof(HotelBusinessRepository));
            var hotelList = repository.GetAllHotelInfo(model.AccountID);
            if (hotelList != null)
            {
                hotelList.ForEach(x => list.Add(ConvertFromRepositoryEntity(x)));
            }
            return list;
        }
        public bool Add(HotelInfoDto model)
        {
            if (model == null)
            {
                return false;
            }
            else
            {
                var hotel = ConvertFromDto(model);
                if (string.IsNullOrEmpty(hotel.HID))
                {
                    hotel.HID = Guid.NewGuid().ToString();
                }
                hotel.CreateTime = DateTime.Now;
                hotel.UpdateTime = DateTime.Now;
                hotel.Status = (int)HotelStatusEnum.Trial;

                var reuslt = _hotelRepository.Insert(hotel);
                if (reuslt > 0)
                {
                    var routingEntity = new RoutingAccount()
                    {
                        HID = hotel.HID,
                        AccountID = model.AccountID,
                        IsAdmin = true,
                        IsDeleted = false,
                        UpdateTime = DateTime.Now
                    };
                    reuslt = _routingAccountRepository.Insert(routingEntity);
                }
                return reuslt > 0;
            }
        }
        public int Update(HotelInfoDto model)
        {
            if (model == null)
            {
                return 0;
            }
            else
            {
                var account = ConvertFromDto(model);
                return _hotelRepository.UpdateNonDefaults(account, x => x.HID == account.HID);
            }
        }
        public bool Delete(string HID)
        {
            if (string.IsNullOrEmpty(HID))
            {
                return false;
            }
            else
            {
                var account = _hotelRepository.Single(a => (a.HID == HID));
                _hotelRepository.Delete(account);
                return true;
            }
        }

        private static HotelInfoDto ConvertFromRepositoryEntity(HotelFullInfo hotelInfo)
        {
            if (hotelInfo == null)
            {
                return null;
            }
            var hotelDto = new HotelInfoDto
            {
                HID = hotelInfo.HID,
                HAddress = hotelInfo.HAddress,
                HFax  = hotelInfo.HFax,
                HName = hotelInfo.HName,
                HPhone = hotelInfo.HPhone,
                IsAdmin = hotelInfo.IsAdmin.Value,
                IsDeleted = hotelInfo.IsDeleted.Value,
                Remark = hotelInfo.Remark,
                Status = hotelInfo.Status.Value,
                CreateTime = hotelInfo.CreateTime.Value,
                UpdateTime = hotelInfo.UpdateTime.Value,
            };
            if (hotelInfo.HLocationX != null)
            {
                hotelDto.HLocationX = hotelInfo.HLocationX.Value;
            }
            if (hotelInfo.HLocationY != null)
            {
                hotelDto.HLocationY = hotelInfo.HLocationY.Value;
            }
            return hotelDto;
        }

        private static HotelInfoDto ConvertFromRepositoryEntity(HotelInfo hotelInfo)
        {
            if (hotelInfo == null)
            {
                return null;
            }
            var hotelDto = new HotelInfoDto
            {
                HID = hotelInfo.HID,
                HAddress = hotelInfo.HAddress,
                HFax = hotelInfo.HFax,
                HName = hotelInfo.HName,
                HPhone = hotelInfo.HPhone,
                IsDeleted = hotelInfo.IsDeleted.Value,
                Remark = hotelInfo.Remark,
                Status = hotelInfo.Status.Value,
                CreateTime = hotelInfo.CreateTime.Value,
                UpdateTime = hotelInfo.UpdateTime.Value,
            };
            if (hotelInfo.HLocationX != null)
            {
                hotelDto.HLocationX = hotelInfo.HLocationX.Value;
            }
            if (hotelInfo.HLocationY != null)
            {
                hotelDto.HLocationY = hotelInfo.HLocationY.Value;
            }
            return hotelDto;
        }

        private static HotelInfo ConvertFromDto(HotelInfoDto hotelInfoDto)
        {
            if (hotelInfoDto == null)
            {
                return null;
            }
            var hotel = new HotelFullInfo
            {
                HID = hotelInfoDto.HID,
                HAddress = hotelInfoDto.HAddress,
                HFax = hotelInfoDto.HFax,
                HName = hotelInfoDto.HName,
                HPhone = hotelInfoDto.HPhone,
                Remark = hotelInfoDto.Remark
            };
            if (hotelInfoDto.HLocationX > 0)
            {
                hotel.HLocationX = hotelInfoDto.HLocationX;
            }
            if (hotelInfoDto.HLocationY > 0)
            {
                hotel.HLocationY = hotelInfoDto.HLocationY;
            }
            if (!hotelInfoDto.IsAdmin)
            {
                hotel.IsAdmin = hotelInfoDto.IsAdmin;
            }
            if (!hotelInfoDto.IsDeleted)
            {
                hotel.IsDeleted = hotelInfoDto.IsDeleted;
            }

            if (hotelInfoDto.Status > 0)
            {
                hotel.Status = hotelInfoDto.Status;
            }

            if ((hotelInfoDto?.CreateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                hotel.CreateTime = hotelInfoDto.CreateTime;
            }
            if ((hotelInfoDto?.UpdateTime ?? DateTime.MinValue) > DateTime.MinValue)
            {
                hotel.UpdateTime = hotelInfoDto.UpdateTime;
            }
            return hotel;
        }
    }
}
