using System;

namespace HomeWork.Infrastructure.Handler
{
    internal interface IHandler
    {
        void Handle(Exception e);
    }
}
