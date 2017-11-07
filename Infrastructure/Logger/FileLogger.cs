using System;
using System.IO;

namespace HomeWork.Infrastructure.Logger
{
    public class FileLogger : ILogger
    {
        public void Log(Exception e)
        {
            File.AppendAllText("log.txt", $@"{e.Message}{Environment.NewLine}{Environment.NewLine}");
        }
    }
}
