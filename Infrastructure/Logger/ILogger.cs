using System;

namespace HomeWork.Infrastructure.Logger
{
    public interface ILogger
    {
        void Log(Exception e);
    }
}
