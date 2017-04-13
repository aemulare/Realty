using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Realty
{
   public class Startup
   {
      public void ConfigureServices(IServiceCollection services)
      {
         services.AddMvc();
         services.AddMemoryCache();
         services.AddSession();
      }



      public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
      {
         app.UseDeveloperExceptionPage();
         app.UseStatusCodePages();
         app.UseStaticFiles();
         app.UseSession();
         app.UseMvcWithDefaultRoute();
      }
   }
}
