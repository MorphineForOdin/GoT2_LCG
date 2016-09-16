using System;
using System.Data;
using GotLcg.Abstraction.Repositories;
using GotLcg.Abstraction.Repositories.Base;
using GotLcg.DataAccess.Ado.Interfaces;
using GotLcg.DataAccess.Ado.Repositories;

namespace GotLcg.DataAccess.Ado.Base
{
    /// <summary>
    /// Place to initialize all registered repository properties.
    /// </summary>
    /// <seealso cref="GotLcg.Abstraction.Repositories.Base.IRepositoryFacade" />
    public class RepositoryFacade : IRepositoryFacade
    {
        #region Private Fields

        /// <summary>
        /// The card repository as lazy backing field.
        /// </summary>
        private readonly Lazy<ICardRepository> _cardLazy;

        /// <summary>
        /// The card icon repository as lazy backing field.
        /// </summary>
        private readonly Lazy<ICardIconRepository> _cardIconLazy;

        /// <summary>
        /// The deck repository as lazy backing field.
        /// </summary>
        private readonly Lazy<IDeckRepository> _deckLazy;

        /// <summary>
        /// The deck card repository as lazy backing field.
        /// </summary>
        private readonly Lazy<IDeckCardRepository> _deckCardLazy;

        /// <summary>
        /// The user repository as lazy backing field.
        /// </summary>
        private readonly Lazy<IUserRepository> _userLazy;

        /// <summary>
        /// The user profile repository as lazy backing field.
        /// </summary>
        private readonly Lazy<IUserProfileRepository> _userProfileLazy;

        #endregion

        #region Implementation of IRepositoryFacade

        /// <summary>
        /// Gets the card repository.
        /// </summary>
        public ICardRepository Card => _cardLazy.Value;

        /// <summary>
        /// Gets the card icon repository.
        /// </summary>
        public ICardIconRepository CardIcon => _cardIconLazy.Value;

        /// <summary>
        /// Gets the deck repository.
        /// </summary>
        public IDeckRepository Deck => _deckLazy.Value;

        /// <summary>
        /// Gets the deck card repository.
        /// </summary>
        public IDeckCardRepository DeckCard => _deckCardLazy.Value;

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        public IUserRepository User => _userLazy.Value;

        /// <summary>
        /// Gets the user profile repository.
        /// </summary>
        public IUserProfileRepository UserProfile => _userProfileLazy.Value;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFacade"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="mapperBootstrap">The mapper bootstrap.</param>
        public RepositoryFacade(IDbConnection connection, IMapperBootstrap mapperBootstrap)
        {
            _cardLazy = new Lazy<ICardRepository>(() => new CardRepository(connection, mapperBootstrap));
            _cardIconLazy = new Lazy<ICardIconRepository>(() => new CardIconRepository(connection, mapperBootstrap));

            _deckLazy = new Lazy<IDeckRepository>(() => new DeckRepository(connection, mapperBootstrap));
            _deckCardLazy = new Lazy<IDeckCardRepository>(() => new DeckCardRepository(connection, mapperBootstrap));

            _userLazy = new Lazy<IUserRepository>(() => new UserRepository(connection, mapperBootstrap));
            _userProfileLazy = new Lazy<IUserProfileRepository>(() => new UserProfileRepository(connection, mapperBootstrap));
        }

        #endregion
    }
}