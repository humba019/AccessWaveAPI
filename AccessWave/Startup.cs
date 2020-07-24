using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessWave.Persistence.Context;
using AccessWave.Persistence.Repositories;
using AccessWave.Persistence.Repositories.Interface;
using AccessWave.Services;
using AccessWave.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace AccessWave
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
            services.AddDbContext<DatabaseContext>(opt => {
                opt.UseInMemoryDatabase("accesswave");
            });

            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IControlRepository, ControlRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IRuleRepository, RuleRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IControlService, ControlService>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IRuleService, RuleService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddHealthChecks();
            services.AddControllers();
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
