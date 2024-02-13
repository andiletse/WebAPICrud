using BAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace DAL.Helpers
{
   
    public sealed class PersonDbContext : DbContext
    {
        public PersonDbContext() { }
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        public  string Connect()
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionString");
            var myConnectionString = configSection["SQLServerConnection"] ?? null;

            return myConnectionString ?? string.Empty;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connect());
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