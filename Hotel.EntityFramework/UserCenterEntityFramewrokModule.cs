using Hotel.Core;
using Lib.EntityFramework.EntityFramework;
using LibMain.Dependency;
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
    public class UserCenterEntityFramewrokModule:LibMain.Modules.Module
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "CDHotelUserCenter";
        }

        public override void Initialize()
        {
            var config = new ConventionalRegistrationConfig
            {
                InstallInstallers = false
            };
            config["nameOrConnectionString"] = "CDHotelUserCenter";
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(), config);

            //执行一次.
            IocManager.Resolve<UserCenterDbContext>();
        }
    }
}
