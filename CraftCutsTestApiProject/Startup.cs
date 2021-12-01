using CraftCutsTestApiProject.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftCutsTestApiProject.Contracts;
using CraftCutsTestApiProject.Repositories;
using Microsoft.AspNetCore.SignalR;
using CraftCutsTestApiProject.Logic;

namespace CraftCutsTestApiProject
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
            services.AddSingleton<DapperContext>();
            
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IDemoBeardRepository, DemoBeardRepository>();
            services.AddScoped<IHairCutRepository, HairCutRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingListRepository, BookingListRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IPromocodeRepository, PromocodeRepository>();
            services.AddScoped<IIdGetterRepository, IdGetterRepository>();
            services.AddScoped<IBarberRepository, BarberRepository>();
            services.AddScoped<IBookingLogic, BookingLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CraftCutsTestApiProject", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
       
                    .WithOrigins("http://localhost:64169", "http://localhost:3000"));
            });
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseRouting();
            app.UseCors("CorsPolicy");
            
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<InformHub>("/InformHub");
            });
        }
    }
}
