using HomeWork.Data;
using HomeWork.Infrastructure.Handler;
using HomeWork.Infrastructure.Logger;
using HomeWork.Model;
using HomeWork.Model.Contact;

using Unity;
using Unity.Lifetime;

namespace HomeWork.DI
{
    public static class Bootstrapper
    {
        public static IUnityContainer ConfigureUnity()
        {
            var container = new UnityContainer();

            return container.ConfigureLogger()
                            .ConfigureHandler()
                            .ConfigureRepository();
        }

        private static IUnityContainer ConfigureRepository(this IUnityContainer container)
        {
            return container.RegisterType<IRepository<User>, EntityRepository<User>>()
                            .RegisterType<IRepository<Contact>, ContactRepository>();
        }

        private static IUnityContainer ConfigureLogger(this IUnityContainer container)
        {
            return container.RegisterType<ILogger, FileLogger>(new ContainerControlledLifetimeManager());
        }

        private static IUnityContainer ConfigureHandler(this IUnityContainer container)
        {
            return container.RegisterType<IHandler, ExceptionHandler>(new ContainerControlledLifetimeManager());
        }
    }
}
