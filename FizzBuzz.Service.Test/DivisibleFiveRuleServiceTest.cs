using FizzBuzz.Service.Interface;
using FizzBuzz.Service.Service;
using FizzBuzz.Utility.Common;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class DivisibleFiveRuleServiceTest
    {
        private DivisibleFiveRuleService divisibleFiveRule;
        private Mock<ICheckDayService> mockCheckDay;

        [SetUp]
        public void Initialise()
        {
            this.mockCheckDay = new Mock<ICheckDayService>();
            this.divisibleFiveRule = new DivisibleFiveRuleService(this.mockCheckDay.Object);
        }
        
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(15, true)]
        public void IsDivisible_WhenNumberMultipleOfFive_ReturnTrue(int number, bool result)
        {
            // Assert
            Assert.AreEqual(result, this.divisibleFiveRule.IsDivisible(number));
        }

        [TestCase(false, Constants.Buzz)]
        [TestCase(true, Constants.Wuzz)]
        public void Display_WhenNotWednesday_ReturnBuzz(bool input, string output)
        {
            // Arrange
            this.mockCheckDay.Setup(x => x.IsDayMatch()).Returns(input);

            // Act
            var result = this.divisibleFiveRule.GetValue();

            // Assert
            Assert.AreEqual(output, result);
        }
    }
}
