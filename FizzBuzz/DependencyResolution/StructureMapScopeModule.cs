// <copyright file="StructureMapScopeModule.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.DependencyResolution
{
    using System.Web;

    using FizzBuzz.App_Start;

    using StructureMap.Web.Pipeline;

    /// <summary>
    /// StructureMapScopeModule.
    /// </summary>
    public class StructureMapScopeModule : IHttpModule
    {
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Init.
        /// </summary>
        /// <param name="context">HttpApplication.</param>
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) =>
            {
                HttpContextLifecycle.DisposeAndClearAll();
                StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }
    }
}