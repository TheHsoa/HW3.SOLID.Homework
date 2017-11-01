using System;
using HomeWork.Data;
using HomeWork.DI;
using HomeWork.Infrastructure;
using HomeWork.Infrastructure.Handler;
using HomeWork.Infrastructure.Logger;
using HomeWork.Model;
using HomeWork.Model.Contact;
using HomeWork.Validation;

using Unity;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.Configure();

            var handler = container.Resolve<IHandler>();

            var user = new User { Id = 1, Name = "Name" };

            var phone = new Phone { Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Email { Id = 2, Value = "mail@2gis.ru" };

            var validator = new ContactValidator(new FileLogger());

            var userRepository = GetRepository<User>(handler);
            userRepository.Add(user);

            var contactRepository = GetRepository<IContactEntity>(handler);

            if (validator.IsValid(email))
                contactRepository.Add(phone);

            if (validator.IsValid(phone))
                contactRepository.Add(email);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));
        }

        private static IRepository<TEntity> GetRepository<TEntity>(IHandler handler) where TEntity : class, IEntity
        {
            return new EntityRepository<TEntity>(handler);
        }
    }
}
