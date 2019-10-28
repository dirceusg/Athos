using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Repository.Mapping
{
    public class CondominioMapping : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();


            // 1 : N => Condominio : Usuarios
            builder.HasMany(x => x.Usuarios)
                .WithOne(x => x.Condominio)
                .HasForeignKey(x => x.CondominioId);


        }
    }
}
