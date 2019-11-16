using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Host4Travel.BLL.Abstract;
using Host4Travel.BLL.Concrete;
using Host4Travel.Core.Exceptions;
using Host4Travel.Core.MappingProfiles;
using Host4Travel.Core.SystemProperties;
using Host4Travel.DAL.Abstract;
using Host4Travel.DAL.Concrete.EntityFramework;
using Host4Travel.UI;
using Host4Travel.UI.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Host4Travel.API
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
            ConfigureAutoMapperService(services);
            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
            
            ConfigureInjections(services);


   
            
            
            
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(
                    Configuration.GetConnectionString("Host4Travel"), b => b.MigrationsAssembly("Host4Travel.UI"));
            });

            services.AddIdentity<ApplicationIdentityUser, ApplicationIdentityRole>(options => { })
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


       
            var key = Encoding.ASCII.GetBytes(Core.SystemProperties.Configuration.SecretKey);
            
            
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

            // configure DI for application services
        }

        private static void ConfigureAutoMapperService(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void ConfigureInjections(IServiceCollection services)
        {
            services.AddScoped<IExceptionHandler, ExceptionHandler>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<IRewardDal, EfRewardRepository>();
            services.AddScoped<IRewardService, RewardManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPasswordHasher<ApplicationIdentityUser>, PasswordHasher<ApplicationIdentityUser>>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "api/{controller=Users}/{action=Get}/{id?}");
            });
        }
    }
}