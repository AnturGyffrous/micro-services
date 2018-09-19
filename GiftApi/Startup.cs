using GiftApi.Infrastructure;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

namespace GiftApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                });

            services
                .AddDistributedRedisCache(options =>
                {
                    options.Configuration = Configuration["Redis:Configuration"];
                    options.InstanceName = Configuration["Redis:InstanceName"];
                });

            services
                .AddSingleton<IGiftRepository, MemoryGiftRepository>();

            services
                .AddResponseCaching(options =>
                {
                });

            services
                .AddMvc()
                .AddXmlSerializerFormatters()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseCompression();
            app.UseResponseCaching();
            app.UseMvc();
        }
    }
}
