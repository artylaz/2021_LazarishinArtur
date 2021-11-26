using System;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossSquared
    {
        #region Исходные данные	

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела (С0), Вт/(м^2 * K)
        /// </summary>
        private const double BLACKBODY_EMISSIVITY = 5.7;

        private double? tempBake;
        private double? sideLength;
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
        /// Высота окна (H), м
        /// </summary>
        public double? SideLength
        {
            get
            {
                if (sideLength == null)
                    throw new ArgumentException("Значение не указано", nameof(SideLength));

                return sideLength;
            }
            set => sideLength = value;
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
        public double? RadiatingHoleArea { get => Math.Round((double)(SideLength * SideLength), 2); }

        /// <summary>
        /// Отношение высоты к толщине стенки (H/S), -
        /// </summary>
        public double? HeightToWallThicknessRatio { get => Math.Round((double)(SideLength / WallThickness), 2); }

        /// <summary>
        /// Отношение ширины к высоте (B/H), -
        /// </summary>
        public double? WidthToHeightRatio
        {
            get
            {
                double widthToHeightRatio = Math.Round((double)(SideLength / SideLength), 2);

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
                return Math.Round(0.0034 * Math.Pow((double)HeightToWallThicknessRatio, 4) - 0.0358 * Math.Pow((double)HeightToWallThicknessRatio, 3) + 0.0969 * Math.Pow((double)HeightToWallThicknessRatio, 2) + 0.1253 * (double)HeightToWallThicknessRatio, 3);
            }
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
            return Math.Round(BLACKBODY_EMISSIVITY * Math.Pow((((double)TempBake + 273) / 100), 4) * (double)RadiatingHoleArea * GetApertureRatio() * (double)WindowOpenTime, 2);
        }

        #endregion
    }
}
