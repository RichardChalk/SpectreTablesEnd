using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SpectreTablesToRefactor.Enums
{
    internal enum MenuOptions
    {
        [Description("Lägg till en produkt")]
        AddProduct,
        [Description("Visa alla produkter")]
        ViewAllProducts,
        [Description("Visa en specifik produkt")]
        ViewProduct,
        [Description("Uppdatera en produkt")]
        UpdateProduct,
        [Description("Ta bort en produkt")]
        DeleteProduct,
        [Description("Avsluta programmet")]
        Exit
    }
    internal static class MenuEnum
    {
        // När en extension-metod definieras med nyckelordet this framför sin första
        // parameter(this Enum value), betyder det att metoden kan anropas som om den
        // vore en del av typen den utökar.
        //
        // Det är därför du kan anropa GetDescription() utan att explicit skicka
        // in en parameter – den förlänger Enum.

        // Hur Extension-metoder Fungerar
        // Definierad med this: När this används framför en parameter i en extension-metod
        // (this Enum value), blir den första parametern implicit den instans som metoden anropas på.
        // Anropet: När du anropar option.GetDescription(),
        // skickar du automatiskt in option som värdet för value.
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            if (field == null)
            {
                // Detta borde egentligen aldrig hända om du arbetar med giltiga enums
                return value.ToString();
            }

            var attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
