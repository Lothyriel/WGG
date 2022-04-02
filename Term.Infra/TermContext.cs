using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class TermContext : DbContext
    {
        public DbSet<Term> Terms { get; }

        public TermContext(DbContextOptions<TermContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}