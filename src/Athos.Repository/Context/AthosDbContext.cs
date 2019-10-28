using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Athos.Entity.entities;
using Microsoft.EntityFrameworkCore;

namespace Athos.Repository.Context
{
    public class AthosDbContext : DbContext
    {

        public AthosDbContext(DbContextOptions<AthosDbContext> options) : base(options) { }

        public DbSet<Administradora> Administradora { get; set; }
        public DbSet<Assunto> Assunto { get; set; }
        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Comunicado> Comunicado { get; set; }
        public DbSet<ComunicadoAcao> ComunicadoAcao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AthosDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }


        
    }
}
