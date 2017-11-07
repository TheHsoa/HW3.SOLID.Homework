namespace HomeWork.Model.Contact
{
    public class Email : Contact
    {
        public override string ToString()
        {
            return $"Id={Id}, Value={Value}";
        }
    }
}
