// <copyright file="IoC.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.DependencyResolution
{
    using StructureMap;

    /// <summary>
    /// IoC.
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        /// <returns>Container.</returns>
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}