// <copyright file="StructuremapMvc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Web.Mvc;
using FizzBuzz.App_Start;
using FizzBuzz.DependencyResolution;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using StructureMap;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace FizzBuzz.App_Start
{
    /// <summary>
    /// Static Class StructuremapMvc.
    /// </summary>
    public static class StructuremapMvc
    {
        /// <summary>
        /// Gets or sets et Property.
        /// </summary>
        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        /// <summary>
        /// Dispose.
        /// </summary>
        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        public static void Start()
        {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }
    }
}