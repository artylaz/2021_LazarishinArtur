using _2021_LazarishinArtur.MathLib;
using NUnit.Framework;
using System;

namespace _2021_LazarishinArtur.MathLibTests
{
    [TestFixture]
    class HeatLossSquaredTests
    {
        private HeatLossSquared heatLossSquared;

        [SetUp]
        public void SetUp()
        {
            heatLossSquared = new HeatLossSquared();
        }

        #region Проверка исходных данных

        #region Проверка SideLength
        [Test]
        public void HeatLossRectangle_SideLength_True()
        {
            // arrange
            heatLossSquared.SideLength = 0.7;

            // act
            var res = heatLossSquared.SideLength;

            // assert
            Assert.AreEqual(0.7, res);
        }

        [Test]
        public void HeatLossRectangle_SideLength_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossSquared.SideLength = 6);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и не более 5 метров (Parameter 'SideLength')"));
        }

        #endregion

        #endregion

        #region Проверка промежуточных расчётов

        #region Проверка RadiatingHoleArea
        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_True()
        {
            // arrange
            heatLossSquared.SideLength = 2;

            // act
            var res = heatLossSquared.RadiatingHoleArea;

            // assert
            Assert.AreEqual(4, res);
        }

        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_Ex_Zero()
        {
            double value;

            // arrange
            heatLossSquared.SideLength = 0;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossSquared.RadiatingHoleArea);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение SideLength должно быть больше 0 (Parameter 'RadiatingHoleArea')"));
        }
        #endregion

        #region Проверка HeightToWallThicknessRatio
        [Test]
        public void HeatLossRectangle_HeightToWallThicknessRatio_True()
        {
            // arrange
            heatLossSquared.WallThickness = 0.46;
            heatLossSquared.SideLength = 1.2;

            // act
            var res = heatLossSquared.HeightToWallThicknessRatio;

            // assert
            Assert.AreEqual(2.61, res);
        }

        [Test]
        public void HeatLossRectangle_HeightToWallThicknessRatio_Ex_Zero()
        {
            double value;

            // arrange
            heatLossSquared.WallThickness = 0;
            heatLossSquared.SideLength = 1.4;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossSquared.HeightToWallThicknessRatio);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значения WallThickness, SideLength должны быть больше 0 (Parameter 'HeightToWallThicknessRatio')"));
        }

        #endregion

        #region Проверка WidthToHeightRatio
        [Test]
        public void HeatLossRectangle_WidthToHeightRatio_True()
        {
            // arrange
            heatLossSquared.SideLength = 1.4;

            // act
            var res = heatLossSquared.WidthToHeightRatio;

            // assert
            Assert.AreEqual(1, res);
        }

        [Test]
        public void HeatLossRectangle_WidthToHeightRatio_Ex_Zero()
        {
            double value;

            // arrange
            heatLossSquared.SideLength = 0;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossSquared.WidthToHeightRatio);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение SideLength должно быть больше 0 (Parameter 'WidthToHeightRatio')"));
        }

        #endregion

        #endregion

        #region Проверка результатов

        [Test]
        public void GetApertureRatio_Test()
        {
            // arrange
            heatLossSquared.SideLength = 1.4;
            heatLossSquared.WallThickness = 0.46;

            // act
            var res = heatLossSquared.GetApertureRatio();

            // assert
            Assert.AreEqual(0.7805, res);
        }

        [Test]
        public void GetRadiationHeatLoss_Test()
        {
            // arrange
            heatLossSquared.TempBake = 900;
            heatLossSquared.SideLength = 1.4;
            heatLossSquared.WallThickness = 0.46;
            heatLossSquared.WindowOpenTime = 720;

            // act
            var res = heatLossSquared.GetRadiationHeatLoss();

            // assert
            Assert.AreEqual(118857989.36, res);
        }

        #endregion
    }
}
