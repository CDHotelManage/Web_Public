﻿using Hotel.BusinessEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application
{
    public class HotelApplicationModule : LibMain.Modules.Module
    {
        public override void Initialize()
        {            
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
