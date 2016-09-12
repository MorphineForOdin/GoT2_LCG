namespace GotLcg.Domain.Enums
{
    /// <summary>
    /// Defines different challenge icon types.
    /// </summary>
    public enum ChallengeIcon
    {
        /// <summary>
        /// Military challenge with the goal  to kill an opponent’s characters.
        /// </summary>
        Military = 1,

        /// <summary>
        /// Intrigue challenge with the goal to discard cards from an opponent’s hand.
        /// </summary>
        Intrigue,

        /// <summary>
        /// Power challenge with the goal to move power from an opponent’s faction card to yours.
        /// </summary>
        Power
    }
}