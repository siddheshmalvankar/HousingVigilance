using DBAccess.HousingVigilance.Domain;
using DBAccess.HousingVigilance.Domain.Interfaces;
using Infra.HousingVigilance.Execution;
using Infra.HousingVigilance.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.HousingVigilance.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntergration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });

        }

        public static void ConfigureTransientAppService(this IServiceCollection services)
        {

           

        }

        public static void ConfigureSingletonAppService(this IServiceCollection services)
        {
            services.AddSingleton<IMediator, DefaultMediator>();
            services.AddSingleton<ILog, ApplicationLog>();         


        }

        public static void ConfigureScopeonAppService(this IServiceCollection services)
        {

            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IResolver, ServiceLocator>();
            services.AddScoped<IAuditLogger, AuditLogger>();

        }
    }
}
