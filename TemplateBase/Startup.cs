using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplateBase.Core.Interfaces;
using TemplateBase.Core.Services;
using TemplateBase.Infrastructure;
using TemplateBase.Infrastructure.Repositories;

namespace TemplateBase
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
            services.AddDbContext<DBTestContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TestDB"));
            });

            // For use Injection of Dependecy. Exist 3 types:
            //Singleton: ASP.net core will create and share a single instance of the service through the application life.
            //Transient: ASP.net core will create and share an instance of the service every time to the application when we ask for it. 
            //Scoped:ASP.net core will create and share an instance of the service per request to the application. It means that a single instance of service is available per request 
            
            // Services
            services.AddTransient<ITestClassService, TestClassService>();

            // Repositories
            services.AddTransient<ITestClassRepository, TestClassRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Used for migrate the context to DB to start the app
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DBTestContext>();
                context.Database.Migrate();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
