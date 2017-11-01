using System.Collections.Generic;
using HomeWork.Model.Contact;

namespace HomeWork.Model
{
    internal class User : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<IContactEntity> Contacts { get; private set; }

        public User()
        {
            Contacts = new HashSet<IContactEntity>();
        }
    }
}
