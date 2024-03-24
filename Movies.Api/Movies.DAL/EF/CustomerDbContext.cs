using Microsoft.EntityFrameworkCore;
using Movies.Models.EF.Customer;

namespace Movies.DAL.EF
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext (DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
