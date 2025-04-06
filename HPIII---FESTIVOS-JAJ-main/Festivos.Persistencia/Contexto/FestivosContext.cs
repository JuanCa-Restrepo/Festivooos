using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Festivos.Dominio.Entidades;

namespace Festivos.Persistencia.Contexto
{
    public class FestivosContext: DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options) : base(options)
        {
        }
        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }  

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<Festivo>(Entidad =>
                { Entidad.HasKey(e => e.Id);
                    Entidad.HasIndex(e => e.Nombre).IsUnique();
                });

            Builder.Entity<Festivo>()
                .HasOne(e => e.TipoDia)
                .WithMany()
                .HasForeignKey(e => e.TipoId);

            Builder.Entity<Tipo>(Entidad =>
            {
                Entidad.HasKey(e => e.Id);
                Entidad.HasIndex(e => e.TipoFestivo).IsUnique();
            });

            
                
        }
    }

   
}
