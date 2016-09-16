using Dapper;

namespace GotLcg.DataAccess.Ado.Base
{
    /// <summary>
    /// Provides strongly type mapping from entity to stored procedure.
    /// </summary>
    public class CommandMap
    {
        /// <summary>
        /// Gets or sets the name of SP command.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the command parameters.
        /// </summary>
        public CommandParam[] CommandParams { get; set; }

        /// <summary>
        /// Gets the object parameters based on CommandParams property.
        /// </summary>
        public object ObjectParams
        {
            get
            {
                var args = new DynamicParameters(new { });

                foreach (var commandParam in CommandParams)
                {
                    args.Add(commandParam.Name, commandParam.Value);
                }

                return args;
            }
        }
    }
}