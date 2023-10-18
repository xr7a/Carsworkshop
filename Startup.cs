using CarWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace CarWorkshop
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddSingleton<UsersRepository>();
            services.AddSingleton<CarsRepository>();
            services.AddSingleton<OrdersRepository>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarWorkshop", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute ("Default", "Controllers/{controller=User}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("Default", "Controllers/{controller=Car}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("Default", "Controllers/{controller=Order}/{action=Index}/{id?}");
            });
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                //c.RoutePrefix = " ";
            });


        }

    }
}