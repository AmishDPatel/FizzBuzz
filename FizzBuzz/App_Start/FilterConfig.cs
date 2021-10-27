// <copyright file="FilterConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz
{
    using System.Web.Mvc;

    /// <summary>
    /// FilterConfig.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters.
        /// </summary>
        /// <param name="filters">GlobalFilterCollection.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
