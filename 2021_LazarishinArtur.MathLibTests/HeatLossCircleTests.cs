using _2021_LazarishinArtur.MathLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_LazarishinArtur.MathLibTests
{
    [TestFixture]
    class HeatLossCircleTests
    {
        private HeatLossCircle heatLossCircle;

        [SetUp]
        public void SetUp()
        {
            heatLossCircle = new HeatLossCircle();
        }

        #region Проверка исходных данных

        #region Проверка SideLength
        [Test]
        public void HeatLossRectangle_Diameter_True()
        {
            // arrange
            heatLossCircle.Diameter = 0.7;

            // act
            var res = heatLossCircle.Diameter;

            // assert
            Assert.AreEqual(0.7, res);
        }

        [Test]
        public void HeatLossRectangle_Diameter_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossCircle.Diameter = 6);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и не более 5 метров (Parameter 'Diameter')"));
        }

        #endregion

        #endregion

        #region Проверка промежуточных расчётов

        #region Проверка RadiatingHoleArea
        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_True()
        {
            // arrange
            heatLossCircle.Diameter = 1.4;

            // act
            var res = heatLossCircle.RadiatingHoleArea;

            // assert
            Assert.AreEqual(1.54, res);
        }

        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_Ex_Zero()
        {
            double value;

            // arrange
            heatLossCircle.Diameter = 0;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossCircle.RadiatingHoleArea);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение Diameter должно быть больше 0 (Parameter 'RadiatingHoleArea')"));
        }
        #endregion

        #region Проверка HeightToWallThicknessRatio
        [Test]
        public void HeatLossRectangle_DiameterToWallThicknessRatio_True()
        {
            // arrange
            heatLossCircle.WallThickness = 0.46;
            heatLossCircle.Diameter = 1.2;

            // act
            var res = heatLossCircle.DiameterToWallThicknessRatio;

            // assert
            Assert.AreEqual(2.61, res);
        }

        [Test]
        public void HeatLossRectangle_DiameterToWallThicknessRatio_Ex_Zero()
        {
            double value;

            // arrange
            heatLossCircle.WallThickness = 0;
            heatLossCircle.Diameter = 1.4;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossCircle.DiameterToWallThicknessRatio);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значения WallThickness, Diameter должны быть больше 0 (Parameter 'DiameterToWallThicknessRatio')"));
        }

        #endregion

        #endregion

        #region Проверка результатов

        [Test]
        public void GetApertureRatio_Test()
        {
            // arrange
            heatLossCircle.Diameter = 1.4;
            heatLossCircle.WallThickness = 0.46;

            // act
            var res = heatLossCircle.GetApertureRatio();

            // assert
            Assert.AreEqual(0.7630, res);
        }

        [Test]
        public void GetRadiationHeatLoss_Test()
        {
            // arrange
            heatLossCircle.TempBake = 900;
            heatLossCircle.Diameter = 1.4;
            heatLossCircle.WallThickness = 0.46;
            heatLossCircle.WindowOpenTime = 720;

            // act
            var res = heatLossCircle.GetRadiationHeatLoss();

            // assert
            Assert.AreEqual(91294509.44, res);
        }

        #endregion
    }
}
