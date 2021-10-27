// <copyright file="FizzBuzzServiceTest.cs" company="PlaceholderCompany">
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
    /// Test class FizzBuzzServiceTest.
    /// </summary>
    [TestFixture]
    public class FizzBuzzServiceTest
    {
        private Mock<IRuleService> mockRule;

        /// <summary>
        /// Test of GetDataTest.
        /// </summary>
        /// <param name="inputValue">inputValue.</param>
        /// <param name="expectedResult">expectedResult.</param>
        [TestCase(0, (object)new string[] { })]
        [TestCase(1, (object)new string[] { "1" })]
        [TestCase(2, (object)new string[] { "1", "2" })]
        public void GetDataTest(int inputValue, string[] expectedResult)
        {
            // Arrange
            this.mockRule = new Mock<IRuleService>();

            this.mockRule.Setup(x => x.IsDivisible(inputValue)).Returns(false);

            this.mockRule.Setup(y => y.GetValue()).Returns(string.Empty);

            var businesrule = new[]
            {
                this.mockRule.Object,
                this.mockRule.Object,
            };
            var results = new FizzBuzzService(businesrule);

            // Act
            var actual = results.GetData(inputValue);

            // Assert
            Assert.AreEqual(actual, expectedResult);
        }

        /// <summary>
        /// Test of when input number is three.
        /// </summary>
        /// <param name="inputValue">inputValue.</param>
        /// <param name="expectedResult">expectedResult.</param>
        [TestCase(3, Constants.Fizz)]
        public void GetFizzBuzzData_WhenInputNumberIsThree_ReturnFizz(int inputValue, string expectedResult)
        {
            // Arrange
            this.mockRule = new Mock<IRuleService>();

            this.mockRule.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.mockRule.Setup(y => y.GetValue()).Returns(Constants.Fizz);

            var businesrule = new[]
            {
                this.mockRule.Object,
            };
            var results = new FizzBuzzService(businesrule);

            // Act
            var actual = results.GetData(inputValue);

            // Assert
            Assert.AreEqual(actual[2], expectedResult);
        }

        /// <summary>
        /// Test of when input number is five.
        /// </summary>
        /// <param name="inputValue">inputValue.</param>
        /// <param name="expectedResult">expectedResult.</param>
        [TestCase(5, Constants.Buzz)]
        public void GetFizzBuzzData_WhenInputNumberIsFive_ReturnBuzz(int inputValue, string expectedResult)
        {
            // Arrange
            this.mockRule = new Mock<IRuleService>();

            this.mockRule.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.mockRule.Setup(y => y.GetValue()).Returns(Constants.Buzz);

            var businesrule = new[]
            {
                this.mockRule.Object,
            };
            var results = new FizzBuzzService(businesrule);

            // Act
            var actual = results.GetData(inputValue);

            // Assert
            Assert.AreEqual(actual[4], expectedResult);
        }

        /// <summary>
        /// Test of when input number is divisible by three and five.
        /// </summary>
        /// <param name="inputValue">inputValue.</param>
        /// <param name="expectedResult">expectedResult.</param>
        [TestCase(15, Constants.Fizz + " " + Constants.Buzz)]
        public void GetFizzBuzzData_WhenInputNumberIsDivisibleByThreeAndFive_ReturnFizzBuzz(int inputValue, string expectedResult)
        {
            // Arrange
            this.mockRule = new Mock<IRuleService>();

            this.mockRule.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.mockRule.Setup(y => y.GetValue()).Returns(Constants.Fizz + " " + Constants.Buzz);

            var businesrule = new[]
            {
                this.mockRule.Object,
            };
            var results = new FizzBuzzService(businesrule);

            // Act
            var actual = results.GetData(inputValue);

            // Assert
            Assert.AreEqual(actual[14], expectedResult);
        }
    }
}
