using System;
using HomeWork.Data;
using HomeWork.DI;
using HomeWork.Infrastructure;
using HomeWork.Infrastructure.Handler;
using HomeWork.Model;
using HomeWork.Validation;

using Unity;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrapper.ConfigureLogging();

            var handler = container.Resolve<IHandler>();

            var user = new User { Id = 1, Name = "Name" };

            var phone = new Contact { Type = ContactType.Phone, Id = 1, PhoneCode = "123", Value = "123124" };
            var email = new Contact { Type = ContactType.Email, Id = 2, Value = "mail@2gis.ru" };

            var validator = new ContactValidator();

            var userRepository = GetRepository<User>(handler);
            userRepository.Add(user);

            var contactRepository = GetRepository<Contact>(handler);

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
