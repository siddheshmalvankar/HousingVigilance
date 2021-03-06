﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBAccess.HousingVigilance.Domain;
using Infra.HousingVigilance.Execution;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using WebApi.HousingVigilance.Extensions;

namespace WebApi.HousingVigilance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIISIntergration();
          
            services.ConfigureTransientAppService();
            services.ConfigureSingletonAppService();
            services.ConfigureScopeonAppService();

            ServiceLocator.SetLocatorProvider(services.BuildServiceProvider());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<HousingVigilanceContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("HousingVigilance"), b => b.MigrationsAssembly("WebApi.HousingVigilance")),ServiceLifetime.Scoped);    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
