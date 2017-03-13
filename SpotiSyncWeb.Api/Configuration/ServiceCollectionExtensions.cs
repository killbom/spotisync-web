using Microsoft.Extensions.DependencyInjection;
using SpotiSyncWeb.Infrastructure.Interfaces;
using SpotiSyncWeb.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotiSyncWeb.Configuration
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
