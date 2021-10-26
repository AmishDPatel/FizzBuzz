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
    public class DivisibleThreeRuleServiceTest
    {
        private DivisibleThreeRuleService divisibleThreeRule;
        private Mock<ICheckDayService> mockCheckDay;

        [SetUp]
        public void Initialise()
        {
            this.mockCheckDay = new Mock<ICheckDayService>();
            this.divisibleThreeRule = new DivisibleThreeRuleService(this.mockCheckDay.Object);
        }       
        
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, false)]
        [TestCase(15, true)]
        public void IsDivisible_WhenNumberMultipleOfThree_ReturnTrue(int number, bool result)
        {
            Assert.AreEqual(result, divisibleThreeRule.IsDivisible(number));
        }

        [TestCase(false, Constants.Fizz)]
        [TestCase(true, Constants.Wizz)]
        public void Display_WhenNotWednesday_ReturnFizz(bool input, string output)
        {
            mockCheckDay.Setup(x => x.IsDayMatch()).Returns(input);
            var result = divisibleThreeRule.GetValue();
            Assert.AreEqual(output, result);
        }
    }
}
