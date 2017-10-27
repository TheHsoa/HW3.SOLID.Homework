using System;

using HomeWork.Infrastructure;
using HomeWork.Infrastructure.Logger;

using Unity.Attributes;

namespace HomeWork.Infrastructure.Handler
{
    public class ExceptionHandler : IHandler
    {
        private readonly ILogger logger;

        public ExceptionHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public void Handle(Exception e)
        {
            if (e is ArgumentNullException)
            {
                Console.WriteLine(e.Message);
            }
            else if (e is InvalidOperationException)
            {
                throw new Exception("Custom exception", e);
            }
            else
            {
                logger.Log(e);
            }
        }
    }
}
