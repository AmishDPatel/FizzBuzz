// <copyright file="FizzBuzzService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using FizzBuzz.Service.Interface;

    /// <summary>
    /// Class fo FizzBuzzService.
    /// </summary>
    public class FizzBuzzService : IFizzBuzzService
    {
        private readonly IEnumerable<IRuleService> fizzBuzzRules;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzService"/> class.
        /// </summary>
        /// <param name="fizzBuzzRules">IEnumerable.</param>
        public FizzBuzzService(IEnumerable<IRuleService> fizzBuzzRules)
        {
            this.fizzBuzzRules = fizzBuzzRules;
        }

        /// <summary>
        /// Method of GetData.
        /// </summary>
        /// <param name="inputNumber">inputNumber.</param>
        /// <returns>List of string.</returns>
        public IList<string> GetData(int inputNumber)
        {
            var resultList = new List<string>();

            for (var count = 1; count <= inputNumber; count++)
            {
                var matchedRules = this.fizzBuzzRules.Where(x => x.IsDivisible(count)).ToList();
                resultList.Add(matchedRules.Any() ? matchedRules.Select(r => r.GetValue()).LastOrDefault() : count.ToString());
            }

            return resultList;
        }
    }
}
