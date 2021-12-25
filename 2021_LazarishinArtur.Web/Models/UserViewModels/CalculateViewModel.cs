using _2021_LazarishinArtur.MathLib;
using System;
using System.ComponentModel.DataAnnotations;

namespace _2021_LazarishinArtur.Web.Models.UserViewModels
{
    public class CalculateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        public DateTime DateAdded { get; set; }

        [Required]
        public string WindowShape { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и не более 5 метров")]
        public double WidthWindow { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и не более 5 метров")]
        public double HeightWindow { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и не более 5 метров")]
        public double Diameter { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и не более 5 метров")]
        public double SideLength { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и меньше 4500 градусов")]
        public double TempBake { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, 5, ErrorMessage = "Значение должно быть больше 0 и не более 5 метров")]
        public double WallThickness { get; set; }

        [Required(ErrorMessage = "Не указано значение")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Значение должно быть больше 0")]
        public double WindowOpenTime { get; set; }

        public double GetApertureRatio
        {
            get
            {
                switch (WindowShape)
                {
                    case "Прямоугольное":
                        return new HeatLossRectangle
                        {
                            HeightWindow = HeightWindow,
                            TempBake = TempBake,
                            WallThickness = WallThickness,
                            WidthWindow = WidthWindow,
                            WindowOpenTime = WindowOpenTime
                        }.GetApertureRatio();

                    case "Квадратное":
                        return new HeatLossSquared
                        {
                            SideLength = SideLength,
                            WindowOpenTime = WindowOpenTime,
                            WallThickness = WallThickness,
                            TempBake = TempBake
                        }.GetApertureRatio();

                    case "Круглое":
                        return new HeatLossCircle
                        {
                            Diameter = Diameter,
                            TempBake = TempBake,
                            WallThickness = WallThickness,
                            WindowOpenTime = WindowOpenTime
                        }.GetApertureRatio();

                    default: return 0;
                }
            }
        }

        public double GetRadiationHeatLoss
        {
            get
            {
                switch (WindowShape)
                {
                    case "Прямоугольное":
                        return new HeatLossRectangle
                        {
                            HeightWindow = HeightWindow,
                            TempBake = TempBake,
                            WallThickness = WallThickness,
                            WidthWindow = WidthWindow,
                            WindowOpenTime = WindowOpenTime
                        }.GetRadiationHeatLoss();

                    case "Квадратное":
                        return new HeatLossSquared
                        {
                            SideLength = SideLength,
                            WindowOpenTime = WindowOpenTime,
                            WallThickness = WallThickness,
                            TempBake = TempBake
                        }.GetRadiationHeatLoss();

                    case "Круглое":
                        return new HeatLossCircle
                        {
                            Diameter = Diameter,
                            TempBake = TempBake,
                            WallThickness = WallThickness,
                            WindowOpenTime = WindowOpenTime
                        }.GetRadiationHeatLoss();

                    default: return 0;
                }
            }
        }


    }
}
