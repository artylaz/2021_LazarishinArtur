using _2021_LazarishinArtur.MathLib.Base;
using System;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossSlot : HeatLossBase
    {

        #region Промежуточные расчёты
        /// <summary>
        /// Угловой коэффициент (φ), -
        /// </summary>
        public double? AngularCoefficient
        {
            get
            {
                return Math.Round(0.0101 * Math.Pow((double)0.43, 3) - 0.1178 * Math.Pow((double)0.43, 2) + 0.5069 * (double)0.43, 3);
            }
        }

        #endregion

        #region Расчет результатов

        public override double GetApertureRatio()
        {
            return Math.Round(((1 + (double)AngularCoefficient) / 2) - Math.Pow((double)((1 - AngularCoefficient) / 6), 4), 4);
        }

        public override double GetRadiationHeatLoss()
        {
            return Math.Round(BLACKBODY_EMISSIVITY * Math.Pow((((double)TempBake + 273) / 100), 4) * 0.28 * GetApertureRatio() * (double)WindowOpenTime, 2);
        }

        #endregion
    }
}
