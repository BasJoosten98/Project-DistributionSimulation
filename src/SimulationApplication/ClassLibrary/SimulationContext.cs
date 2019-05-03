using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary
{
    class SimulationContext : DbContext
    {
        public DbSet<Map> Maps { get; set; }

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
        }
    }
}
