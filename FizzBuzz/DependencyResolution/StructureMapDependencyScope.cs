// <copyright file="StructureMapDependencyScope.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FizzBuzz.DependencyResolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Microsoft.Practices.ServiceLocation;

    using StructureMap;

    /// <summary>
    /// The structure map dependency scope.
    /// </summary>
    public class StructureMapDependencyScope : ServiceLocatorImplBase
    {
        private const string NestedContainerKey = "Nested.Container.Key";

        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapDependencyScope"/> class.
        /// </summary>
        /// <param name="container">IContainer.</param>
        public StructureMapDependencyScope(IContainer container)
        {
            this.Container = container ?? throw new ArgumentNullException("container");
        }

        /// <summary>
        /// Gets or sets container Property.
        /// </summary>
        public IContainer Container { get; set; }

        /// <summary>
        /// Gets or sets currentNestedContainer.
        /// </summary>
        public IContainer CurrentNestedContainer
        {
            get
            {
                return (IContainer)this.HttpContext.Items[NestedContainerKey];
            }

            set
            {
                this.HttpContext.Items[NestedContainerKey] = value;
            }
        }

        private HttpContextBase HttpContext
        {
            get
            {
                var ctx = this.Container.TryGetInstance<HttpContextBase>();
                return ctx ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            }
        }

        /// <summary>
        /// CreateNestedContainer.
        /// </summary>
        public void CreateNestedContainer()
        {
            if (this.CurrentNestedContainer != null)
            {
                return;
            }

            this.CurrentNestedContainer = this.Container.GetNestedContainer();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            this.DisposeNestedContainer();
            this.Container.Dispose();
        }

        /// <summary>
        /// DisposeNestedContainer.
        /// </summary>
        public void DisposeNestedContainer()
        {
            if (this.CurrentNestedContainer != null)
            {
                this.CurrentNestedContainer.Dispose();
                this.CurrentNestedContainer = null;
            }
        }

        /// <summary>
        /// GetServices.
        /// </summary>
        /// <param name="serviceType">Type.</param>
        /// <returns>DoGetAllInstances.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.DoGetAllInstances(serviceType);
        }

        /// <summary>
        /// DoGetAllInstances.
        /// </summary>
        /// <param name="serviceType">Type.</param>
        /// <returns>GetAllInstances.</returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return (this.CurrentNestedContainer ?? this.Container).GetAllInstances(serviceType).Cast<object>();
        }

        /// <summary>
        /// DoGetInstance.
        /// </summary>
        /// <param name="serviceType">Type.</param>
        /// <param name="key">key.</param>
        /// <returns>GetInstance.</returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            IContainer container = this.CurrentNestedContainer ?? this.Container;

            if (string.IsNullOrEmpty(key))
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? container.TryGetInstance(serviceType)
                    : container.GetInstance(serviceType);
            }

            return container.GetInstance(serviceType, key);
        }
    }
}
