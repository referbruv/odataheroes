using System.Linq;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using ODataCore3.API.Contracts;
using ODataCore3.API.Providers;

namespace ODataCore3.API
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
            services.AddControllers();
            services.AddScoped<IReadersContext, ReadersContext>();
            services.AddScoped<IReadersRepo, ReadersRepo>();
            services.AddOData();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            IEdmModel model = EdmModelBuilder.Build();

            app.UseOData(model);

            app.UseMvc(builder =>
            {
                builder.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();
                builder.MapODataServiceRoute("odata", "odata", model);
                builder.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
