using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_NET8.Models;

namespace SuperHeroAPI_NET8.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<SuperHero> SuperHeroes { get; set; }
}
