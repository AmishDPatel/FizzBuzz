// <copyright file="ControllerConvention.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.DependencyResolution
{
    using System;
    using System.Web.Mvc;

    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Pipeline;
    using StructureMap.TypeRules;

    /// <summary>
    /// ControllerConvention.
    /// </summary>
    public class ControllerConvention : IRegistrationConvention
    {
        /// <summary>
        /// Process.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="registry">Registry.</param>
        public void Process(Type type, Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }
    }
}