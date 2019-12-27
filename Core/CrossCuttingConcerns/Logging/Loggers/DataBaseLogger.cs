using Core.CrossCuttingConcerns.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Loggers
{
    public class DataBaseLogger : LoggerServiceBase
    {
        public DataBaseLogger() : base(name: "DatabaseLogger")
        {
        }
    }
}
