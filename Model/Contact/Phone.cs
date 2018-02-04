using System;

using HomeWork.Properties;

namespace HomeWork.Model.Contact
{
    public class Phone : IContactEntity
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public string PhoneCode { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentException(string.Format(Resources.NullPropertyException, nameof(Value)), GetType().Name);
            }

            if (string.IsNullOrWhiteSpace(PhoneCode))
            {
                throw new ArgumentException(string.Format(Resources.NullPropertyException, nameof(PhoneCode)), GetType().Name);
            }
        }
    }
}
