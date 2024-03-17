using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace DAL.Helpers
{
   
    public sealed class System1DbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        //default constructor
        public System1DbContext()
        {
        }
        //overloaded con
        public System1DbContext(DbContextOptions<System1DbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        //connection to database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("System1DbConnectionString"));
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //adding domain classes as dbset properties.
        public DbSet<System1_EntityName1> System1_TableName1 { get; set; }

    }
}