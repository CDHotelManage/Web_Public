using Hotel.Core;
using Lib.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application
{
    public class HotelAppServiceBase : ApplicationService
    {
        protected HotelAppServiceBase()
        {
            LocalizationSourceName = HotelConsts.LocalizationSourceName;
        }
    }
}
