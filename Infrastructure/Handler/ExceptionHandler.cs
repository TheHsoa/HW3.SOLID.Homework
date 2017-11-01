using System;

using HomeWork.Infrastructure.Logger;

namespace HomeWork.Infrastructure.Handler
{
    public class ExceptionHandler : IHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        // Не понимаю как можно разбить Handle, чтобы оставить текущее поведение
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
                _logger.Log(e);
            }
        }
    }
}
