using System;

namespace HomeWork.Infrastructure.Handler
{
    public interface IExceptionHandler
    {
        void Handle(Exception e);
    }
}
