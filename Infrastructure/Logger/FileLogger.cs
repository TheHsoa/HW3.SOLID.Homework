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
            using (TextWriter writer = new StreamWriter(logFilePath))
            {
                writer.WriteLine($"{e.Message}{Environment.NewLine}");
            }
        }
    }
}
