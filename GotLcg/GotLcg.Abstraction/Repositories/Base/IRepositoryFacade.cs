namespace GotLcg.Abstraction.Repositories.Base
{
    /// <summary>
    /// Place to register all repository interfaces.
    /// </summary>
    public interface IRepositoryFacade
    {
        /// <summary>
        /// Gets the card repository.
        /// </summary>
        ICardRepository Card { get; }

        /// <summary>
        /// Gets the card icon repository.
        /// </summary>
        ICardIconRepository CardIcon { get; }

        /// <summary>
        /// Gets the deck repository.
        /// </summary>
        IDeckRepository Deck { get; }

        /// <summary>
        /// Gets the deck card repository.
        /// </summary>
        IDeckCardRepository DeckCard { get; }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        IUserRepository User { get; }

        /// <summary>
        /// Gets the user profile repository.
        /// </summary>
        IUserProfileRepository UserProfile { get; }
    }
}