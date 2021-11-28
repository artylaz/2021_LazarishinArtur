using _2021_LazarishinArtur.MathLib.Base;
using System;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossSquared : HeatLossBase
    {
        #region Исходные данные	

        private double sideLength;

        /// <summary>
        /// Высота окна (H), м
        /// </summary>
        public double SideLength
        {
            get => sideLength;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение должно быть больше 0 и не более 5 метров", nameof(SideLength));

                sideLength = value;
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
                if (SideLength == 0)
                    throw new ArgumentException("Значение SideLength должно быть больше 0", nameof(RadiatingHoleArea));

                return Math.Round((SideLength * SideLength), 2);
            }
        }

        /// <summary>
        /// Отношение высоты к толщине стенки (H/S), -
        /// </summary>
        public double HeightToWallThicknessRatio
        {
            get
            {
                if (WallThickness == 0 || SideLength == 0)
                    throw new ArgumentException("Значения WallThickness, SideLength должны быть больше 0", nameof(HeightToWallThicknessRatio));

                var heightToWallThicknessRatio = Math.Round((SideLength / WallThickness), 2);

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
                if (SideLength == 0)
                    throw new ArgumentException("Значение SideLength должно быть больше 0", nameof(WidthToHeightRatio));

                double widthToHeightRatio = Math.Round((SideLength / SideLength), 2);

                if (widthToHeightRatio > 1 || widthToHeightRatio < 1)
                    throw new ArgumentException("Значение не может быть таким", nameof(WidthToHeightRatio));

                return widthToHeightRatio;
            }

        }

        /// <summary>
        /// Угловой коэффициент (φ), -
        /// </summary>
        public double AngularCoefficient
        {
            get => Math.Round(0.0034 * Math.Pow(HeightToWallThicknessRatio, 4) - 0.0358 * Math.Pow(HeightToWallThicknessRatio, 3) + 0.0969 * Math.Pow(HeightToWallThicknessRatio, 2) + 0.1253 * HeightToWallThicknessRatio, 3);
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
