using System;
using System.Diagnostics;

using HomeWork.Properties;

namespace HomeWork.Model.Contact
{
    [DebuggerDisplay("Id={Id}, Value={Value}")]
    public class Email : IContactEntity
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                throw new ArgumentException(string.Format(Resources.NullPropertyException, nameof(Value)), GetType().Name);
            }
        }
    }
}
