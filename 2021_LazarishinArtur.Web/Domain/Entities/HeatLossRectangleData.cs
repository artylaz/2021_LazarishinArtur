using _2021_LazarishinArtur.Web.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace _2021_LazarishinArtur.Web.Domain.Entities
{
    public class HeatLossRectangleData : CalculationDataBase
    {
        [Required]
        public double WidthWindow { get; set; }

        [Required]
        public double HeightWindow { get; set; }
    }
}
