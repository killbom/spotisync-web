using Microsoft.Extensions.DependencyInjection;
using SpotiSync_Web.Infrastructure.Interfaces;
using SpotiSync_Web.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiySync_Web.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
