namespace GotLcg.Domain.Enums
{
    /// <summary>
    /// Defines different card types.
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// Faction card (Starks, Lannister, etc..).
        /// </summary>
        Faction = 1,

        /// <summary>
        /// Agenda card, contains general strategy for the game.
        /// </summary>
        Agenda,

        /// <summary>
        /// Plot card that specify strategy for one round.
        /// </summary>
        Plot,

        /// <summary>
        /// Character card.
        /// </summary>
        Character,

        /// <summary>
        /// Location card.
        /// </summary>
        Location,

        /// <summary>
        /// Attachment card.
        /// </summary>
        Attachment,

        /// <summary>
        /// Event card.
        /// </summary>
        Event
    }
}