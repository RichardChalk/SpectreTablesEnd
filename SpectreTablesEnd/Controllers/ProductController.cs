using Spectre.Console;
using SpectreTablesEnd.Services;
using SpectreTablesToRefactor.Enums;
using SpectreTablesToRefactor.Models;
using SpectreTablesToRefactor.UI;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesEnd.Controllers;

internal class ProductController
{
    internal static void InsertProduct()
    {
        var product = new Product();
        product.Name = AnsiConsole.Ask<string>("Produktens namn:");
        product.Price = AnsiConsole.Ask<decimal>("Produtens pris:");

        // Skapa en lista med kategorier och deras beskrivningar
        var chosenDescription = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Välj produktens kategori:")
            .AddChoices(Enum.GetValues(typeof(Category))
            .Cast<Category>()
            .Select(EnumService.GetEnumDescription)));

        // Hitta vald kategori baserat på beskrivningen
        var chosenCategory = Enum.GetValues(typeof(Category))
            .Cast<Category>()
            .First(cat => EnumService.GetEnumDescription(cat) == chosenDescription);

        product.Category = chosenCategory;

        var productService = new ProductService();
        productService.AddProduct(product);
    }

    internal static void GetProducts()
    {
        var productService = new ProductService();
        var products = productService.GetProducts();
        DisplayItems.ShowProductTable(products);
    }

    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        DisplayItems.ShowProduct(product);
    }

    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        if (AnsiConsole.Confirm("Uppdatera namn?"))
            product.Name = AnsiConsole.Ask<string>("Produktens nya namn:");

        if (AnsiConsole.Confirm("Uppdatera pris?"))
            product.Price = AnsiConsole.Ask<decimal>("Produktens nya pris:");

        // Skapa en lista med kategorier och deras beskrivningar
        var chosenDescription = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Välj produktens kategori:")
            .AddChoices(Enum.GetValues(typeof(Category))
            .Cast<Category>()
            .Select(EnumService.GetEnumDescription)));

        // Hitta vald kategori baserat på beskrivningen
        var chosenCategory = Enum.GetValues(typeof(Category))
            .Cast<Category>()
            .First(cat => EnumService.GetEnumDescription(cat) == chosenDescription);

        product.Category = chosenCategory;

        var productService = new ProductService();
        productService.UpdateProduct(product);
    }

    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        var productService = new ProductService();
        productService.DeleteProduct(product);
    }


    internal static Product GetProductOptionInput()
    {
        // Get productService
        var productService = new ProductService();
        var products = productService.GetProducts();

        // Display produkter för användaren att välja bland
        var productsArrayForDisplay = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Välj Produkt")
            .AddChoices(productsArrayForDisplay));

        // Hitta vald produkt
        var id = products.Single(x => x.Name == option).ProductId;
        var product = productService.GetProductById(id);

        return product;
    }
}
