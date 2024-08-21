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
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Excepcion> Excepciones { get; set; }

        public DbSet<RevisionCab> RevisionCabs { get; set; }
        public DbSet<RevisionDet> RevisionDets { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<SquadDetalle> SquadDetalles { get; set; }
        public DbSet<Iniciativa> Iniciativas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Habilitador>().HasIndex(x => new { x.Codigo, x.Titulo }).IsUnique();
           // modelBuilder.Entity<Parametros>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Parametro>().HasIndex(x => new { x.Nombre, x.Valor, x.Abreviatura }).IsUnique();
            //modelBuilder.Entity<RevisionDets>().HasIndex(x => new { x.CountryId, x.Name }).IsUnique();
            modelBuilder.Entity<Colaborador>().HasIndex(x => new { x.Dni }).IsUnique();
            modelBuilder.Entity<RevisionCab>().HasIndex(x => new { x.CodigoIniciativa, x.CodigoSquad }).IsUnique();
            modelBuilder.Entity<RevisionDet>().HasIndex(x => x.RevisionCabId ).IsUnique();

            modelBuilder.Entity<Squad>().HasIndex(x => new { x.Nombre }).IsUnique();
            modelBuilder.Entity<SquadDetalle>().HasIndex(x => x.SquadId).IsUnique();

            modelBuilder.Entity<Iniciativa>().HasIndex(x => new { x.Nombre}).IsUnique();

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
