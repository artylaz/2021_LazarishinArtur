using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2021_LazarishinArtur.Web.Domain.Entities.Base
{
    public class CalculationDataBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public double TempBake { get; set; }

        [Required]
        public double WallThickness { get; set; }

        [Required]
        public double WindowOpenTime { get; set; }

        [Required]
        public double ApertureRatio { get; set; }
        [Required]
        public double RadiationHeatLoss { get; set; }

        [Required]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
