// <copyright file="DivisibleFiveRuleServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Test
{
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Service.Service;
    using FizzBuzz.Utility.Common;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test class of DivisibleFiveRuleServiceTest.
    /// </summary>
    [TestFixture]
    public class DivisibleFiveRuleServiceTest
    {
        private DivisibleFiveRuleService divisibleFiveRule;
        private Mock<ICheckDayService> mockCheckDay;

        /// <summary>
        /// Initialise the setup.
        /// </summary>
        [SetUp]
        public void Initialise()
        {
            this.mockCheckDay = new Mock<ICheckDayService>();
            this.divisibleFiveRule = new DivisibleFiveRuleService(this.mockCheckDay.Object);
        }

        /// <summary>
        /// Test when number is multiple of five.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="result">result.</param>
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

        /// <summary>
        /// Test of when not wednesday.
        /// </summary>
        /// <param name="input">input.</param>
        /// <param name="output">output.</param>
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
