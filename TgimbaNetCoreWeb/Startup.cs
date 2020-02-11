using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;
using Algorithms.Algorithms.Search;
using Algorithms.Algorithms.Search.Implementations;
using APINetCore;
using BLLNetCore.helpers;
using BLLNetCore.Security;  // TODO - remove after namespaces changed to bllnetcore.helpers
using DALNetCore;
using DALNetCore.helpers;
using DALNetCore.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.interfaces;
using TgimbaNetCoreWebShared;
using System.Collections.Generic;

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
            // TODO - make a configuration item
            var host = "http://localhost:56675/";    	
            //var host = "https://www.tgimba.com";
            services.AddSingleton<IWebClient>(new WebClient(host, new TgimbaHttpClient()));

            IUserHelper userHelper = new UserHelper();
            BucketListContext context = new BucketListContext(true); // TODO - make this configurable
            IBucketListData bucketListData = new BucketListData(context, userHelper);
            IPassword passwordHelper = new PasswordHelper();
            IGenerator generatorHelper = new GeneratorHelper();
            IString stringHelper = new StringHelper();
            var sortingAlgorithms = new List<ISort>() { new LinqSort(), new BubbleSort() };
            var availableSortingAlgorithms = new AvailableSortingAlgorithms(sortingAlgorithms);
            ISearch searchAlgorithm = new LinqSearch(); // TODO - update to load dynanically
            ITgimbaService service = new TgimbaService(bucketListData, passwordHelper,
                                                        generatorHelper, stringHelper,
                                                        availableSortingAlgorithms, searchAlgorithm);

            services.AddSingleton<ITgimbaService>(service);
            services.AddSingleton<IValidationHelper>(new ValidationHelper());

            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
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
