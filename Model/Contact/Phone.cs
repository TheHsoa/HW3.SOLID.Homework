using System;

namespace HomeWork.Model.Contact
{
    internal class Phone : IContactEntity
    {
        public string PhoneCode { get; set; }
        public long Id { get; set; }
        public virtual string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0}, Value={1}", Id, "(" + PhoneCode + ")" + Value);
        }
    }
}
