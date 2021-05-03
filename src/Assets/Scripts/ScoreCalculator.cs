using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name ScoreCalculator
 * @brief Handles score incrementation and multiplier application.
 * @date April 12, 2021
 */
public class ScoreCalculator : MonoBehaviour
{
    /**
     * @brief The number of notes going toward the next multiplier.
     */
    public int multiplierTracker;

    /**
     * @brief The number of notes that must be hit for the next multiplier.
     */
    public int[] multiplierThresholds;

    /**
     * @brief The score for a normal hit, before multipliers.
     */
    public const int scorePerNote = 100;

    /**
     * @brief The score for a good hit, before multipliers.
     */
    public const int scorePerGoodNote = 125;

    /**
     * @brief The score for a perfect hit, before multipliers.
     */
    public const int scorePerPerfectNote = 150;

    /**
     * @brief The score for a long hit, before multipliers.
     */
    public const int scorePerLongNote = 200;

    /**
     * @brief The instance of ScoreCalculator to be referenced globally.
     */
    public static ScoreCalculator instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NoteHit(int currentMultiplier)
    {
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                GameManager.instance.SetMultiplier(currentMultiplier + 1);
            }
        }
    }

    /**
     * @brief Called when a normal hit has been made.
     * @param currentScore The current gameplay score.
     * @param currentMultiplier The current gameplay multiplier.
     * @return 1. Used to increment the number of normal hits logged.
     */
    public float NormalHit(int currentScore, int currentMultiplier)
    {
        GameManager.instance.SetScore(currentScore + scorePerNote * currentMultiplier);
        NoteHit(currentMultiplier);

        return 1f;
    }

    /**
     * @brief Called when a good hit has been made.
     * @param currentScore The current gameplay score.
     * @param currentMultiplier The current gameplay multiplier.
     * @return 1. Used to increment the number of good hits logged.
     */
    public float GoodHit(int currentScore, int currentMultiplier)
    {
        GameManager.instance.SetScore(currentScore + scorePerGoodNote * currentMultiplier);
        NoteHit(currentMultiplier);

        return 1f;
    }

    /**
     * @brief Called when a perfect hit has been made.
     * @param currentScore The current gameplay score.
     * @param currentMultiplier The current gameplay multiplier.
     * @return 1. Used to increment the number of perfect hits logged.
     */
    public float PerfectHit(int currentScore, int currentMultiplier)
    {
        GameManager.instance.SetScore(currentScore + scorePerPerfectNote * currentMultiplier);
        NoteHit(currentMultiplier);

        return 1f;
    }

    /**
     * @brief Called when a long hit has been made.
     * @param currentScore The current gameplay score.
     * @param currentMultiplier The current gameplay multiplier.
     * @return 1. Used to increment the number of long hits logged.
     */
    public float LongHit(int currentScore, int currentMultiplier)
    {
        GameManager.instance.SetScore(currentScore + scorePerLongNote * currentMultiplier);
        NoteHit(currentMultiplier);
        
        return 1f;
    }

    /**
     * @brief Called when a note has been missed.
     * @return 1. Used to increment the number of misses logged.
     */
    public float NoteMissed()
    {
        GameManager.instance.SetMultiplier(1);
        multiplierTracker = 0;

        return 1f;
    }

    /**
     * @brief Calculates the user's net accuracy.
     * @param normalHits The number of normal hits made.
     * @param goodHits The number of good hits made.
     * @param perfectHits The number of perfect hits made.
     * @param totalNotes The number of notes spawned.
     * @return The user's hit accuracy, in percent.
     */
    public float AccuracyCalculation(float normalHits, float goodHits, float perfectHits, float totalNotes)
    {
        float totalHits = normalHits + goodHits + perfectHits;
        return (((float)totalHits/GameManager.instance.totalNotes) * 100f);
    }
}
