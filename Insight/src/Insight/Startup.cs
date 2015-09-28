using System;
using System.Linq;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Insight
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().Configure<MvcOptions>(opt =>
            {
                opt.InputFormatters.Clear();

                var jsonOutputFormatter = new JsonOutputFormatter();

                jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                jsonOutputFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

                var outputToRemove = opt.OutputFormatters.FirstOrDefault(formatter => formatter.GetType() == typeof(JsonOutputFormatter)) as JsonOutputFormatter;
                opt.OutputFormatters.Remove(outputToRemove);
                opt.OutputFormatters.Insert(0, jsonOutputFormatter);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
            app.UseMvc();
        }
    }
}
