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
    class FizzBuzzServiceTest
    {
        private IList<IRuleService> rules;
        private Mock<IRuleService> ruleMock;
        private FizzBuzzService fizzBuzzBervice;
        private Mock<IRuleService> fizzRule;
        private Mock<IRuleService> buzzRule;

        [SetUp]
        public void Initialise()
        {
            fizzRule = new Mock<IRuleService>();
            buzzRule = new Mock<IRuleService>();

            rules = new List<IRuleService>()
            {
                fizzRule.Object,
                buzzRule.Object
            };

            fizzBuzzBervice = new FizzBuzzService(rules);
        }

        [TestCase(0, (object)new string[] { })]
        [TestCase(1, (object)new string[] { "1" })]
        [TestCase(2, (object)new string[] { "1", "2" })]
        public void GetDataTest(int inputValue, string[] expectedResult)
        {
            this.ruleMock = new Mock<IRuleService>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(false);

            this.ruleMock.Setup(y => y.GetValue()).Returns(string.Empty);

            var businesrule = new[]
            {
                this.ruleMock.Object,
                this.ruleMock.Object

            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetData(inputValue);

            Assert.AreEqual(actual, expectedResult);
        }

        [TestCase(3, Constants.Fizz)]
        public void GetFizzBuzzData_ReturnFizz_WhenInputNumberIsThree(int inputValue, string expectedResult)
        {
            this.ruleMock = new Mock<IRuleService>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.ruleMock.Setup(y => y.GetValue()).Returns(Constants.Fizz);

            var businesrule = new[]
            {
                this.ruleMock.Object
            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetData(inputValue);

            Assert.AreEqual(actual[2], expectedResult);
        }


        [TestCase(5, Constants.Buzz)]
        public void GetFizzBuzzData_ReturnBuzz_WhenInputNumberIsFive(int inputValue, string expectedResult)
        {
            this.ruleMock = new Mock<IRuleService>();

            this.ruleMock.Setup(x => x.IsDivisible(inputValue)).Returns(true);

            this.ruleMock.Setup(y => y.GetValue()).Returns(Constants.Buzz);

            var businesrule = new[]
            {
                this.ruleMock.Object
            };
            var results = new FizzBuzzService(businesrule);

            var actual = results.GetData(inputValue);

            Assert.AreEqual(actual[4], expectedResult);
        }
    }
}
