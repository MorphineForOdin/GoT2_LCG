using System;

namespace GotLcg.Abstraction.Repositories.Base
{
    /// <summary>
    /// Definition of UoW to use as root DAL point.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository facade to access all registered repositories by demand.
        /// </summary>
        IRepositoryFacade Repository { get; }

        /// <summary>
        /// Commits all active translations in-scope of current UoW.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks all active translations in-scope of current UoW.
        /// </summary>
        void Rollback();
    }
}