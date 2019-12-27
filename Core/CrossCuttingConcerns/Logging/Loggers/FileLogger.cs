using Core.CrossCuttingConcerns.Logging.Log4Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base(name:"JsonFileLogger")
        {
        }
    }
}
