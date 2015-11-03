using System;

namespace Domain.Entities
{
    public abstract class Identity
    {
        public Guid Id { get; protected set; }
    }
}
