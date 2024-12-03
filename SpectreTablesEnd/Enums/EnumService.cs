using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectreTablesToRefactor.Enums
{
    internal class EnumService
    {
        // Hjälpmetod för att hämta beskrivningen från en enum
        public static string GetEnumDescription(Category category)
        {
            var field = category.GetType().GetField(category.ToString());
            var description = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault() as DescriptionAttribute;
            return description?.Description ?? category.ToString();
        }
    }
}
