using NUnit.Framework;
using TasksImplementation.Tasks;

namespace UnitTesing.Tests
{
    public class CalcStatsKataTests
    {
        private List<int> _list;

        [OneTimeSetUp]
        public void Setup()
        {
            _list = new List<int> { 6, 9, 15, -2, 92, 11 };
        }

        [Test]
        public void ShouldReturnMinValue()
        {
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.TypeValue.Minimum);

            double expectedResult = -2;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnMaxValue()
        {
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.TypeValue.Maximum);

            double expectedResult = 92;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnNumberOfElements()
        {
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.TypeValue.NumberOfElements);

            double expectedResult = 6;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void ShouldReturnAverageValue()
        {
            var result = CalcStatsKata.GetStats(_list, CalcStatsKata.TypeValue.Average);

            double expectedResult = 21.833;
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void CheckIfValueIsZero_ThrowArgumentException()
        {
            Assert.That(() => CalcStatsKata.GetStats(_list, 0), Throws.ArgumentException);
        }

        [Test]
        public void CheckIfSequenceOfIntegerNumbersIsNull_ThrowArgumentNullException()
        {
            Assert.That(() =>
                    CalcStatsKata.GetStats(null, CalcStatsKata.TypeValue.Maximum),
                Throws.ArgumentNullException);
        }
    }
}
