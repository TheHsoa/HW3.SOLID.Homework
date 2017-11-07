using HomeWork.Data;
using HomeWork.Infrastructure.Handler;
using HomeWork.Infrastructure.Logger;
using HomeWork.Model;
using HomeWork.Model.Contact;

using Unity;

namespace HomeWork.DI
{
    public static class Bootstrapper
    {
        public static IUnityContainer Configure()
        {
            var container = new UnityContainer();
            container.RegisterType<ILogger, FileLogger>();
            container.RegisterType<IHandler, ExceptionHandler>();
            container.RegisterType<IRepository<User>, EntityRepository<User>>();
            container.RegisterType<IRepository<Contact>, ContactRepository>();

            return container;
        }
    }
}
