using System.Data;

namespace GotLcg.DataAccess.Ado.Base
{
    /// <summary>
    /// Provides mapping for stored procedure parameter.
    /// </summary>
    public class CommandParam
    {
        #region Properties

        /// <summary>
        /// Gets the name of command parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the value command parameter.
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Gets or sets the db type of the parameter.
        /// </summary>
        public DbType? DbType { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandParam"/> class.
        /// </summary>
        /// <param name="name">The parameter name.</param>
        /// <param name="value">The parameter value.</param>
        public CommandParam(string name, object value)
        {
            Name = name;
            Value = value;
        }

        #endregion
    }
}