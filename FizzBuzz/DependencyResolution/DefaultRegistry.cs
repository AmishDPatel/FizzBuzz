// <copyright file="DefaultRegistry.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.DependencyResolution
{
    using System.Configuration;
    using FizzBuzz.Service.Interface;
    using FizzBuzz.Service.Service;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    /// <summary>
    /// DefaultRegistry.
    /// </summary>
    public class DefaultRegistry : Registry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRegistry"/> class.
        /// </summary>
        public DefaultRegistry()
        {
            this.Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

            // For<IExample>().Use<Example>();
            this.For<ICheckDayService>().Use<CheckDayService>().Ctor<string>().Is(ConfigurationManager.AppSettings["DayOfWeek"].ToString());
            this.For<IRuleService>().Use<DivisibleThreeRuleService>();
            this.For<IRuleService>().Use<DivisibleFiveRuleService>();
            this.For<IRuleService>().Use<DivisibleThreeAndFiveRuleService>();
            this.For<IFizzBuzzService>().Use<FizzBuzzService>();
        }
    }
}