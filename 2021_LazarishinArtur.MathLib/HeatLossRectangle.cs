using _2021_LazarishinArtur.MathLib.Base;
using System;
using System.Collections.Generic;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossRectangle : HeatLossBase
    {
        #region Исходные данные	

        private double widthWindow;
        private double heightWindow;

        /// <summary>
        /// Ширина окна (B), м
        /// </summary>
        public double WidthWindow
        {
            get => widthWindow;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение должно быть больше 0 и не более 5 метров", nameof(WidthWindow));

                widthWindow = value;
            }
        }

        /// <summary>
        /// Высота окна (H), м
        /// </summary>
        public double HeightWindow
        {
            get => heightWindow;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение должно быть больше 0 и не более 5 метров", nameof(HeightWindow));

                heightWindow = value;
            }
        }

        #endregion

        #region Промежуточные расчёты

        /// <summary>
        /// Площадь излучающего отверстия (F), м^2
        /// </summary>
        public double RadiatingHoleArea
        {
            get
            {
                if (WidthWindow == 0 || HeightWindow == 0)
                    throw new ArgumentException("Значения WidthWindow, HeightWindow должны быть больше 0", nameof(RadiatingHoleArea));

                return Math.Round((WidthWindow * HeightWindow), 2);
            }
        }

        /// <summary>
        /// Отношение высоты к толщине стенки (H/S), -
        /// </summary>
        public double HeightToWallThicknessRatio
        {
            get
            {
                if (WallThickness == 0 || HeightWindow == 0)
                    throw new ArgumentException("Значения WallThickness, HeightWindow должны быть больше 0", nameof(HeightToWallThicknessRatio));

                var heightToWallThicknessRatio = Math.Round((HeightWindow / WallThickness), 2);

                if (heightToWallThicknessRatio < 0 || heightToWallThicknessRatio >= 5)
                    throw new ArgumentException("Значение не может быть таким", nameof(HeightToWallThicknessRatio));

                return heightToWallThicknessRatio;
            }
        }

        /// <summary>
        /// Отношение ширины к высоте (B/H), -
        /// </summary>
        public double WidthToHeightRatio
        {
            get
            {
                if (WidthWindow == 0 || HeightWindow == 0)
                    throw new ArgumentException("Значения WidthWindow, HeightWindow должны быть больше 0", nameof(WidthToHeightRatio));

                double widthToHeightRatio = Math.Round((WidthWindow / HeightWindow), 2);

                if (widthToHeightRatio < 0 )
                    throw new ArgumentException("Значение не может быть таким", nameof(WidthToHeightRatio));

                return widthToHeightRatio;
            }

        }
        /// <summary>
        /// Угловой коэффициент (φ), -
        /// </summary>
        public double AngularCoefficient { get => Interpolation(WidthToHeightRatio, GetAngularCoefficients()); }

        #endregion

        #region Расчёт по номограмме

        /// <summary>
        /// Рассчитывает угловые коэффициенты по номограммам
        /// </summary>
        /// <returns>Словарь, где ключ - это отношение ширины к высоте окна, а значение - это угловой коэффициент</returns>
        private Dictionary<double, double> GetAngularCoefficients()
        {
            return new Dictionary<double, double>
            {
                { 1, Math.Round(0.0034 * Math.Pow(HeightToWallThicknessRatio,4) - 0.0358 * Math.Pow(HeightToWallThicknessRatio,3) + 0.0969 * Math.Pow(HeightToWallThicknessRatio,2) + 0.1253 * HeightToWallThicknessRatio, 3) },
                { 1.4, Math.Round(0.0028 * Math.Pow(HeightToWallThicknessRatio,4) - 0.0262 * Math.Pow(HeightToWallThicknessRatio,3) + 0.0454 * Math.Pow(HeightToWallThicknessRatio,2) + 0.2259 * HeightToWallThicknessRatio, 3) },
                { 2, Math.Round(-0.0014 * Math.Pow(HeightToWallThicknessRatio,5) + 0.019 * Math.Pow(HeightToWallThicknessRatio,4) - 0.0876 * Math.Pow(HeightToWallThicknessRatio,3) + 0.1224 * Math.Pow(HeightToWallThicknessRatio, 2) + 0.2328 * (double)HeightToWallThicknessRatio, 3) },
                { 3, Math.Round(0.0027 * Math.Pow(HeightToWallThicknessRatio,4) - 0.0248 * Math.Pow(HeightToWallThicknessRatio,3) + 0.0268 * Math.Pow(HeightToWallThicknessRatio,2) + 0.3 * HeightToWallThicknessRatio, 3) },
                { 5, Math.Round(0.0054 * Math.Pow(HeightToWallThicknessRatio,3) - 0.0806 * Math.Pow(HeightToWallThicknessRatio,2) + 0.4252 * HeightToWallThicknessRatio, 3) },
                { 10, Math.Round(0.0088 * Math.Pow(HeightToWallThicknessRatio,3) - 0.108 * Math.Pow(HeightToWallThicknessRatio,2) + 0.4819 * HeightToWallThicknessRatio, 3) },
                { 11, Math.Round(0.0101 * Math.Pow(HeightToWallThicknessRatio,3) - 0.1178 * Math.Pow(HeightToWallThicknessRatio,2) + 0.5069 * HeightToWallThicknessRatio, 3) }
            };
        }

        /// <summary>
        /// Метод рассчитывает интерполяцию
        /// </summary>
        /// <param name="widthToHeightRatio">Отношение ширины к высоте окна (B/H), -</param>
        /// <param name="angularCoefficients">Словарь, где ключ - это отношение ширины к высоте окна, а значение - это угловой коэффициент</param>
        /// <returns>Угловой коэффициент (φ), -</returns>
        private static double Interpolation(double widthToHeightRatio, Dictionary<double, double> angularCoefficients)
        {
            double x1 = 0;
            double x2 = 0;
            double y1 = 0;
            double y2 = 0;

            foreach (var item in angularCoefficients)
            {
                if (item.Key == widthToHeightRatio)
                    return item.Value;

                if (item.Key > 10)
                {
                    return item.Value;
                }

                if (item.Key < widthToHeightRatio)
                {
                    x1 = item.Key;
                    y1 = item.Value;
                }

                if (item.Key > widthToHeightRatio)
                {
                    x2 = item.Key;
                    y2 = item.Value;
                    break;
                }
            }

            if (x1 != 0 && x2 != 0 && y1 != 0 && y2 != 0)
                return Math.Round((y1 + ((widthToHeightRatio - x1) / (x2 - x1) * (y2 - y1))), 3);
            else
                return 0;
        }
        #endregion

        #region Расчет результатов

        public override double GetApertureRatio()
        {
            return Math.Round(((1 + AngularCoefficient) / 2) - Math.Pow(((1 - AngularCoefficient) / 6), 4), 4);
        }

        public override double GetRadiationHeatLoss()
        {
            return Math.Round(BLACKBODY_EMISSIVITY * Math.Pow(((TempBake + 273) / 100), 4) * RadiatingHoleArea * GetApertureRatio() * WindowOpenTime, 2);
        }

        #endregion
    }
}
