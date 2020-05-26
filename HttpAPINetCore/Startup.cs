using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms.Search;
using Algorithms.Algorithms.Search.Implementations;
using Algorithms.Algorithms.Sorting;
using Algorithms.Algorithms.Sorting.Implementations;
using APINetCore;
using BLLNetCore.helpers;
using BLLNetCore.Security;  // TODO - remove after namespaces changed to bllnetcore.helpers
using DALNetCore;
using DALNetCore.helpers;
using DALNetCore.interfaces;
using HttpAPINetCore.helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.interfaces;
using Swashbuckle.AspNetCore.Swagger;
//using TgimbaNetCoreWebShared;

namespace HttpAPINetCore
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
            services.AddMvc();//.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "TgimbaApi"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            //IUserHelper userHelper = new UserHelper();
            //BucketListContext context = new BucketListContext();
            //IBucketListData bucketListData = new BucketListData(context, userHelper);
            //IPassword passwordHelper = new PasswordHelper();
            //IGenerator generatorHelper = new GeneratorHelper();
            //IString stringHelper = new StringHelper();
            //IConversion conversionHelper = new ConversionHelper();
            //ITgimbaService service = new TgimbaService(bucketListData, passwordHelper, 
            //                                            generatorHelper, stringHelper, 
            //                                            conversionHelper);

            //services.AddSingleton<ITgimbaService>(service);
            //services.AddSingleton<IValidationHelper>(new ValidationHelper());

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "TgimbaApi"
            //    });
            //    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            //});
        }

        private void SetUpDI(IServiceCollection services)
        {
            //services.AddSingleton<IWebClient>(new WebClient(Configuration["ApiHost"], new TgimbaHttpClient()));
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
            //services.AddSingleton<ISearch>(new LinqSearch());
            services.AddSingleton(new AvailableSearchingAlgorithms(
                new List<ISearch>()
                {
                        new LinqSearch(),
                        new BinarySearch()
                 }
             ));

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
                                   x.GetRequiredService<AvailableSearchingAlgorithms>()
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
