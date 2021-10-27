using FizzBuzz.Service.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Service.Test
{
    [TestFixture]
    public class CheckDayServiceTest
    {
        [Test]
        public void IsDayMatchingT_WhenDayIsEmpty_ReturnFalse()
        {
            // Arrange
            var day = new CheckDayService("");
            
            // Act
            var actualResult = day.IsDayMatch();
            
            // Assert
            Assert.IsFalse(actualResult);
        }

        [Test]
        public void IsDayMatching_WhenDayIsToday_ReturnTrue()
        {
            // Arrange
            var day = new CheckDayService(DateTime.Now.DayOfWeek.ToString());

            // Act
            var actualResult = day.IsDayMatch();

            // Assert
            Assert.IsTrue(actualResult);
        }

        [Test]
        public void IsDayMatching_WhenDayIsTomorrow_ReturnFalse()
        {
            // Arrange
            var day = new CheckDayService(DateTime.Now.AddDays(1).DayOfWeek.ToString());

            // Act
            var actualResult = day.IsDayMatch();

            // Assert
            Assert.IsFalse(actualResult);
        }
    }
}
