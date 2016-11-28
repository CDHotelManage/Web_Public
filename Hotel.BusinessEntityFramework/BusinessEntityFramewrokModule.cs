using Hotel.BusinessEntityFramework.Repositories;
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

namespace Hotel.BusinessEntityFramework
{
    [DependsOn(typeof(LibEntityFrameworkModule), typeof(HotelCoreModule))]
    public class BusinessEntityFramewrokModule : LibMain.Modules.Module
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "CDHotelBusiness";
        }

        public override void Initialize()
        {
            var config = new ConventionalRegistrationConfig
            {
                InstallInstallers = false
            };
            config["nameOrConnectionString"] = "CDHotelBusiness";
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(), config);            
            //执行一次.
            IocManager.Resolve<BusinessDbContext>();
        }
    }
}
