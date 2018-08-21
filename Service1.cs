using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TestSerilogWithILoggerFactory
{
    public class Service1
    {
        private readonly ILogger<Service1> logger;
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<Service1> loggerFromFactory;

        public Service1(ILogger<Service1> logger, ILoggerFactory loggerFactory)
        {
            this.logger = logger;
            this.loggerFactory = loggerFactory;

            loggerFromFactory = loggerFactory.CreateLogger<Service1>();
        }

        public void LogWithLogger()
        {
            logger.LogInformation("Service1: Log with logger");
        }

        public void LogWithLoggerFactory()
        {
            logger.LogInformation("Service1: Log with logger factory");
        }
    }
}
