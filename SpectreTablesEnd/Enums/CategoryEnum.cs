using System.ComponentModel;
namespace SpectreTablesToRefactor.Enums;

internal enum Category
{
    [Description("Kök")]
    Kitchen,
    [Description("Städ")]
    Cleaning,
    [Description("Personvård")]
    PersonalCare,
    [Description("Hem")]
    Home
}
