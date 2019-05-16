using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EG.Core.Dependency;
using EG.Model.CustomModels.ConnectionDatabase;
using EG.Security.JWT.Dependency;
using EG.Security.JWT.Policy.Core;
using EG.Web.Core.StaticConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EG.API
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
            GetConfigs();
            
            services.AddDependency();
            services.AddDependencyServices();
            services.AddDependencyRepository();
            var listAudiences = new List<string>(){
                SystemConfigs.SystemName.AllSystem.ToString()
            };
            services.AddDependencyJWT(JWTConfigs.APISecurityJWTIssuer, listAudiences, JWTConfigs.APISecurityJWTKey);
            services.AddPolicy();
            services.Configure<MongoConnection>(options =>
            {
                options.Server = Configuration.GetSection("MongoConnection:Server").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration.GetSection("RedisConnection:Server").Value;
                option.InstanceName = Configuration.GetSection("RedisConnection:InstanceName").Value;
            });
            // Để sau config mongodb để lúc load Schema có connection string mongodb
            services.AddDependencyGraphQL();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
        private void GetConfigs()
        {
            //DatabaseEntities.ConnectionString = Configuration.GetConnectionString("TestConnection");
            JWTConfigs.APISecurityJWTKey = Configuration["Jwt:Key"];
            JWTConfigs.APISecurityJWTIssuer = Configuration["Jwt:Issuer"];
            JWTConfigs.APISecurityJWTExpriedDays = double.Parse(Configuration["Jwt:ExpriedDays"]);
            JWTConfigs.APISecurityJWTExpriedHours = double.Parse(Configuration["Jwt:ExpriedHours"]);
            JWTConfigs.APISecurityJWTExpriedMinutes = double.Parse(Configuration["Jwt:ExpriedMinutes"]);
        }
    }
}
