using CdHotelManage.Model;
using Hotel.Application.Business.Hotel;
using Hotel.Application.Business.Hotel.Dto;
using LibMain.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ApplictionFactory.Business
{
    public class ShopBridge
    {
        public static shopInfo GetModel(string hotelID)
        {
            IHotelAppService service = IocManager.Instance.Resolve<IHotelAppService>();
            if (service == null)
            {
                return null; ;
            }
            else
            {
                var hotelDto = service.GetHotelInfo(hotelID);
                return ConvertFromDto(hotelDto);
            }
        }

        private static HotelInfoDto ConvertFromBllEntity(shopInfo shop)
        {
            if (shop == null)
            {
                return null;
            }
            HotelInfoDto accountDto = new HotelInfoDto()
            {
                HAddress = shop.Shop_Address,
                HFax = shop.Shop_chuanzen,
                HID = shop.id,
                HLocationX = float.Parse(shop.Shop_x),
                HLocationY = float.Parse(shop.Shop_y),
                HName = shop.shop_Name,
                HPhone = shop.Shop_Telphone,
                Remark = shop.Shop_Remaker,
                CreateTime = shop.Shop_date.Value
            };
            return accountDto;
        }

        private static shopInfo ConvertFromDto(HotelInfoDto hotelDto)
        {
            if (hotelDto == null)
            {
                return null;
            }
            shopInfo user = new shopInfo()
            {
                Shop_Address= hotelDto.HAddress,
                Shop_chuanzen = hotelDto.HFax,      
                id= hotelDto.HID,      
                Shop_x = hotelDto.HLocationX.ToString(),
                Shop_y= hotelDto.HLocationY.ToString(),
                shop_Name= hotelDto.HName,    
                Shop_Telphone= hotelDto.HPhone, 
                Shop_Remaker= hotelDto.Remark, 
                Shop_date= hotelDto.CreateTime
            };
            return user;
        }
    }
}
