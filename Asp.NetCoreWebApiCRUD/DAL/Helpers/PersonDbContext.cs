using BAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace DAL.Helpers
{
   
    public sealed class PersonDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public PersonDbContext() { }
        public PersonDbContext(DbContextOptions<PersonDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PersonDbConnectionString"));
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //adding domain classes as dbset properties.
        public DbSet<Person> Persons { get; set; }
    }
}