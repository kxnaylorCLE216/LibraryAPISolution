using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAPI.Data;
using LibraryAPI.Profiles;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryAPI
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
            services.AddControllers();

            services.AddTransient<IProvideServerStatusInformation, HealthMonitoringApiServerStatus>();

            services.AddDbContext<LibraryDataContext>(options =>
            { 
                options.UseSqlServer(@"server=.\sqlexpress;database=books_prod;integrated security=true");
            });

            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<BooksProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton<MapperConfiguration>(mapperConfiguration);
            services.AddSingleton<IMapper>(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
