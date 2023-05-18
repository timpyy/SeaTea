using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    ///<summary>
    ///The purpose of this class is to create a program that runs
    ///the host builder because the program required services and an
    ///IWebHost which hosts a web application for the program.
    ///</summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //Crates a host for the web application
            //that uses the build to run classes
            CreateHostBuilder(args).Build().Run();
        }

        ///Builds the host builder for the website
        ///using a create default builder class
        ///to build a template of a web.
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Uses the startup method from webBuilder.
                    webBuilder.UseStartup<Startup>();
                });
    }
}
