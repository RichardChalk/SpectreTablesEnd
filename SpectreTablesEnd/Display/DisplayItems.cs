using Spectre.Console;
using SpectreTablesToRefactor.Enums;
using SpectreTablesToRefactor.Models;

// Lägger man till ett ; på slutet så slipper man {} runt namepsace!
namespace SpectreTablesToRefactor.UI;

internal class DisplayItems
{
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        // Alternativ för tabellutseende
        table.Border(TableBorder.Double); // Dubbelram
        table.BorderColor(Color.Grey); // Sätt en kantfärg
        table.Title("[underline bold white]Alla Produkter[/]"); // Lägg till en titel

        // Alternativ för Kolumnerna
        table.AddColumn(new TableColumn("[bold red]Id[/]"));
        table.AddColumn(new TableColumn("[bold red]Namn[/]"));
        table.AddColumn(new TableColumn("[bold red]Pris[/]"));
        table.AddColumn(new TableColumn("[bold red]Kategori[/]"));
        //Utan formattering
        //table.AddColumn("Id");
        //table.AddColumn("Namn");
        //table.AddColumn("Pris");
        //table.AddColumn("Kategori");

        foreach (Product product in products)
        {
            table.AddRow(
                $"[blue]{product.ProductId}[/]",
                $"[bold]{product.Name}[/]",
                $"[green]{product.Price:C}[/]", // Format som valuta
                $"[italic]{EnumService.GetEnumDescription(product.Category)}[/]"
                //Utan formattering
                //product.ProductId.ToString(),
                //product.Name,
                //product.Price.ToString(),
                //EnumService.GetEnumDescription(product.Category)
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowProduct(Product product)
    {
        // Egenskaperna måste vara till vänster eftersom det är en string literal!
        var panel = new Panel($@"
[blue]Id:[/]       {product.ProductId}
[blue]Namn:[/]     {product.Name}
[blue]Pris:[/]     {product.Price:C}
[blue]Kategori:[/] {EnumService.GetEnumDescription(product.Category)}
        ");
        panel.Header = new PanelHeader("[red]Produkt Info[/]");
        panel.Padding = new Padding(2, 1, 2, 1);
        panel.Border = BoxBorder.Double; // Dubbelram

        AnsiConsole.Write(panel);

        Console.WriteLine("Valfri tangent för att återgå till huvudmeny");
        Console.ReadLine();
        Console.Clear();
    }
}
