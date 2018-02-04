using System;

using HomeWork.Infrastructure.Handler;
using HomeWork.Model.Contact;
using HomeWork.Validation;

namespace HomeWork.Data
{
    public class ContactRepository : EntityRepository<IContactEntity>
    {
        public ContactRepository(IExceptionHandler exceptionHandler) : base(exceptionHandler) { }

        public override void Add(IContactEntity contact)
        {
            try
            {
                contact.ValidateEntityNotNull();
                contact.Validate();
                Storage.Add(contact);
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }
    }
}
