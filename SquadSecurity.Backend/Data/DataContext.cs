using Microsoft.EntityFrameworkCore;
using SquadSecurity.Shared.Entities;

namespace SquadSecurity.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       // public DbSet<Habilitador> Habilitadores { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Habilitador> Habilitadores { get; set; }
        //public DbSet<RevisionDet> RevisionDets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Habilitador>().HasIndex(x => new { x.Codigo, x.Titulo }).IsUnique();
           // modelBuilder.Entity<Parametros>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Parametro>().HasIndex(x => new { x.Nombre, x.Valor, x.Abreviatura }).IsUnique();
            //modelBuilder.Entity<RevisionDets>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            DisableCasacadingDelete(modelBuilder);
        }

        private void DisableCasacadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
