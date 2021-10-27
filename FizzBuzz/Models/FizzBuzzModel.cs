// <copyright file="FizzBuzzModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.Models
{
    using System.ComponentModel.DataAnnotations;
    using FizzBuzz.Utility.Common;
    using PagedList;

    /// <summary>
    /// FizzBuzzModel.
    /// </summary>
    public class FizzBuzzModel
    {
        /// <summary>
        /// Gets or sets number.
        /// </summary>
        [Required(ErrorMessage = Constants.RequiredErrorMessage)]
        [Range(1, Constants.MaxNumber, ErrorMessage = Constants.EnterNumberMessage)]
        [Display(Name = "Enter Number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets fizzBuzzListValue.
        /// </summary>
        public IPagedList<string> FizzBuzzListValue { get; set; }
    }
}