using Domain.Entities;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using System;

namespace Infra.Configs
{
    internal class PersonConfig
    {
        public static Action<EntityTypeBuilder<Person>> Config()
        {
            return c =>
            {
                c.ToTable("Person");
                c.HasKey(k => k.Id);
                c.Property(p => p.Name).IsRequired().HasMaxLength(500);
                c.Property(p => p.Email).IsRequired().HasMaxLength(500);
            };
        }
    }
}
