using Microsoft.EntityFrameworkCore;
using Desafio002.Models;

namespace Desafio002.Data;

public class UrlDbContext : DbContext
{
    public UrlDbContext(DbContextOptions<UrlDbContext> opt) : base(opt)
    {

    }
    public DbSet<Url> url { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Url>()
             .HasIndex(x => x.UrlEncurtada).IsUnique();
            
        modelBuilder.Entity<Url>()
            .HasIndex(y=>y.URL).IsUnique();

    }
}
