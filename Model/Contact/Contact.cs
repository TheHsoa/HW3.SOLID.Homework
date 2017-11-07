using HomeWork.Validation;

namespace HomeWork.Model.Contact
{
    public abstract class Contact : IContactEntity
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public virtual void Validate()
        {
            this.ValidateContact();
        }
    }
}
