using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HentaiSite.Database;
using HentaiSite.Database.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HentaiSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();  // добавляем сервисы MVC
            ApplicationContext db = new ApplicationContext();
            services.AddSingleton(new PostService(db));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting(); // используем систему маршрутизации

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}