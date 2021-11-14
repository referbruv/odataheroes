using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ODataHeroes.Contracts.Data.Repositories;
using ODataHeroes.Core.Data.Repositories;
using ODataHeroes.Migrations;

namespace ODataHeroes.API
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
            services.AddDbContext<DatabaseContext>((builder) =>
            {
                builder.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection"),
                    (x) => x.MigrationsAssembly("ODataHeroes.Migrations"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", EdmModelBuilder.Build()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
