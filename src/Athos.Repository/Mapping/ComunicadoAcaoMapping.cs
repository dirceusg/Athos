using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Athos.Repository.Mapping
{
    public class ComunicadoAcaoMapping : IEntityTypeConfiguration<ComunicadoAcao>
    {
        public void Configure(EntityTypeBuilder<ComunicadoAcao> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
