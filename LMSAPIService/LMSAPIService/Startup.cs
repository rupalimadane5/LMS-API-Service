using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSAPI.BusinessLayer;
using LMSAPI.DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace LMSAPI.Service
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IServiceCollection Services { get; set; }

        /// <summary>
        ///     Startup
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false)//TODO: Allow to be optional after debug
                .AddEnvironmentVariables();//local environment can override anything set in deployed configuration files
            Configuration = builder.Build();
        }


        /// <summary>
        ///     This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            //services.AddMvc();

            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(new JsonOutputFormatter(
                    new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    },
                    ArrayPool<char>.Shared));
            });
            // Add EF services to the services container
            services.AddEntityFrameworkSqlServer();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<LMSDataContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            // Add Application Insights
            services.AddApplicationInsightsTelemetry(Configuration);


            // Add instances - lifetime of the service
            services.AddSingleton(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add instances
            services.AddScoped<ILMSContext, LMSDataContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IManageLeaveRepository, ManageLeaveRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IManageLeaveManager, ManageLeaveManager>();
        }

        /// <summary>
        ///     This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Set Environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            // Add the Swagger UI
        }
    }
}
