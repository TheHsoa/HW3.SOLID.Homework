namespace HomeWork.Model.Contact
{
    public interface IContactEntity : IEntity, IValidatableEntity
    {
        string Value { get; set; }
    }
}
