// <copyright file="CheckDayServiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Test
{
    using System;
    using FizzBuzz.Service.Service;
    using NUnit.Framework;

    /// <summary>
    /// Test class fo CheckDayService.
    /// </summary>
    [TestFixture]
    public class CheckDayServiceTest
    {
        /// <summary>
        /// Test of when day is empty.
        /// </summary>
        [Test]
        public void IsDayMatching_WhenDayIsEmpty_ReturnFalse()
        {
            // Arrange
            var day = new CheckDayService(string.Empty);

            // Act
            var actualResult = day.IsDayMatch();

            // Assert
            Assert.IsFalse(actualResult);
        }

        /// <summary>
        /// Test of when day is today.
        /// </summary>
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

        /// <summary>
        /// Test of when day is tomorrow.
        /// </summary>
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
