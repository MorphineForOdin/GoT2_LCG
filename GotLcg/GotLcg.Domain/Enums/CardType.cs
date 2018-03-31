namespace GotLcg.Domain.Enums
{
    /// <summary>
    /// Defines different card types.
    /// </summary>
    public enum CardType : byte
    {
        /// <summary>
        /// Agenda card, contains general strategy for the game.
        /// </summary>
        Agenda = 1,

        /// <summary>
        /// Faction card (Starks, Lannister, etc..).
        /// </summary>
        Faction,

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