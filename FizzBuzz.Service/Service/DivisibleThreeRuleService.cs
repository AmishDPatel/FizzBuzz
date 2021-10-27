// <copyright file="DivisibleThreeRuleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Service
{
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Utility.Common;

    /// <summary>
    /// Class of DivisibleThreeRuleService.
    /// </summary>
    public class DivisibleThreeRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleThreeRuleService"/> class.
        /// </summary>
        /// <param name="checkDayService">ICheckDayService.</param>
        public DivisibleThreeRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        /// <summary>
        /// Method of IsDivisible.
        /// </summary>
        /// <param name="number">number.</param>
        /// <returns>bool.</returns>
        public bool IsDivisible(int number)
        {
            return number % 3 == 0;
        }

        /// <summary>
        /// Method of GetValue.
        /// </summary>
        /// <returns>string.</returns>
        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wizz : Constants.Fizz;
        }
    }
}
