namespace GotLcg.Abstraction.Repositories.Base
{
    /// <summary>
    /// Factory for starting a new DAL as UoW.
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Begins (creates) new UoW with optional transaction options.
        /// </summary>
        /// <param name="withTransaction">If set to <c>true</c> transaction 
        /// is also created after connection initialization.</param>
        /// <returns>New instance of UoW.</returns>
        IUnitOfWork Begin(bool withTransaction = true);
    }
}