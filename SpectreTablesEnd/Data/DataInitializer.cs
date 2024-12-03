using Microsoft.EntityFrameworkCore;
using SpectreTablesToRefactor.Enums;
using SpectreTablesToRefactor.Models;
using System.Diagnostics.Metrics;

namespace SpectreTablesToRefactor.Data;

internal class DataInitializer
{
    public void MigrateAndSeed(ApplicationDbContext dbContext)
    {
        dbContext.Database.Migrate();
        SeedProducts(dbContext);
        dbContext.SaveChanges();
    }

    private void SeedProducts(ApplicationDbContext dbContext)
    {
        if (!dbContext.Products.Any(c => c.Name == "Electric Kettle"))
        {
            dbContext.Products.Add(new Product { Name = "Electric Kettle", Price = 299.00m, Category = Category.Kitchen });
        }
        if (!dbContext.Products.Any(c => c.Name == "Toaster"))
        {
            dbContext.Products.Add(new Product { Name = "Toaster", Price = 199.00m, Category = Category.Kitchen });
        }
        if (!dbContext.Products.Any(c => c.Name == "Microwave Oven"))
        {
            dbContext.Products.Add(new Product { Name = "Microwave Oven", Price = 1299.00m, Category = Category.Kitchen });
        }
        if (!dbContext.Products.Any(c => c.Name == "Refrigerator"))
        {
            dbContext.Products.Add(new Product { Name = "Refrigerator", Price = 7999.00m, Category = Category.Kitchen });
        }
        if (!dbContext.Products.Any(c => c.Name == "Washing Machine"))
        {
            dbContext.Products.Add(new Product { Name = "Washing Machine", Price = 4999.00m, Category = Category.Cleaning });
        }
        if (!dbContext.Products.Any(c => c.Name == "Electric Fan"))
        {
            dbContext.Products.Add(new Product { Name = "Electric Fan", Price = 399.00m, Category = Category.Home });
        }
        if (!dbContext.Products.Any(c => c.Name == "Hair Dryer"))
        {
            dbContext.Products.Add(new Product { Name = "Hair Dryer", Price = 249.00m, Category = Category.PersonalCare });
        }
        if (!dbContext.Products.Any(c => c.Name == "Vacuum Cleaner"))
        {
            dbContext.Products.Add(new Product { Name = "Vacuum Cleaner", Price = 1799.00m, Category = Category.Cleaning });
        }
        if (!dbContext.Products.Any(c => c.Name == "Air Conditioner"))
        {
            dbContext.Products.Add(new Product { Name = "Air Conditioner", Price = 9999.00m, Category = Category.Home });
        }
        if (!dbContext.Products.Any(c => c.Name == "Electric Heater"))
        {
            dbContext.Products.Add(new Product { Name = "Electric Heater", Price = 699.00m, Category = Category.Home });
        }

    }
}
