using _2021_LazarishinArtur.Web.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace _2021_LazarishinArtur.Web.Domain.Entities
{
    public class HeatLossSquaredData : CalculationDataBase
    {
        [Required]
        public double SideLength { get; set; }
    }
}
