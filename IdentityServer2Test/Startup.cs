using System;
using System.Reflection;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.IdentityServer4;
using Castle.Facilities.Logging;
using IdentityServer2Test.InternalClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestProject.Authentication.JwtBearer;
using TestProject.Authorization.Users;
using TestProject.EntityFrameworkCore;
using TestProject.Identity;

namespace IdentityServer2Test
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
            
            IdentityRegistrar.Register(services);
            services.AddMvc();
           
            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                //.AddTestUsers(Users.Get())
                .AddDeveloperSigningCredential()
                .AddAbpPersistedGrants<TestProjectDbContext>()
                .AddInMemoryPersistedGrants()
                .AddAbpIdentityServer<User>();
            
            
            return services.AddAbp<IdentityServerServiceModel>(options =>
            {
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAbp();
            
            app.UseStaticFiles();
            //app.UseJwtTokenMiddleware("IdentityBearer");
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
            
            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
