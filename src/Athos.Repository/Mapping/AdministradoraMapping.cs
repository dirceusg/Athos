using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athos.Repository.Mapping
{
    public class AdministradoraMapping : IEntityTypeConfiguration<Administradora>
    {
        public void Configure(EntityTypeBuilder<Administradora> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            // 1 : N => Administradora : Condominios
            builder.HasMany(x => x.Condominios)
                .WithOne(x => x.administradora)
                .HasForeignKey(x => x.AdministradoraId);
        }
    }
}
