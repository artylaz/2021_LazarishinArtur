using System;

namespace _2021_LazarishinArtur.MathLib
{
    public class HeatLossSlot
    {
        #region Исходные данные	

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела (С0), Вт/(м^2 * K)
        /// </summary>
        private const double BLACKBODY_EMISSIVITY = 5.7;

        private double? tempBake;
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
            return Math.Round(BLACKBODY_EMISSIVITY * Math.Pow((((double)TempBake + 273) / 100), 4) * 0.28 * GetApertureRatio() * (double)WindowOpenTime, 2);
        }

        #endregion
    }
}
