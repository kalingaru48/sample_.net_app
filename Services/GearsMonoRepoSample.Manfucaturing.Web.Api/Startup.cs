using GearsMonoRepoSample.Manfucaturing.Web.Api.Brokers.Storages;
using GearsMonoRepoSample.Manfucaturing.Web.Api.Services.Foundations.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GearsMonoRepoSample.Manfucaturing.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc(
                    "v1", 
                    new OpenApiInfo 
                    { 
                        Title = "GearsMonoRepoSample.Manfucaturing.Web.Api", 
                        Version = "v1" 
                    })
            );

            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<IProductService, ProductService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json", 
                    "GearsMonoRepoSample.Manfucaturing.Web.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }
    }
}
