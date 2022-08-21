using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// List of units used to measure weight
    /// </summary>
    public enum UnitsList
    {
        [Display(Name = "No Unit")]
        NoUnit,
        Feet,
        Inches,
        Stones,
        Pounds,
        Metres,
        Centimetres,
        Kilograms,
        Grams
    }
}