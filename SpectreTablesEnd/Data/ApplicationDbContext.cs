using Microsoft.EntityFrameworkCore;
using SpectreTablesToRefactor.Models;
namespace SpectreTablesToRefactor.Data;

internal class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ApplicationDbContext()
    {
        // en tom konstruktor behövs för att skapa migrations
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Denna behövs första gången man kör för att skapa databasen!
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SpectreTables;Trusted_Connection=True;TrustServerCertificate=true;");
        }
    }
}
