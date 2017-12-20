using System;
using System.IO;

namespace HomeWork.Infrastructure.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string logFilePath;

        public FileLogger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Log(Exception e)
        {
            File.AppendAllText(logFilePath, $@"{e.Message}{Environment.NewLine}{Environment.NewLine}");
        }
    }
}
