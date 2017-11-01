namespace HomeWork.Model.Contact
{
    public class Email : IContactEntity
    {
        public long Id { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Value={Value}";
        }
    }
}
