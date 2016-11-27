using Hotel.Core;
using Lib.EntityFramework.EntityFramework;
using LibMain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.EntityFramework
{
    [DependsOn(typeof(LibEntityFrameworkModule), typeof(HotelCoreModule))]
    public class HotelEntityFramewrokModule:LibMain.Modules.Module
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "CDHotelUserCenter";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //执行一次.
            IocManager.Resolve<UserCenterDbContext>();
        }
    }
}
