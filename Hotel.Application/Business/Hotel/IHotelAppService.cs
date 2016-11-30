using Hotel.Application.Business.Hotel.Dto;
using Lib.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Business.Hotel
{
    public interface IHotelAppService: IApplicationService
    {

        HotelInfoDto GetHotelInfo(HotelInfoDto model);
        HotelInfoDto GetHotelInfo(string HID);
        List<HotelInfoDto> GetAllHotelInfo(HotelInfoDto model);
        bool Add(HotelInfoDto model);
        int Update(HotelInfoDto model);
        bool Delete(string HID);
    }
}
