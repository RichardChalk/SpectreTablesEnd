using SpectreTablesToRefactor.Data;
using SpectreTablesToRefactor.Models;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesEnd.Services;

internal class ProductService
{
    public ApplicationDbContext dbContext { get; set; }
    public ProductService()
    {
        dbContext = new ApplicationDbContext();
    }

    internal void AddProduct(Product product)
    {
        dbContext.Products.Add(product);
        dbContext.SaveChanges();
    }
    internal List<Product> GetProducts()
    {
        return dbContext.Products.ToList();
    }

    internal Product GetProductById(int id)
    {
        // returnera null om Id inte hittas!
        return dbContext.Products.SingleOrDefault(x => x.ProductId == id);
    }

    internal void UpdateProduct(Product product)
    {
        // returnera null om Id inte hittas!
        var productToUpdate = dbContext.Products
            .SingleOrDefault(x => x.ProductId == product.ProductId);

        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.Category = product.Category;
        dbContext.SaveChanges();
    }

    internal void DeleteProduct(Product product)
    {
        dbContext.Products.Remove(product);
        dbContext.SaveChanges();
    }
}
