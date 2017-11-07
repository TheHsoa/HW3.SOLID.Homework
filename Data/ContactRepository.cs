using System;

using HomeWork.Infrastructure.Handler;
using HomeWork.Model.Contact;
using HomeWork.Validation;

namespace HomeWork.Data
{
    public class ContactRepository : EntityRepository<Contact>
    {
        public ContactRepository(IHandler exceptionHandler) : base(exceptionHandler) { }

        public override void Add(Contact contact)
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
