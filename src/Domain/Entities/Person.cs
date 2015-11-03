using System;

namespace Domain.Entities
{
    public class Person : Identity
    {
        internal Person()
        {
        }

        public Person(string Nome,
            string Email)
        {
            this.Id = Guid.NewGuid();

            this.Name = Nome;
            this.Email = Email;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
