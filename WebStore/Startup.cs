using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Infrastructure.Conventions;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Middleware;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public record Startup(IConfiguration Configuration)
    {
        /*private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }*/

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmployeesData, InMemoryEmployeesData>();
            services.AddTransient<IProductData, InMemoryProductData>();

            //services.AddMvc(/*opt => opt.Conventions.Add(new TestControllerModelConvention())*/);
            services.AddControllersWithViews(/*opt => opt.Conventions.Add(new TestControllerModelConvention())*/)
                .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env/*, IServiceProvider services*/)
        {
            //var employees = services.GetService<IEmployeesData>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles(); //important for using files, pictures, ....

            app.UseRouting();

            app.UseWelcomePage("/welcome");

            app.UseMiddleware<TestMiddleware>();

            // localhost:5000/hello?id=5
            app.MapWhen(
                context => context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5", 
                context => context.Run(async request => await request.Response.WriteAsync("Hello with id = 5"))
            );

            app.Map("/hello",
                context => context.Run(async request => await request.Response.WriteAsync("Hello!!!")));
            app.UseEndpoints(endpoints =>
            {
                // Проекция запроса на действие
                endpoints.MapGet("/greetings", async context =>
                {
                    await context.Response.WriteAsync(Configuration["Greetings"]);
                });

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
                //http://localhost:5000 -> controller = "Home" action = "Index" parameter = null
                //http://localhost:5000/Catalog/Products/5 -> controller = "Catalog" action = "Products" parameter = 5
            });
        }
    }
}
