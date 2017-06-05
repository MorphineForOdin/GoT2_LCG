using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using GotLcg.Logger.Interfaces;

namespace GotLcg.Web.Api.App_Data.Bootstrap
{
    /// <summary>
    /// Wraps Unity IoC in order to set as default Dependency Resolver for Web API project.
    /// </summary>
    public partial class UnityResolver : IDependencyResolver
    {
        #region Static constants

        public static string ResolutionFailedMessageTemplate = "Could not get service with type - {0}";
        public static string UnexpectedExceptionMessageTemplate = "Unexpected exception occurred while getting service - {0}";

        #endregion

        #region Private fields

        /// <summary>
        /// IoC container.
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Base logger instance.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Track whether Dispose has been already called.
        /// </summary>
        private bool _disposed;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize resolver and register all project dependencies.
        /// </summary>
        /// <param name="container">Unity IoC container instance.</param>
        /// <param name="logger">Logger instance that will be used for internal logging of UnityResolver.</param>
        public UnityResolver(IUnityContainer container, ILogger logger)
        {
            this._container = container;
            this._logger = logger;
            this._disposed = false;

            this.RegisterTypes();
        }

        #endregion

        #region IDependencyResolver implementation

        /// <summary>
        /// Create new child container resolver.
        /// </summary>
        /// <returns>Child container with same types registration.</returns>
        public IDependencyScope BeginScope()
        {
            IUnityContainer child = this._container.CreateChildContainer();
            return new UnityResolver(child, _logger);
        }

        /// <summary>
        /// Tries to resolve service instance by type.
        /// </summary>
        /// <param name="serviceType">Service type.</param>
        /// <returns>Resolved service or <code>null</code> if failed.</returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return this._container.Resolve(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                this._logger.Warning(string.Format(ResolutionFailedMessageTemplate, serviceType), exception);

                // Returning null will provide WebAPI fall back on the framework's default implementation for the requested service.
                // Use [DebuggerStepThrough] attribute for avoiding annoying debugging stoppers at the application start.
                return null;
            }
            catch (Exception exception)
            {
                this._logger.Fatal(string.Format(UnexpectedExceptionMessageTemplate, serviceType), exception);
                throw;
            }
        }

        /// <summary>
        /// Tries resolve service instances by type.
        /// </summary>
        /// <param name="serviceType">Service type.</param>
        /// <returns>Collection of resolved services or empty collection if failed.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                this._logger.Warning(string.Format(ResolutionFailedMessageTemplate, serviceType), exception);

                // Returning empty collection will provide WebAPI fall back on the framework's default implementation for the requested service.
                // Use [DebuggerStepThrough] attribute for avoiding annoying debugging stoppers at the application start.
                return new List<object>();
            }
            catch (Exception exception)
            {
                this._logger.Fatal(string.Format(UnexpectedExceptionMessageTemplate, serviceType), exception);
                throw;
            }
        }

        #endregion
        
        #region IDisposable implementation
        
        /// <summary>
        /// Dispose all resources of current instance.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // Do not call finalization for this instance, treated as already cleaned manually.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Clean instance resources if not disposed yet.
        /// </summary>
        /// <param name="disposeManaged">If <code>true</code> will dispose all resources, in other case unmanaged only.</param>
        protected virtual void Dispose(bool disposeManaged)
        {
            // Check to see if Dispose has already been called.
            if (this._disposed)
            {
                return;
            }

            if (disposeManaged)
            {
                // Dispose managed resources here...
                var manageContainer = this._container as IDisposable;
                manageContainer?.Dispose();
            }

            // Call the appropriate methods to clean up unmanaged resources here...

            // Note that disposing has been done.
            this._disposed = true;
        }

        /// <summary>
        /// Destructor for cleaning instance in case Dispose method was not called.
        /// </summary>
        ~UnityResolver()
        {
            this.Dispose(false);
        }

        #endregion
    }
}