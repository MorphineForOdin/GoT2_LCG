using GotLcg.Abstraction.Repositories.Base;
using GotLcg.Config;
using GotLcg.DataAccess.Ado.Interfaces;

namespace GotLcg.DataAccess.Ado.Base
{
    /// <summary>
    /// Implementation of factory for starting a new DAL as UoW.
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// The configuration provider read-only field.
        /// </summary>
        private readonly IConfigProvider _config;

        /// <summary>
        /// The mapper bootstrap read-only field.
        /// </summary>
        private readonly IMapperBootstrap _mapperBootstrap;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkFactory"/> class.
        /// </summary>
        /// <param name="config">The configuration provider.</param>
        /// <param name="mapperBootstrap">The mapper bootstrap.</param>
        public UnitOfWorkFactory(IConfigProvider config, IMapperBootstrap mapperBootstrap)
        {
            _config = config;
            _mapperBootstrap = mapperBootstrap;
        }

        /// <summary>
        /// Begins (creates) new UoW with optional transaction options.
        /// </summary>
        /// <param name="withTransaction">If set to <c>true</c> transaction
        /// is also created after connection initialization.</param>
        /// <returns>
        /// New instance of UoW.
        /// </returns>
        public IUnitOfWork Begin(bool withTransaction = true)
        {
            return new UnitOfWork(_config, _mapperBootstrap, withTransaction);
        }
    }
}