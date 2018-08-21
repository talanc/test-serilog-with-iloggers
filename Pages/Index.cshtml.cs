using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TestSerilogWithILoggerFactory.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Service1 service1;
        private readonly ILogger<IndexModel> logger;
        private readonly ILoggerFactory loggerFactory;

        private readonly ILogger<IndexModel> loggerFromFactory;

        public IndexModel(Service1 service1, ILogger<IndexModel> logger, ILoggerFactory loggerFactory)
        {
            this.service1 = service1;
            this.logger = logger;
            this.loggerFactory = loggerFactory;

            loggerFromFactory = loggerFactory.CreateLogger<IndexModel>();
        }

        public void OnGet()
        {

        }

        public void OnPostUseLogger()
        {
            logger.LogInformation("IndexModel: Log using Logger");
        }

        public void OnPostUseLoggerFactory()
        {
            loggerFromFactory.LogInformation("IndexModel: Log using LoggerFactory");
        }

        public void OnPostUseService1Logger()
        {
            service1.LogWithLogger();
        }

        public void OnPostUseService1LoggerFactory()
        {
            service1.LogWithLoggerFactory();
        }
    }
}
