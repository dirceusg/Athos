using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athos.Repository.Mapping
{
    public class ComunicadoMapping : IEntityTypeConfiguration<Comunicado>
    {
        public void Configure(EntityTypeBuilder<Comunicado> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Mensagem)
                .IsRequired()
                .HasMaxLength(3000);

            builder.HasMany(x => x.ComunicadosAcoes)
                .WithOne(x => x.Comunicado)
                .HasForeignKey(x => x.ComunicadoId);

        }
    }
}
