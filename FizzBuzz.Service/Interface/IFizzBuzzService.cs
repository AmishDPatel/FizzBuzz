// <copyright file="IFizzBuzzService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Service.Interface
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface of FizzBuzzService.
    /// </summary>
    public interface IFizzBuzzService
    {
        /// <summary>
        /// GetData.
        /// </summary>
        /// <param name="inputNumber">inputNumber.</param>
        /// <returns>List of string.</returns>
        IList<string> GetData(int inputNumber);
    }
}
