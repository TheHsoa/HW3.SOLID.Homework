using System;
using HomeWork.Data;
using HomeWork.DI;
using HomeWork.Model;
using HomeWork.Model.Contact;

using Unity;

namespace HomeWork
{
    public class Program
    {
        public static void Main()
        {
            var container = Bootstrapper.Configure();

            var user = new User
                           {
                               Id = 1,
                               Name = "Name"
                           };

            var phone = new Phone
                            {
                                Id = 1,
                                PhoneCode = "123",
                                Value = "123124"
                            };
            var email = new Email
                            {
                                Id = 2,
                                Value = "mail@2gis.ru"
                            };
            var userRepository = container.Resolve<IRepository<User>>();
            userRepository.Add(user);

            var contactRepository = container.Resolve<IRepository<Contact>>();

            contactRepository.Add(email);
            contactRepository.Add(phone);

            Console.WriteLine(contactRepository.GetById(1));

            Console.WriteLine(contactRepository.GetById(2));
        }
    }
}
