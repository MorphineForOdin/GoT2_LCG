namespace GotLcg.DataAccess.Ado.Interfaces
{
    /// <summary>
    /// Provides bootstrap logic to register and resolve all mapping classes that are use in this project.
    /// </summary>
    public interface IMapperBootstrap
    {
        /// <summary>
        /// Initializes and registers all table and stored procedure mappers.
        /// </summary>
        void Init();

        /// <summary>
        /// Gets this instance of mapping class by it's type.
        /// </summary>
        /// <typeparam name="TMapper">The type of the mapper.</typeparam>
        TMapper Get<TMapper>() where TMapper : ITableMapper;
    }
}