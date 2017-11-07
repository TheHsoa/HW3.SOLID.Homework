using System;

using HomeWork.Model;
using HomeWork.Model.Contact;
using HomeWork.Properties;

namespace HomeWork.Validation
{
    public static class EntityValidators
    {
        public static void ValidateEntityNotNull<TEntity>(this TEntity entity) where TEntity : IEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name);
            }
        }

        public static void ValidateContact(this Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Value))
            {
                throw new ArgumentException(string.Format(Resources.NullPropertyException, nameof(contact.Value)), contact.GetType().Name);
            }
        }

        public static void ValidatePhone(this Phone phone)
        {
            if (string.IsNullOrWhiteSpace(phone.PhoneCode))
                throw new ArgumentException(string.Format(Resources.NullPropertyException, nameof(phone.PhoneCode)), phone.GetType().Name);
        }
    }
}
