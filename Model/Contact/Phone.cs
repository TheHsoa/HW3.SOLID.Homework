using HomeWork.Validation;

namespace HomeWork.Model.Contact
{
    public class Phone : Contact
    {
        public string PhoneCode { get; set; }

        public override string ToString()
        {
            return string.Format("Id={0}, Value={1}", Id, "(" + PhoneCode + ")" + Value);
        }

        public override void Validate()
        {
            base.Validate();
            this.ValidatePhone();
        }
    }
}
