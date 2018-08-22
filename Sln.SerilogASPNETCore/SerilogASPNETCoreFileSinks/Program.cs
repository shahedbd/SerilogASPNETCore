using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace SerilogASPNETCoreFileSinks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Helper.CreateFileLogger();
            //Helper.CreateFileLoggerUsingJSONFile();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
