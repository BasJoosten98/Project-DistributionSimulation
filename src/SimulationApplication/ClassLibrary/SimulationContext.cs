using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class SimulationContext : DbContext
    {
        public DbSet<Entities.Building> Buildings { get; set; }
        public DbSet<Entities.Location> Locations { get; set; }
        public DbSet<Entities.Map> Maps { get; set; }
        public DbSet<Entities.Shop> Shops { get; set; }
        public DbSet<Entities.Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envVariable = ConfigurationManager.AppSettings["envVariableName"];
                Console.WriteLine(envVariable);
                string connectionString = Environment.GetEnvironmentVariable(envVariable);
                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Location
            modelBuilder.Entity<Entities.Location>()
                .HasKey(location => new { location.MapId, location.RowIndex, location.ColumnIndex });
            #endregion

            #region Map

            #endregion
        }
    }
}
