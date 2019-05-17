using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    public class SimulationContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }
        public DbSet<Location> Locations { get; set; }

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

            modelBuilder.Ignore<Building>();
        }
    }
}
