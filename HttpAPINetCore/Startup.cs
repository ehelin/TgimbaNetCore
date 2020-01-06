using System.Linq;
using APINetCore;
using BLLNetCore.helpers;
using BLLNetCore.Security;  // TODO - remove after namespaces changed to bllnetcore.helpers
using DALNetCore;
using DALNetCore.helpers;
using DALNetCore.interfaces;
using HttpAPINetCore.helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.interfaces;
using Swashbuckle.AspNetCore.Swagger;

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
            IUserHelper userHelper = new UserHelper();
            BucketListContext context = new BucketListContext();
            IBucketListData bucketListData = new BucketListData(context, userHelper);
            IPassword passwordHelper = new PasswordHelper();
            IGenerator generatorHelper = new GeneratorHelper();
            IString stringHelper = new StringHelper();
            IConversion conversionHelper = new ConversionHelper();
            ITgimbaService service = new TgimbaService(bucketListData, passwordHelper, 
                                                        generatorHelper, stringHelper, 
                                                        conversionHelper);

            services.AddSingleton<ITgimbaService>(service);
            services.AddSingleton<IValidationHelper>(new ValidationHelper());
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "TgimbaApi"
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
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
