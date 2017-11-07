using System;

namespace HomeWork.Infrastructure.Handler
{
    public interface IHandler
    {
        void Handle(Exception e);
    }
}
