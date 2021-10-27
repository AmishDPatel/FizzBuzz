// <copyright file="DivisibleThreeAndFiveRuleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Service
{
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Utility.Common;

    /// <summary>
    /// Class fo DivisibleThreeAndFiveRuleService.
    /// </summary>
    public class DivisibleThreeAndFiveRuleService : IRuleService
    {
        private readonly ICheckDayService checkDayService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleThreeAndFiveRuleService"/> class.
        /// </summary>
        /// <param name="checkDayService">ICheckDayService.</param>
        public DivisibleThreeAndFiveRuleService(ICheckDayService checkDayService)
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
            return number % 3 == 0 && number % 5 == 0;
        }

        /// <summary>
        /// Method pf GetValue.
        /// </summary>
        /// <returns>string.</returns>
        public string GetValue()
        {
            return this.checkDayService.IsDayMatch() ? string.Concat(Constants.Wizz, " ", Constants.Wuzz) : string.Concat(Constants.Fizz, " ", Constants.Buzz);
        }
    }
}
