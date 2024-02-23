using DAL.Repository;
using DAL.Entities;
using DAL.Mapping;
using DAL.Helpers;
using BAL.Domain;
using BAL.Gateways.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BAL.Interfaces;
using BAL.UseCases;

namespace Asp.NetCoreWebApiCRUD
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public IConfiguration _config { get; }

        //this method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonDbContext>();
            services.AddControllers();
            services.AddHttpClient();
            AutoMapperService(services);
            UseCaseServices(services);
            RepositoryServices(services);            
            
            //services.AddTransient<IPersonsRepository<Person>, RepositoryPerson>();
            // DatabaseConnectionServices(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Asp.NetCoreWebApiCRUD", Version = "v1" });
            });
        }

        private void AutoMapperService(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MappingProfiles>(), typeof(Startup));
        }

        //private void DatabaseConnectionServices(IServiceCollection services)
        //{
        //    var connectionString = new PersonDbContext(_config.GetConnectionString("PersonDbConnectionString"));
        //    services.AddSingleton(connectionString);
        //}

        private void RepositoryServices(IServiceCollection services)
        {
            services.AddTransient<IPersonsRepository, RepositoryPerson>();
        }
        private void UseCaseServices(IServiceCollection services)
        {
            services.AddTransient<ICreatePersonUseCase, CreatePersonUseCase>();

        }

        //
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asp.NetCoreWebApiCRUD v1"));
                {
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
    }
}
