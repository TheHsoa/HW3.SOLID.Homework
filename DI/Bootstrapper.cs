using HomeWork.Infrastructure;
using HomeWork.Infrastructure.Handler;
using HomeWork.Infrastructure.Logger;

using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace HomeWork.DI
{
    public static class Bootstrapper
    {
        public static IUnityContainer ConfigureLogging()
        {
            var container = new UnityContainer();
            container.RegisterType<ILogger, FileLogger>();
            container.RegisterType<IHandler, ExceptionHandler>(new InjectionConstructor(new InjectionParameter(container.Resolve<ILogger>())));
            return container;
        }
    }
}
