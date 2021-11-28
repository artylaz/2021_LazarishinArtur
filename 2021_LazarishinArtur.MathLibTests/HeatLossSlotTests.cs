using _2021_LazarishinArtur.MathLib;
using NUnit.Framework;

namespace _2021_LazarishinArtur.MathLibTests
{
    [TestFixture]
    class HeatLossSlotTests
    {
        private HeatLossSlot heatLossSlot;

        [SetUp]
        public void SetUp()
        {
            heatLossSlot = new HeatLossSlot();
        }

        #region Проверка результатов

        [Test]
        public void GetApertureRatio_Test()
        {
            // arrange
            heatLossSlot.WallThickness = 0.46;

            // act
            var res = heatLossSlot.GetApertureRatio();

            // assert
            Assert.AreEqual(0.5982, res);
        }

        [Test]
        public void GetRadiationHeatLoss_Test()
        {
            // arrange
            heatLossSlot.TempBake = 900;
            heatLossSlot.WallThickness = 0.46;
            heatLossSlot.WindowOpenTime = 720;

            // act
            var res = heatLossSlot.GetRadiationHeatLoss();

            // assert
            Assert.AreEqual(13013791.39, res);
        }

        #endregion
    }
}
