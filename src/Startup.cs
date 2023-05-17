using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// The purpose of this class is to provide a startup
    /// framework to be called at runtime to run the program.
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// Gets the class to configure the container.
        public IConfiguration Configuration { get; }

        /// This method gets called by the runtime. Use this method to add
        /// services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ///Calls for add razor pages.
            services.AddRazorPages();
            ///Calls for add server size blazor.
            services.AddServerSideBlazor();
            ///Calls for the add http client.
            services.AddHttpClient();
            ///Calls for the add controllers classes.
            services.AddControllers();
            ///Includes the json file product service.
            services.AddTransient<JsonFileProductService>();
        }

        /// This method gets called by the runtime.
        /// Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                ///The exception dev page is use for exception as default.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                /// The default HSTS value is 30 days.
                /// You may want to change this for production scenarios,
                /// see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            ///Calls the https redirection method from app.
            app.UseHttpsRedirection();
            ///Calls the useStaticFiles method from app.
            app.UseStaticFiles();
            ///Routes the application.
            app.UseRouting();
            ///Authorizes the application using use authorization method.
            app.UseAuthorization();

            ///Creates end points because the start up needs to end.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();

                // endpoints.MapGet("/products", (context) => 
                // {
                //     var products = app.ApplicationServices.GetService
                //     <JsonFileProductService>().GetProducts();
                //     var json = JsonSerializer.Serialize<IEnumerable
                //     <Product>>(products);
                //     return context.Response.WriteAsync(json);
                // });
            });
        }
    }
}
