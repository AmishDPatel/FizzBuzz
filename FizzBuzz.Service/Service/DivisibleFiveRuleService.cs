// <copyright file="DivisibleFiveRuleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Service
{
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Utility.Common;

    /// <summary>
    /// Class of DivisibleFiveRuleService.
    /// </summary>
    public class DivisibleFiveRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleFiveRuleService"/> class.
        /// </summary>
        /// <param name="checkDayService">ICheckDayService.</param>
        public DivisibleFiveRuleService(ICheckDayService checkDayService)
        {
            this.checkDayService = checkDayService;
        }

        /// <summary>
        /// Methof of IsDivisible.
        /// </summary>
        /// <param name="number">number.</param>
        /// <returns>bool.</returns>
        public bool IsDivisible(int number)
        {
            return number % 5 == 0;
        }

        /// <summary>
        /// Method of GetValue.
        /// </summary>
        /// <returns>string.</returns>
        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? Constants.Wuzz : Constants.Buzz;
        }
    }
}
