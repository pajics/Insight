using System;
using System.Linq;
using Insight.Core;
using Insight.Core.Identity;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Insight
{
    public class Startup
    {
        //http://blogs.msdn.com/b/webdev/archive/2014/06/17/dependency-injection-in-asp-net-vnext.aspx
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EmployeeQueries, EmployeeQueries>();
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Entity Framework services to the services container.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                });


            // Add Identity services to the services container.
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            //services.AddMvc().Configure<MvcOptions>(opt =>
            //{
            //    opt.InputFormatters.Clear();

            //    var jsonOutputFormatter = new JsonOutputFormatter();

            //    jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //    jsonOutputFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

            //    var outputToRemove = opt.OutputFormatters.FirstOrDefault(formatter => formatter.GetType() == typeof(JsonOutputFormatter)) as JsonOutputFormatter;
            //    opt.OutputFormatters.Remove(outputToRemove);
            //    opt.OutputFormatters.Insert(0, jsonOutputFormatter);
            //});

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Add the following to the request pipeline only in development environment.
            //if (env.IsDevelopment())
            //{
            //    //app.UseBrowserLink();
            //    app.UseErrorPage();
            //    app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            //}
            //else
            //{
            //    // Add Error handling middleware which catches all application specific errors and
            //    // sends the request to the following path or controller action.
            //    app.UseErrorHandler("/Home/Error");
            //}

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
            app.UseMvc();
        }


        public Startup(IApplicationEnvironment env, IRuntimeEnvironment runtimeEnvironment)
        {
            //Below code demonstrates usage of multiple configuration sources. For instance a setting say 'setting1' is found in both the registered sources, 
            //then the later source will win. By this way a Local config can be overridden by a different setting while deployed remotely.
            var builder = new ConfigurationBuilder(env.ApplicationBasePath)
                        .AddJsonFile("config.json")
                        .AddEnvironmentVariables(); //All environment variables in the process's context flow in as configuration values.

            Configuration = builder.Build();
        }
    }
}
