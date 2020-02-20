using System.Collections.Generic;
using Algorithms.Algorithms.Search;
using Algorithms.Algorithms.Search.Implementations;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;
using APINetCore;
using BLLNetCore.Security;  // TODO - remove after namespaces changed to bllnetcore.helpers
using BLLNetCore.helpers;
using DALNetCore;
using DALNetCore.helpers;
using DALNetCore.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.interfaces;
using TgimbaNetCoreWebShared;

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
            SetUpDI(services);
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        private void SetUpDI(IServiceCollection services)
        {
            services.AddSingleton<IWebClient>(new WebClient(Configuration["ApiHost"], new TgimbaHttpClient()));
            services.AddSingleton<IUserHelper>(new UserHelper());
            
            // true load test db connection, false load prod db connection
            services.AddSingleton(new BucketListContext
            (
                Configuration["Env"] != null 
                    && Configuration["Env"] == "Development"
                        ? true
                            : false
            ));
            services.AddSingleton<IBucketListData>(x =>
                new BucketListData(x.GetRequiredService<BucketListContext>(),
                                   x.GetRequiredService<IUserHelper>()
                                   ));
            services.AddSingleton<IPassword>(new PasswordHelper());
            services.AddSingleton<IGenerator>(new GeneratorHelper());
            services.AddSingleton<IString>(new StringHelper());

            // TODO - replace single ISearch w/searching algorithm class
            services.AddSingleton<ISearch>(new LinqSearch());
            //services.AddSingleton(new AvailableSearchingAlgorithms(
            //    new List<ISearch>()
            //    {
            //            new LinqSearch(),
            //            new BinarySearch()
            //     }
            // ));

            services.AddSingleton(new AvailableSortingAlgorithms(
                new List<ISort>() 
                { 
                    new LinqSort(), 
                    new BubbleSort(), 
                    new InsertionSort() 
                 }
             ));
            services.AddSingleton<ITgimbaService>(x =>
                new TgimbaService(x.GetRequiredService<IBucketListData>(),
                                   x.GetRequiredService<IPassword>(),
                                   x.GetRequiredService<IGenerator>(),
                                   x.GetRequiredService<IString>(),
                                   x.GetRequiredService<AvailableSortingAlgorithms>(),
                                   x.GetRequiredService<ISearch>()
                                   ));
            services.AddSingleton<IValidationHelper>(new ValidationHelper());
            services.AddSingleton<IConfiguration>(Configuration);
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
            app.UseHttpsRedirection();  // TODO - add local flag to handle
            
            app.UseSession();

            app.UseMvc(routes =>
            {
				routes.MapRoute(
					name: "welcome",
					template: "{controller=Welcome}/{action=Index}/{id?}");
			});
        }
    }
}
