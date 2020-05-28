using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Resturant.Domain.Entities.ResponseModel;
using Resturant.Domain.Interfaces;
using Resturant.Infrastructure.Data;
using Resturant.Services;
using Resturant.Services.Interfaces;
using Together_DB.Context;

namespace Together
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
            //jwt start 
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretDataPattern);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddHttpContextAccessor();
            //jwt end
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(Configuration["ConnectionDBString:ConnectionServer"]));

            services.AddControllers();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ITestRepository, TestRepository>();

            services.AddTransient<IUserTypeService, CommonService>();
            services.AddTransient<ILocationService, CommonService>();
            services.AddTransient<IStatusService, CommonService>();

            services.AddTransient<IUserTypeRepository, CommonRepository>();
            services.AddTransient<ILocationRepository, CommonRepository>();
            services.AddTransient<IStatusRepository, CommonRepository>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            //order Place
            services.AddTransient<IOrderServiceEntry, OrderService>();
            services.AddTransient<IOrderServiceUpdate, OrderService>();
            services.AddTransient<IOrderServiceDelete, OrderService>();
            services.AddTransient<IOrderItemServiceUpdate, OrderService>();
            services.AddTransient<IOrderItemServiceDelete, OrderService>();

            services.AddTransient<IOrderRepositoryEntry, OrderRepository>();
            services.AddTransient<IOrderRepositoryUpdate, OrderRepository>();
            services.AddTransient<IOrderRepositoryDelete, OrderRepository>();
            services.AddTransient<IOrderItemRepositoryEntry, OrderRepository>();
            services.AddTransient<IOrderItemRepositoryUpdate, OrderRepository>();
            services.AddTransient<IOrderItemRepositoryDelete, OrderRepository>();


            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICheckCustomerRepositoryExists, CustomerRepository>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeCheckExistsRepository, EmployeeRepository>();
            
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ILoginRepository, LoginRepository>();

            services.AddTransient<IJwtSecurityService, JwtSecurityService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
