using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TestSerilogWithILoggerFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    // add file logging via Serilog
                    var env = context.HostingEnvironment;
                    var logger = new LoggerConfiguration()
                        .WriteTo.File(path: Path.Combine(env.ContentRootPath, "logs", "log.txt"), rollingInterval: RollingInterval.Day)
                        .CreateLogger();
                    logging.AddSerilog(logger, dispose: true);
                })
                .UseStartup<Startup>();
    }
}
