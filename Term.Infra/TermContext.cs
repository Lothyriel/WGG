using Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infra
{
    public class TermContext : DbContext
    {
        public DbSet<Term> Terms { get; }

        public TermContext(DbContextOptions<TermContext> options) : base(options)
        {
            Database.EnsureCreated();
            Terms = Set<Term>();
        }

#if DEBUG
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(x => Debug.WriteLine(x));
            optionsBuilder.EnableSensitiveDataLogging();
        }
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Term>(entity =>
            {
                entity.HasKey(e => e.Word);
            });
        }
    }
}