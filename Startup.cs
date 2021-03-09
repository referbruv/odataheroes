using System.Linq;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using ODataCore3.API.Contracts;
using ODataCore3.API.Models;
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
            services.AddDbContext<ReadersContext>(options =>
            {
                options.UseSqlite("Filename=app.db");
            });

            services.AddScoped<IReadersRepo, ReadersRepo>();

            services.AddOData();

            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();

            SeedData(app);

            IEdmModel model = EdmModelBuilder.Build();

            app.UseRouting();

            app.UseEndpoints(options =>
            {
                options.Select().Expand().Filter().OrderBy().MaxTop(1000).Count();
                options.MapODataRoute("odata", "odata", model);
                options.MapDefaultControllerRoute();
            });
        }

        private void SeedData(IApplicationBuilder app)
        {
            using (var sp = app.ApplicationServices.CreateScope())
            {
                var db = sp.ServiceProvider.GetRequiredService<ReadersContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                for (int i = 1001; i <= 1100; i++)
                {
                    db.Users.Add(new User
                    {
                        Id = i,
                        UserName = $"User#{i}",
                        EmailAddress = $"user.{i}@abc.com",
                        IsActive = true
                    });
                    db.Readers.Add(new Reader
                    {
                        Id = i,
                        Name = $"Reader#{i}",
                        AddedOn = System.DateTime.Now,
                        Description = "Loreum Ipseum Loreum Ipseum",
                        UserId = i
                    });
                }

                db.SaveChanges();
            }
        }
    }
}
