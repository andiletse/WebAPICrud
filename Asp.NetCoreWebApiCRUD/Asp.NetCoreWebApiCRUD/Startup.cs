using DAL.Repository;
using DAL.Mapping;
using DAL.Helpers;
using BAL.Gateways.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
            services.AddControllers();
            services.AddDbContext<System1DbContext>();
            services.AddHttpClient();           
            AutoMapperService(services);           
            UseCaseServices(services);
            RepositoryServices(services);
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

        private void RepositoryServices(IServiceCollection services)
        {
            services.AddScoped<ISystem1_ObjectName_Repository, RepositorySystem1_ObjectName_>();
        }

        private void UseCaseServices(IServiceCollection services)
        {
            services.AddTransient<ICreateSytem1_ObjectName_UseCase, CreateSystem1_ObjectName_UseCase>();

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
