using GotLcg.Config;
using GotLcg.Config.Implementation;
using Microsoft.Practices.Unity;

namespace GotLcg.Web.Api.App_Data.Bootstrap
{
    /// <summary>
    /// Contains all type registration.
    /// </summary>
    public partial class UnityResolver
    {
        #region Types registration

        /// <summary>
        /// Register project dependencies.
        /// </summary>
        public void RegisterTypes()
        {
            _container?
                .RegisterType<IConfigProvider, FileConfigProvider>(new TransientLifetimeManager())
                .RegisterType<IConfigSection, FileConfigSection>(new TransientLifetimeManager());
        }

        #endregion
    }
}