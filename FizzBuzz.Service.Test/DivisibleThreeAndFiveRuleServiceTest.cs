using FizzBuzz.Service.Interface;
using FizzBuzz.Service.Service;
using FizzBuzz.Utility.Common;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class DivisibleThreeAndFiveRuleServiceTest
    {
        private DivisibleThreeAndFiveRuleService divisibleThreeAndFiveRule;
        private Mock<ICheckDayService> mockCheckDay;

        [SetUp]
        public void Initialise()
        {
            this.mockCheckDay = new Mock<ICheckDayService>();
            this.divisibleThreeAndFiveRule = new DivisibleThreeAndFiveRuleService(this.mockCheckDay.Object);
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(15, true)]
        public void IsDivisible_WhenNumberDivisibleByThreeAndFive_ReturnTrue(int number, bool result)
        {
            // Act
            var output = this.divisibleThreeAndFiveRule.IsDivisible(number);

            // Assert
            Assert.AreEqual(result, output);
        }

        [TestCase(false, Constants.Fizz + " " + Constants.Buzz)]
        [TestCase(true, Constants.Wizz + " " + Constants.Wuzz)]
        public void Display_WhenNotWednesday_ReturnFizzBuzz(bool input, string output)
        {
            // Arrange
            this.mockCheckDay.Setup(x => x.IsDayMatch()).Returns(input);
            
            // Act
            var result = this.divisibleThreeAndFiveRule.GetValue();

            // Assert
            Assert.AreEqual(output, result);
        }
    }
}
