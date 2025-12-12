using Microsoft.EntityFrameworkCore;
using DSW1_T2_ChicllaZamoraRonny.Domain.Entities;

namespace DSW1_T2_ChicllaZamoraRonny.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();
        }
    }
}