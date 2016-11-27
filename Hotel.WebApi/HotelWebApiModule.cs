using Hotel.Application;
using Lib.Application.Services;
using Lib.Web.Api;
using Lib.WebApi.Controllers.Dynamic.Builders;
using LibMain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.WebApi
{
    [DependsOn(typeof(WebApiModule), typeof(HotelApplicationModule))]
    public class HotelWebApiModule : LibMain.Modules.Module
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(HotelApplicationModule).Assembly, "app")
                .Build();

        }
    }
}
