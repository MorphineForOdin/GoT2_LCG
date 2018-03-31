using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using GotLcg.Abstraction.Repositories.Base;
using GotLcg.Config;
using GotLcg.DataAccess.Ado.Interfaces;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace GotLcg.DataAccess.Ado.Base
{
    /// <summary>
    /// Implementation of UoW as main ADO.NET DAL entry point.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly IConfigProvider _config;
        private readonly IMapperBootstrap _mapperBootstrap;
        private readonly bool _withTransaction;
        private readonly Lazy<IRepositoryFacade> _repositoryLazy;
        private bool _disposed;
        private TransactionScope _transactionScope;
        private IDbConnection _connection;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <exception cref="ObjectDisposedException">UoW was already disposed. Please create new instance if needed.</exception>
        private IDbConnection Connection
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("UoW was already disposed. Please create new instance if needed.");
                }

                return _connection ?? (_connection = InitConnection(out _transactionScope));
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="mapperBootstrap">The mapper bootstrap.</param>
        /// <param name="withTransaction">if set to <c>true</c> [with transaction].</param>
        public UnitOfWork(IConfigProvider config, IMapperBootstrap mapperBootstrap, bool withTransaction)
        {
            _config = config;
            _mapperBootstrap = mapperBootstrap;
            _withTransaction = withTransaction;

            _repositoryLazy = new Lazy<IRepositoryFacade>(() => new RepositoryFacade(Connection, _mapperBootstrap));
        }

        #endregion

        #region Implementation of IUnitOfWork

        /// <summary>
        /// Gets the repository facade to access all registered repositories by demand.
        /// </summary>
        public IRepositoryFacade Repository => _repositoryLazy.Value;

        /// <summary>
        /// Commits all active translations in-scope of current UoW.
        /// </summary>
        public void Commit()
        {
            _transactionScope?.Complete();
        }

        /// <summary>
        /// Rollbacks all active translations in-scope of current UoW.
        /// </summary>
        public void Rollback()
        {
            Dispose(true);
        }

        #endregion

        #region IDisposible Implementation

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        ~UnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // free managed resources
                _transactionScope?.Dispose();
                _connection?.Dispose();

                _transactionScope = null;
                _connection = null;

                _disposed = true;
            }
            // free native resources if there are any.
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Initializes the new database connection.
        /// </summary>
        /// <param name="transactionScope">The transaction scope.</param>
        /// <returns></returns>
        private SqlConnection InitConnection(out TransactionScope transactionScope)
        {
            var connection = new SqlConnection(_config.GetConnectionString("Default"));

            if (_withTransaction)
            {
                var options = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.DefaultTimeout
                };

                transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, options);
            }
            else
            {
                transactionScope = null;
            }

            return connection;
        }

        #endregion
    }
}