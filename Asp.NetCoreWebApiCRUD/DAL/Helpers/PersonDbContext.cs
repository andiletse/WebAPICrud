using BAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace DAL.Helpers
{
   
    public sealed class PersonDbContext : DbContext
    {
       // var connectionString = new ConnSqlHelper(ConnectionString);
        public PersonDbContext() { }
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
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