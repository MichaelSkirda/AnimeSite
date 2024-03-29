using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeSite.Database;
using AnimeSite.Database.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace AnimeSite
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();  // добавляем сервисы MVC

            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст ApplicationContext в качестве сервиса в приложение
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));


            services.AddControllersWithViews();

            services.AddScoped(typeof(PostService));
            services.AddScoped(typeof(EntitiesService));
            services.AddScoped(typeof(ViewModelService));
            services.AddScoped(typeof(CommentService));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting(); // используем систему маршрутизации

            app.UseStaticFiles();
            app.UseForwardedHeaders();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}