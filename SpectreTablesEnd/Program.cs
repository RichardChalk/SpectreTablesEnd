using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Spectre.Console;
using SpectreTablesEnd.Controllers;
using SpectreTablesToRefactor.Data;
using SpectreTablesToRefactor.Enums;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor;
internal class Program
{
    static void Main(string[] args)
    {
        // Denna sektion skapa en connection till vår nya databas!
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
        var config = builder.Build();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = config.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);

        using (var dbContext = new ApplicationDbContext(options.Options))
        {
            var dataInitiaizer = new DataInitializer();
            dataInitiaizer.MigrateAndSeed(dbContext);
        }

        // Denna sektion presentera menyn till användaren!
        while (true)
        {
            // Sprectre menyval!
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOptions>()
                .Title("Vad vill du göra?")
                .UseConverter(option => option.GetDescription()) // Visa beskrivningar istället för enum-namn
                .AddChoices(Enum.GetValues<MenuOptions>()));

            switch (option)
            {
                case MenuOptions.AddProduct:
                    ProductController.InsertProduct();
                    break;
                case MenuOptions.ViewAllProducts:
                    ProductController.GetProducts();
                    break;

                case MenuOptions.ViewProduct:
                    ProductController.GetProduct();
                    break;
                case MenuOptions.UpdateProduct:
                    ProductController.UpdateProduct();
                    break;
                case MenuOptions.DeleteProduct:
                    ProductController.DeleteProduct();
                    break;
                case MenuOptions.Exit:
                    return;
                default:
                    break;
            }
        }
    }

  


}
