// <copyright file="IRuleService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Interface
{
    /// <summary>
    /// Interface of Rule.
    /// </summary>
    public interface IRuleService
    {
        /// <summary>
        /// IsDivisible.
        /// </summary>
        /// <param name="number">number.</param>
        /// <returns>bool.</returns>
        bool IsDivisible(int number);

        /// <summary>
        /// GetValue.
        /// </summary>
        /// <returns>string.</returns>
        string GetValue();
    }
}
