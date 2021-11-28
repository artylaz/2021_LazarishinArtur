using _2021_LazarishinArtur.MathLib.Base;
using System;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossCircle : HeatLossBase
    {
        #region Исходные данные	

        private double diameter;

        /// <summary>
        /// Высота окна (H), м
        /// </summary>
        public double Diameter
        {
            get => diameter;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение должно быть больше 0 и не более 5 метров", nameof(Diameter));

                diameter = value;
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
                if (Diameter == 0)
                    throw new ArgumentException("Значение Diameter должно быть больше 0", nameof(RadiatingHoleArea));

                return Math.Round(3.14 * Math.Pow(Diameter, 2) / 4, 2);
            }
        }
        /// <summary>
        /// Отношение диаметра к толщине стенки (H/S), -
        /// </summary>
        public double DiameterToWallThicknessRatio
        {
            get
            {
                if (WallThickness == 0 || Diameter == 0)
                    throw new ArgumentException("Значения WallThickness, Diameter должны быть больше 0", nameof(DiameterToWallThicknessRatio));

                var diameterToWallThicknessRatio = Math.Round((Diameter / WallThickness), 2);

                if (diameterToWallThicknessRatio < 0 || diameterToWallThicknessRatio >= 5)
                    throw new ArgumentException("Значение не может быть таким", nameof(DiameterToWallThicknessRatio));

                return diameterToWallThicknessRatio;
            }
        }
        /// <summary>
        /// Угловой коэффициент (φ), -
        /// </summary>
        public double AngularCoefficient
        {
            get
            {
                return Math.Round(0.0041 * Math.Pow(DiameterToWallThicknessRatio, 4) - 0.0444 * Math.Pow(DiameterToWallThicknessRatio, 3) + 0.1318 * Math.Pow(DiameterToWallThicknessRatio, 2) + 0.0675 * DiameterToWallThicknessRatio, 3);
            }
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
