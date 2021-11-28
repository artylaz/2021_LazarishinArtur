using System;

namespace _2021_LazarishinArtur.MathLib.Base
{
    public abstract class HeatLossBase
    {
        #region Исходные данные	

        /// <summary>
        /// Коэффициент излучения абсолютно черного тела (С0), Вт/(м^2 * K)
        /// </summary>
        internal const double BLACKBODY_EMISSIVITY = 5.7;

        private double tempBake;
        private double wallThickness;
        private double windowOpenTime;

        /// <summary>
        /// Температура в печи (tпеч), °С
        /// </summary>
        public double TempBake
        {
            get => tempBake;

            set
            {
                if (value < 0 || value > 4500)
                    throw new ArgumentException("Значение должно быть больше 0 и меньше 4500 градусов", nameof(TempBake));

                tempBake = value;
            }

        }

        /// <summary>
        /// Толщина стенки (S), м
        /// </summary>
        public double WallThickness
        {
            get => wallThickness;
            set
            {
                if (value < 0 || value >= 5)
                    throw new ArgumentException("Значение должно быть больше 0 и не более 5 метров", nameof(WallThickness));

                wallThickness = value;
            }
        }

        /// <summary>
        /// Время открытия окна (τ), с
        /// </summary>
        public double WindowOpenTime
        {
            get => windowOpenTime;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Значение должно быть больше 0", nameof(WindowOpenTime));

                windowOpenTime = value;
            }
        }

        #endregion

        #region Расчет результатов
        /// <summary>
        /// Метод по расчёту коэффициента диафрагмирования
        /// </summary>
        /// <returns>Коэффициент диафрагмирования(Φ), -</returns>
        public abstract double GetApertureRatio();

        /// <summary>
        /// Метод по расчёту тепловых потерь излучением
        /// </summary>
        /// <returns>Потери теплоты излучения (Qл), Дж</returns>
        public abstract double GetRadiationHeatLoss();
        #endregion
    }
}
