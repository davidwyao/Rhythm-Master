using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * @name CompleteScreen
 * @brief This screen is displayed at the end of each game.
 * @date April 12, 2021
 */
public class CompleteScreen : MonoBehaviour
{
    /**
     * @brief The one instance of CompleteScreen, to be referenced externally.
     */
    public static CompleteScreen instance;

    /**
     * @brief The screen to be displayed.
     */
    public GameObject completeScreen;
    public TextMeshProUGUI normalHitText, goodHitText, perfectHitText, missedHitText, accuracyText, finalScoreText, userNameInput;

    /**
     * @brief The button to submit player score.
     */
    public GameObject submitButton;
    private float finalScoreSave;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    /**
     * @brief Display the completion screen to the main display.
     * @param normalCount The number of normal hits.
     * @param goodCount The number of good hits.
     * @param perfectCount The number of perfect hits.
     * @param missedCount The number of missed hits.
     * @param accuracy The player's hit accuracy, in percent.
     * @param finalScore The final score.
     */
    public void DisplayCompleteScreen (float normalCount, float goodCount, float perfectCount, float missedCount, float accuracy, float finalScore)
    {
        finalScoreSave = finalScore;
        if (!completeScreen.activeInHierarchy){
            completeScreen.SetActive(true);

            normalHitText.text = normalCount.ToString();
            goodHitText.text = goodCount.ToString();
            perfectHitText.text = perfectCount.ToString();
            missedHitText.text = missedCount.ToString();

            accuracyText.text = accuracy.ToString("F1") + "%";

            finalScoreText.text = finalScore.ToString();
        }  
    }

    /**
     * @brief Saves the player's submitted score to the high score database.
     */
    public void SaveFinalScore()
    {
        submitButton.SetActive(false); // Remove submit button after submission
        string dateSave = System.DateTime.Now.ToString("d");
        FileIO.AddEntryToLeaderboard(new LeaderboardEntry { name = userNameInput.text, score = (int)finalScoreSave, date = dateSave });
    }
}
