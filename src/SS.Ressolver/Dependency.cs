using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SS.BussinessLogic.Interface;
using SS.BussinessLogic;
using SS.DataService.Interface;
using SS.DataService;

namespace SS.Ressolver
{
    public static class Dependency
    {
        public static void RessolveFor(IServiceCollection services)
        {
            RegisterBusinessServices(services);
            RegisterDataServices(services);
        }
        private static void RegisterBusinessServices(IServiceCollection services)
        {

            services.AddTransient<IUserBusinessService, UserBussinessService>();

        }

        /// <summary>
        /// Register Data services
        /// </summary>
        private static void RegisterDataServices(IServiceCollection services)
        {

            services.AddTransient<IUserDataService, UserDataService>();
        }
    }
}
