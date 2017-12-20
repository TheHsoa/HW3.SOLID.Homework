using System;

using HomeWork.Infrastructure.Handler;
using HomeWork.Model.Contact;
using HomeWork.Validation;

namespace HomeWork.Data
{
    public class ContactRepository : EntityRepository<IContactEntity>
    {
        public ContactRepository(IHandler exceptionHandler) : base(exceptionHandler) { }

        public override void Add(IContactEntity contact)
        {
            try
            {
                contact.ValidateEntityNotNull();
                contact.Validate();
                _storage.Add(contact);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }
    }
}
