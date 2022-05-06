using NUnit.Framework;
using TasksImplementation.Tasks;

namespace UnitTesing.Tests
{
    public class StringSumKataTests
    {
        [TestCase(null, "", "0")]
        [TestCase("", "", "0")]
        [TestCase(null, null, "0")]
        [Test]
        public void IfStringIsEmptyOrNull_SumReturnZero(string str1, string str2, string expectedResult)
        {
            var result = StringSumKata.Sum(str1, str2);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(" 5", "7 ", "12")]
        [TestCase("2", "4", "6")]
        [TestCase("2.0  ", "4", "6")]
        [TestCase("2.3", "4", "6.3")]
        [TestCase("0002", "4", "6")]
        [Test]
        public void IfDataIsValid_ReturnSum(string str1, string str2, string expectedResult)
        {
            var result = StringSumKata.Sum(str1, str2);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("2147483647", "2147483647", "-2")]
        [Test]
        public void IfStringValueIsIntMaxValue(string str1, string str2, string expectedResult)
        {
            var result = StringSumKata.Sum(str1, str2);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("-795", "B77", "0")]
        [TestCase("sdfsdf", "B77", "0")]
        [TestCase("-795", "-3", "0")]
        [Test]
        public void IfDataIsInvalid_SumReturnsZero(string str1, string str2, string expectedResult)
        {
            var result = StringSumKata.Sum(str1, str2);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase("2.0", "2.0")]
        [Test]
        public void IfNumberIsFloat_ReturnsZero(string str1, string str2)
        {
            Assert.That(() => StringSumKata.Sum(str1, str2), Throws.Exception);
        }
    }
}