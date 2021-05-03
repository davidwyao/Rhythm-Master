using System.Collections;
using System.Collections.Generic;

[System.Serializable]
/**
 * @name LeaderboardEntry
 * @brief Wrapper class for an entry in the high scores list.
 * @date April 12, 2021
 */
public class LeaderboardEntry
{
    /**
     * @brief The chosen name for the entrant.
     */
    public string name;

    /**
     * @brief The entrant's score.
     */
    public int score;

    /**
     * @brief The date the entry was made.
     */
    public string date;
}
