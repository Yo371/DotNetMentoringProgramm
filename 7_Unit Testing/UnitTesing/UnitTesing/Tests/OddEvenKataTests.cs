using NUnit.Framework;
using TasksImplementation.Tasks;

namespace UnitTesing.Tests
{
    public class OddEvenKataTests
    {
        [TestCase(1, 5, "Odd Even 3 Even 5")]
        [Test]
        public void CheckIfAllDataIsValid_ShouldPrintOddEvenAndPrimeNumbers(int num1, int num2, string expectedResult)
        {
            var result = OddEvenKata.GetPrintedNumbers(num1, num2);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(-1, 10)]
        [Test]
        public void CheckIfFirstParameterIsNegative_ThrowArgumentException(int num1, int num2)
        {
            Assert.That(() => OddEvenKata.GetPrintedNumbers(num1, num2), Throws.ArgumentException);
        }

        [TestCase(1, -10)]
        [Test]
        public void CheckIfSecondParameterIsNegative_ThrowArgumentException(int num1, int num2)
        {
            Assert.That(() => OddEvenKata.GetPrintedNumbers(num1, num2), Throws.ArgumentException);
        }

        [TestCase(5, 1)]
        [Test]
        public void CheckIfSecondParameterIsLessThanTheFirst_ThrowArgumentException(int num1, int num2)
        {
            Assert.That(() => OddEvenKata.GetPrintedNumbers(num1, num2), Throws.ArgumentException);
        }

        [TestCase(0, 10)]
        [Test]
        public void IfFirstParameterIsZero_ThrowArgumentException(int num1, int num2)
        {
            Assert.That(() => OddEvenKata.GetPrintedNumbers(num1, num2), Throws.ArgumentException);
        }

        [TestCase(5, 0)]
        [Test]
        public void CheckIfSecondParameterIsZero_ThrowArgumentException(int num1, int num2)
        {
            Assert.That(() => OddEvenKata.GetPrintedNumbers(num1, num2), Throws.ArgumentException);
        }
    }
}
