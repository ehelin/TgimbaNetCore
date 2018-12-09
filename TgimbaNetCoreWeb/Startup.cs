using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;				   
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.interfaces;    
using Shared;            
using API;

namespace TgimbaNetCoreWeb
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
			ITgimbaService service = new TgimbaService(); 

            services.AddSingleton<ITgimbaService>(service);																  
			services.AddSingleton<IWebClient>(new WebClient(service));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();      
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
				routes.MapRoute(
					name: "welcome",
					template: "{controller=Welcome}/{action=Index}/{id?}");

				routes.MapRoute(
					name: "vanillaJsEntry",
					template: "{controller=Home}/{action=HtmlVanillaJsIndex}/{id?}");

				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=HtmlJQueryIndex}/{id?}");

				routes.MapSpaFallbackRoute(
					name: "spa-fallback",
					defaults: new { controller = "Home", action = "HtmlVanillaJsIndex" });
			});
        }
    }
}
