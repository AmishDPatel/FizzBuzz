// <copyright file="CheckDayService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Service
{
    using System;
    using FizzBuzz.Service.Interface;

    /// <summary>
    /// Class of CheckDayService.
    /// </summary>
    public class CheckDayService : ICheckDayService
    {
        private readonly string day;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckDayService"/> class.
        /// </summary>
        /// <param name="dayOfWeek">dayOfWeek.</param>
        public CheckDayService(string dayOfWeek)
        {
            this.day = dayOfWeek;
        }

        /// <summary>
        /// Method of IsDayMatch.
        /// </summary>
        /// <returns>bool.</returns>
        public bool IsDayMatch()
        {
            return DateTime.Now.DayOfWeek.ToString() == this.day;
        }
    }
}
