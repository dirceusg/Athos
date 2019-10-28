using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athos.Repository.Mapping
{
    public class UsuariosMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired();

            builder.HasMany(x => x.Comunicados)
                .WithOne(x => x.Remetente)
                .HasForeignKey(x => x.RemetenteId);

            builder.HasMany(x => x.ComunicadosAcoes)
                .WithOne(x => x.Executor)
                .HasForeignKey(x => x.ExecutorId);

        }
    }
}
