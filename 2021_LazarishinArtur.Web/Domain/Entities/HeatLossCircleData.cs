using _2021_LazarishinArtur.Web.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace _2021_LazarishinArtur.Web.Domain.Entities
{
    public class HeatLossCircleData : CalculationDataBase
    {
        [Required]
        public double Diameter { get; set; }
    }
}
