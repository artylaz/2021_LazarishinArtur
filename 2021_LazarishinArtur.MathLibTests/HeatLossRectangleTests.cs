using _2021_LazarishinArtur.MathLib;
using NUnit.Framework;
using System;

namespace _2021_LazarishinArtur.MathLibTests
{
    [TestFixture]
    class HeatLossRectangleTests
    {
        private HeatLossRectangle heatLossRectangle;

        [SetUp]
        public void SetUp()
        {
            heatLossRectangle = new HeatLossRectangle();
        }

        #region Проверка исходных данных

        #region Проверка TempBake
        [Test]
        public void HeatLossRectangle_TempBake_True()
        {
            // arrange
            heatLossRectangle.TempBake = 5;

            // act
            var res = heatLossRectangle.TempBake > 0 && heatLossRectangle.TempBake <= 4500;

            // assert
            Assert.AreEqual(true, res);
        }

        [Test]
        public void HeatLossRectangle_TempBake_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossRectangle.TempBake = 45001);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и меньше 4500 градусов (Parameter 'TempBake')"));
        }
        #endregion

        #region Проверка WidthWindow
        [Test]
        public void HeatLossRectangle_WidthWindow_True()
        {
            // arrange
            heatLossRectangle.WidthWindow = 0.7;

            // act
            var res = heatLossRectangle.WidthWindow > 0 && heatLossRectangle.WidthWindow <= 5;

            // assert
            Assert.AreEqual(true, res);
        }

        [Test]
        public void HeatLossRectangle_WidthWindow_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossRectangle.WidthWindow = 6);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и не более 5 метров (Parameter 'WidthWindow')"));
        }

        #endregion

        #region Проверка HeightWindow
        [Test]
        public void HeatLossRectangle_HeightWindow_True()
        {
            // arrange
            heatLossRectangle.HeightWindow = 1.4;

            // act
            var res = heatLossRectangle.HeightWindow > 0 && heatLossRectangle.HeightWindow <= 5;

            // assert
            Assert.AreEqual(true, res);
        }

        [Test]
        public void HeatLossRectangle_HeightWindow_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossRectangle.HeightWindow = 6);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и не более 5 метров (Parameter 'HeightWindow')"));
        }

        #endregion

        #region Проверка WallThickness
        [Test]
        public void HeatLossRectangle_WallThickness_True()
        {
            // arrange
            heatLossRectangle.WallThickness = 0.7;

            // act
            var res = heatLossRectangle.WallThickness > 0 && heatLossRectangle.WallThickness <= 5;

            // assert
            Assert.AreEqual(true, res);
        }

        [Test]
        public void HeatLossRectangle_WallThickness_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossRectangle.WallThickness = 6);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 и не более 5 метров (Parameter 'WallThickness')"));
        }

        #endregion

        #region Проверка WindowOpenTime
        [Test]
        public void HeatLossRectangle_WindowOpenTime_True()
        {
            // arrange
            heatLossRectangle.WindowOpenTime = 5;

            // act
            var res = heatLossRectangle.WindowOpenTime > 0;

            // assert
            Assert.AreEqual(true, res);
        }

        [Test]
        public void HeatLossRectangle_WindowOpenTime_Ex_Range()
        {
            // arrange
            var ex = Assert.Throws<ArgumentException>(() => heatLossRectangle.WindowOpenTime = -1);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значение должно быть больше 0 (Parameter 'WindowOpenTime')"));
        }

        #endregion

        #endregion

        #region Проверка промежуточных расчётов

        #region Проверка RadiatingHoleArea
        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_True()
        {
            // arrange
            heatLossRectangle.WidthWindow = 1.2;
            heatLossRectangle.HeightWindow = 1.4;

            // act
            var res = heatLossRectangle.RadiatingHoleArea;

            // assert
            Assert.AreEqual(1.68, res);
        }

        [Test]
        public void HeatLossRectangle_RadiatingHoleArea_Ex_Zero()
        {
            double value;

            // arrange
            heatLossRectangle.WidthWindow = 0;
            heatLossRectangle.HeightWindow = 1.4;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossRectangle.RadiatingHoleArea);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значения WidthWindow, HeightWindow должны быть больше 0 (Parameter 'RadiatingHoleArea')"));
        }
        #endregion

        #region Проверка HeightToWallThicknessRatio
        [Test]
        public void HeatLossRectangle_HeightToWallThicknessRatio_True()
        {
            // arrange
            heatLossRectangle.WallThickness = 0.46;
            heatLossRectangle.HeightWindow = 1.2;

            // act
            var res = heatLossRectangle.HeightToWallThicknessRatio;

            // assert
            Assert.AreEqual(2.61, res);
        }

        [Test]
        public void HeatLossRectangle_HeightToWallThicknessRatio_Ex_Zero()
        {
            double value;

            // arrange
            heatLossRectangle.WallThickness = 0;
            heatLossRectangle.HeightWindow = 1.4;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossRectangle.HeightToWallThicknessRatio);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значения WallThickness, HeightWindow должны быть больше 0 (Parameter 'HeightToWallThicknessRatio')"));
        }

        #endregion

        #region Проверка WidthToHeightRatio
        [Test]
        public void HeatLossRectangle_WidthToHeightRatio_True()
        {
            // arrange
            heatLossRectangle.WidthWindow = 1.4;
            heatLossRectangle.HeightWindow = 1.2;

            // act
            var res = heatLossRectangle.WidthToHeightRatio;

            // assert
            Assert.AreEqual(1.17, res);
        }

        [Test]
        public void HeatLossRectangle_WidthToHeightRatio_Ex_Zero()
        {
            double value;

            // arrange
            heatLossRectangle.WidthWindow = 0;
            heatLossRectangle.HeightWindow = 1.4;

            // act
            var ex = Assert.Throws<ArgumentException>(() => value = heatLossRectangle.WidthToHeightRatio);

            // assert
            Assert.That(ex.Message, Is.EqualTo("Значения WidthWindow, HeightWindow должны быть больше 0 (Parameter 'WidthToHeightRatio')"));
        }

        #endregion

        #region Проверка AngularCoefficient
        [Test]
        public void HeatLossRectangle_AngularCoefficient_MoreThan10()
        {
            // arrange
            heatLossRectangle.WidthWindow = 1.4;
            heatLossRectangle.HeightWindow = 0.1;
            heatLossRectangle.WallThickness = 0.46;

            // act
            var res = heatLossRectangle.AngularCoefficient;

            // assert
            Assert.AreEqual(0.106, res);
        }

        [Test]
        public void HeatLossRectangle_AngularCoefficient_True()
        {
            // arrange
            heatLossRectangle.WidthWindow = 1.4;
            heatLossRectangle.HeightWindow = 0.2;
            heatLossRectangle.WallThickness = 0.46;

            // act
            var res = heatLossRectangle.AngularCoefficient;

            // assert
            Assert.AreEqual(0.176, res);
        }

        #endregion

        #endregion

        #region Проверка результатов

        [Test]
        public void GetApertureRatio_Test()
        {
            // arrange
            heatLossRectangle.WidthWindow = 1.4;
            heatLossRectangle.HeightWindow= 1.2;
            heatLossRectangle.WallThickness = 0.46;

            // act
            var res = heatLossRectangle.GetApertureRatio();

            // assert
            Assert.AreEqual(0.7655, res);
        }

        [Test]
        public void GetRadiationHeatLoss_Test()
        {
            // arrange
            heatLossRectangle.TempBake = 900;
            heatLossRectangle.WidthWindow = 1.4;
            heatLossRectangle.HeightWindow = 1.2;
            heatLossRectangle.WallThickness = 0.46;
            heatLossRectangle.WindowOpenTime = 720;

            // act
            var res = heatLossRectangle.GetRadiationHeatLoss();

            // assert
            Assert.AreEqual(99920334.06, res);
        }

        #endregion
    }
}
