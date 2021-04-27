using Application.Security.Jwt;
using Application.Services.Abstract;
using Application.Services.Concrete;
using Cache.Concrete;
using Cache.Interfaces;
using Core.Cache;
using Core.Entities.Concrete;
using Core.Entities.Concrete.UserEntities;
using Core.Interfaces;
using Core.Interfaces.Security;
using Core.Repositories;
using DAL.DTO;
using DAL.DTO.User;
using DAL.PostgresqlRepo;
using DAL.PostgresqlRepo.Abstract;
using DAL.PostgresqlRepo.DbClients;
using Infrastructure.Automappers;
using Infrastructure.Cache;
using Infrastructure.Logging;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmsService.Concrete;
using SmsService.Interfaces;
using SocialApis.Authoriazation;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApis
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddMemoryCache();
            services.AddAuthentication();
            services.AddMvc();
            services.AddScoped<IAppLogger<Controllers.HomeApiController>, AppLogger<Controllers.HomeApiController>>();
            services.AddScoped<IAppLogger<Controllers.UserApiController>, AppLogger<Controllers.UserApiController>>();
            services.AddScoped<IAppLogger<Controllers.AccountManagementApiController>, AppLogger<Controllers.AccountManagementApiController>>();
            //IAppLogger<AccountManagementApiController> 
            //services.AddSingleton<IConnectionMultiplexer>(options=>
            //ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection"))
            //);
            //services.AddDbContext<PostgreSqlContext>(options =>
            //options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")).UseSnakeCaseNamingConvention());
            //services.AddScoped<IHomePostgreSqlDbClient, HomePostgreSqlDbClient>();
            //services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddResponseCompression();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            ConfigureApplication(services);
            ConfigureInfrastructure(services);
            ConfigureAutomappers(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseMiddleware<ApplicationAuthenticationMiddleware>();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseResponseCompression();
            //for jwt
            app.UseAuthentication();
        }
        public void ConfigureApplication(IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtAccountTokenGenerator, JwtAccountTokenGenerator>();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IHomeCache, HomeCache>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IAccountService, AccountService>();
        }
        public void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddSingleton<IConnectionMultiplexer>(options =>
            ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection"))
            );
            services.AddDbContext<PostgreSqlContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("PostgreSqlConnectionString")).UseSnakeCaseNamingConvention());
            services.AddScoped<IHomePostgreSqlDbClient, HomePostgreSqlDbClient>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IUserRepository<User>, UserRepository>();
            services.AddScoped<ISessionRepository<UserSessions>, SessionRepository>();
            services.AddScoped<ISessionDbClient<UserSessionsDTO>, SessionDbClient>();
            services.AddScoped<IUserPostgreSqlDbClient<UserDTO>, UserPostgreSqlDbClient>();
            services.AddScoped<ISmsClientFactory, SmsClientFactory>();
            services.AddScoped<ISmsService, SmsServiceInfra>();
            services.AddScoped<ICacheClient, RedisCacheClient>();
            services.AddScoped<IAccountRepository<User>, AccountRepository>();
        }
        public void ConfigureAutomappers(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
