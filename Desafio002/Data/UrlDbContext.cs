using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Desafio002.Models;

namespace Desafio002.Data;

public class UrlDbContext : DbContext
{
    public UrlDbContext(DbContextOptions<UrlDbContext> opt) : base(opt)
    {

    }
    public DbSet<Url> url { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
