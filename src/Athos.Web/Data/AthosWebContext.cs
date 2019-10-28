using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Athos.Web.ViewModels;

namespace Athos.Web.Models
{
    public class AthosWebContext : DbContext
    {
        public AthosWebContext (DbContextOptions<AthosWebContext> options)
            : base(options)
        {
        }

        public DbSet<Athos.Web.ViewModels.UsuarioViewModel> UsuarioViewModel { get; set; }
    }
}
