using System;

namespace Domain
{
    public class Cliente
    {
        //Apenas para o entity
        internal Cliente()
        {
        }

        public Cliente(string Nome,
            string Email)
        {
            this.Id = Guid.NewGuid();

            this.Nome = Nome;
            this.Email = Email;
        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }
    }
}
