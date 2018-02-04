using HomeWork.Data;
using HomeWork.Infrastructure.Handler;
using HomeWork.Infrastructure.Logger;
using HomeWork.Model;
using HomeWork.Model.Contact;
using HomeWork.Properties;

using Unity;
using Unity.Injection;

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
                            .RegisterType<IRepository<IContactEntity>, ContactRepository>();
        }

        private static IUnityContainer ConfigureLogger(this IUnityContainer container)
        {
            return container.RegisterType<ILogger, FileLogger>(new InjectionConstructor(Resources.LogFilePath));
        }

        private static IUnityContainer ConfigureHandler(this IUnityContainer container)
        {
            return container.RegisterType<IExceptionHandler, ExceptionHandler>();
        }
    }
}
