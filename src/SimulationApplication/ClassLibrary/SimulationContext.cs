using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class SimulationContext : DbContext
    {
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var envVariable = ConfigurationManager.AppSettings["envVariableName"];
                string connectionString = Environment.GetEnvironmentVariable(envVariable);
                optionsBuilder.UseMySql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Cell
            modelBuilder.Entity<Cell>()
                .HasKey(cell => new { cell.MapId, cell.RowIndex, cell.ColumnIndex });
            #endregion
        }
    }
}
