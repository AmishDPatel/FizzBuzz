using FizzBuzz.Controllers;
using FizzBuzz.Models;
using FizzBuzz.Service.Interface;
using FizzBuzz.Utility.Common;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FizzBuzz.Tests.Controllers
{
    [TestFixture]
    public class FizzBuzzControllerTest
    {
        private Mock<IFizzBuzzService> mockFizzBuzzService;
        private FizzBuzzController fizzBuzzController;
        private IList<string> expectedList;

        [SetUp]
        public void Initialise()
        {
            this.mockFizzBuzzService = new Mock<IFizzBuzzService>();
            this.fizzBuzzController = new FizzBuzzController(this.mockFizzBuzzService.Object);
            this.expectedList = new List<string> { "1", "2", "fizz" };
        }

        [Test]
        public void Display_InputNumberThree()
        {
            // Arrange
            var model = new FizzBuzzModel()
            {
                Number = 3
            };

            this.mockFizzBuzzService.Setup(p => p.GetData(It.IsAny<int>())).Returns(this.expectedList);
            
            // Act
            var result = this.fizzBuzzController.DisplayFizzBuzz(model) as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, Constants.ActionName);
            var resultModel = result.Model as FizzBuzzModel;
            Assert.AreEqual(3, this.expectedList.Count);
        }

        [Test]
        public void Display_WithInvalidModelState()
        {
            // Arrange
            var model = new FizzBuzzModel() { };
            this.fizzBuzzController.ViewData.ModelState.AddModelError("Limit", Constants.EnterNumberMessage);

            // Act
            var result = fizzBuzzController.DisplayFizzBuzz(model) as ViewResult;

            // Assert
            Assert.AreEqual(result.ViewName, Constants.ActionName);
        }

        [TestCase(5, (object)new string[] { "1", "2", "fizz", "4", "buzz" })]
        [TestCase(15, (object)new string[] { "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz", "11", "fizz", "13", "14", "fizz buzz" })]
        public void Post_DisplayTest(int value, string[] expectedResult)
        {
            // Arrange
            this.mockFizzBuzzService.Setup(x => x.GetData(It.IsAny<int>())).Returns(expectedResult);
            var fizzBuzzController = new FizzBuzzController(this.mockFizzBuzzService.Object);
            
            // Act
            var output = fizzBuzzController.DisplayFizzBuzz(new FizzBuzzModel() { Number = value }) as ViewResult;
            var outputList = (FizzBuzzModel)output.ViewData.Model;

            // Assert
            Assert.AreEqual(expectedResult.Length, outputList.Number);
        }
    }
}
