using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Layer.Architecture.Application.Models;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.Interfaces;
using Layer.Architecture.Infrastructure.Data.Context;
using Layer.Architecture.Infrastructure.Data.Repository;
using Layer.Architecture.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Layer.Architecture.Application
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

            services.AddDbContext<MySqlContext>(options =>
            {
                var server = Configuration["database:mysql:server"];
                var port = Configuration["database:mysql:port"];
                var database = Configuration["database:mysql:database"];
                var username = Configuration["database:mysql:username"];
                var password = Configuration["database:mysql:password"];

                options.UseMySql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<SomeEntity>, BaseRepository<SomeEntity>>();

            services.AddScoped<IBaseService<SomeEntity>, BaseService<SomeEntity>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateSomeEntityModel, SomeEntity>();
                config.CreateMap<UpdateSomeEntityModel, SomeEntity>();
                config.CreateMap<SomeEntity, SomeEntityModel>();
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
