using System;
using System.Collections.Generic;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossRectangle
    {
        #region Исходные данные	

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела (С0), Вт/(м^2 * K)
        /// </summary>
        private const double BLACKBODY_EMISSIVITY = 5.7;

        private double? tempBake;
        private double? widthWindow;
        private double? heightWindow;
        private double? wallThickness;
        private double? windowOpenTime;

        /// <summary>
        /// Температура в печи (tпеч), °С
        /// </summary>
        public double? TempBake
        {
            get
            {
                if (tempBake == null)
                    throw new ArgumentException("Значение не указано", nameof(TempBake));

                return tempBake;
            }
            set => tempBake = value;
        }

        /// <summary>
        /// Ширина окна (B), м
        /// </summary>
        public double? WidthWindow
        {
            get
            {
                if (widthWindow == null)
                    throw new ArgumentException("Значение не указано", nameof(WidthWindow));

                return widthWindow;
            }
            set => widthWindow = value;
        }

        /// <summary>
        /// Высота окна (H), м
        /// </summary>
        public double? HeightWindow
        {
            get
            {
                if (heightWindow == null)
                    throw new ArgumentException("Значение не указано", nameof(HeightWindow));

                return heightWindow;
            }
            set => heightWindow = value;
        }

        /// <summary>
        /// Толщина стенки (S), м
        /// </summary>
        public double? WallThickness
        {
            get
            {
                if (wallThickness == null)
                    throw new ArgumentException("Значение не указано", nameof(WallThickness));

                return wallThickness;
            }
            set => wallThickness = value;
        }

        /// <summary>
        /// Время открытия окна (τ), с
        /// </summary>
        public double? WindowOpenTime
        {
            get
            {
                if (windowOpenTime == null)
                    throw new ArgumentException("Значение не указано", nameof(WindowOpenTime));

                return windowOpenTime;
            }
            set => windowOpenTime = value;
        }

        #endregion

        #region Промежуточные расчёты

        /// <summary>
        /// Площадь излучающего отверстия (F), м^2
        /// </summary>
        public double? RadiatingHoleArea { get => Math.Round((double)(WidthWindow * HeightWindow), 2); }

        /// <summary>
        /// Отношение высоты к толщине стенки (H/S), -
        /// </summary>
        public double? HeightToWallThicknessRatio { get => Math.Round((double)(HeightWindow / WallThickness), 2); }

        /// <summary>
        /// Отношение ширины к высоте (B/H), -
        /// </summary>
        public double? WidthToHeightRatio
        {
            get
            {
                double widthToHeightRatio = Math.Round((double)(WidthWindow / HeightWindow), 2);

                if (widthToHeightRatio < 1 || widthToHeightRatio > 10)
                    throw new ArgumentException("Значение не может быть таким", nameof(WidthToHeightRatio));

                return widthToHeightRatio;
            }

        }
        /// <summary>
        /// Угловой коэффициент (φ), -
        /// </summary>
        public double? AngularCoefficient
        {
            get
            {
                return Interpolation(WidthToHeightRatio, GetAngularCoefficients());
            }
        }

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
                { 1, Math.Round(0.0034 * Math.Pow((double)HeightToWallThicknessRatio,4) - 0.0358 * Math.Pow((double)HeightToWallThicknessRatio,3) + 0.0969 * Math.Pow((double)HeightToWallThicknessRatio,2) + 0.1253 * (double)HeightToWallThicknessRatio, 3) },
                { 1.4, Math.Round(0.0028 * Math.Pow((double)HeightToWallThicknessRatio,4) - 0.0262 * Math.Pow((double)HeightToWallThicknessRatio,3) + 0.0454 * Math.Pow((double)HeightToWallThicknessRatio,2) + 0.2259 * (double)HeightToWallThicknessRatio, 3) },
                { 2, Math.Round(-0.0014 * Math.Pow((double)HeightToWallThicknessRatio,5) + 0.019 * Math.Pow((double)HeightToWallThicknessRatio,4) - 0.0876 * Math.Pow((double)HeightToWallThicknessRatio,3) + 0.1224 * Math.Pow((double)HeightToWallThicknessRatio, 2) + 0.2328 * (double)HeightToWallThicknessRatio, 3) },
                { 3, Math.Round(0.0027 * Math.Pow((double)HeightToWallThicknessRatio,4) - 0.0248 * Math.Pow((double)HeightToWallThicknessRatio,3) + 0.0268 * Math.Pow((double)HeightToWallThicknessRatio,2) + 0.3 * (double)HeightToWallThicknessRatio, 3) },
                { 5, Math.Round(0.0054 * Math.Pow((double)HeightToWallThicknessRatio,3) - 0.0806 * Math.Pow((double)HeightToWallThicknessRatio,2) + 0.4252 * (double)HeightToWallThicknessRatio, 3) },
                { 10, Math.Round(0.0088 * Math.Pow((double)HeightToWallThicknessRatio,3) - 0.108 * Math.Pow((double)HeightToWallThicknessRatio,2) + 0.4819 * (double)HeightToWallThicknessRatio, 3) }
            };
        }

        /// <summary>
        /// Метод рассчитывает интерполяцию
        /// </summary>
        /// <param name="widthToHeightRatio">Отношение ширины к высоте окна (B/H), -</param>
        /// <param name="angularCoefficients">Словарь, где ключ - это отношение ширины к высоте окна, а значение - это угловой коэффициент</param>
        /// <returns>Угловой коэффициент (φ), -</returns>
        private double? Interpolation(double? widthToHeightRatio, Dictionary<double, double> angularCoefficients)
        {
            double? x1 = null;
            double? x2 = null;
            double? y1 = null;
            double? y2 = null;

            foreach (var item in angularCoefficients)
            {
                if (item.Key == widthToHeightRatio)
                    return item.Value;

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


            if (x1 != null && x2 != null && y1 != null && y2 != null)
                return Math.Round((double)(y1 + ((widthToHeightRatio - x1) / (x2 - x1) * (y2 - y1))), 3);
            else
                return null;
        }
        #endregion

        #region Расчет результатов

        /// <summary>
        /// Метод по расчёту коэффициента диафрагмирования
        /// </summary>
        /// <returns>Коэффициент диафрагмирования(Φ), -</returns>
        public double GetApertureRatio()
        {
            return Math.Round(((1 + (double)AngularCoefficient) / 2) - Math.Pow((double)((1 - AngularCoefficient) / 6), 4), 4);
        }

        /// <summary>
        /// Метод по расчёту тепловых потерь излучением
        /// </summary>
        /// <returns>Потери теплоты излучения (Qл), Дж</returns>
        public double GetRadiationHeatLoss()
        {
            return Math.Round(BLACKBODY_EMISSIVITY * Math.Pow((((double)TempBake + 273) / 100), 4) * (double)RadiatingHoleArea * GetApertureRatio() * (double)WindowOpenTime,2);
        }

        #endregion
    }
}
