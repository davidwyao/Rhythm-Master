using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * @name GameManager
 * @brief Overarching manager of method calls between classes, and game state information.
 * @detail Stores all statistics about the current game session, and manages game music.
 * @date April 12, 2021
 */
public class GameManager : MonoBehaviour
{
    /**
     * @brief The music to play during gameplay.
     */
    public AudioSource song;

    /**
     * @brief The accompanying music, to play only when the player has hit the most recent note.
     */
    public AudioSource guitar;

    /**
     * @brief The instance of GameManager to be referenced globally.
     */
    public static GameManager instance;

    /**
     * @brief The current score during the session.
     */
    public int currentScore;

    /**
     * @brief The current score multiplier during the session.
     */
    public int currentMultiplier;

    /**
     * @brief False if the song has not begun playing.
     */
    public bool songStarted = false;

    /**
     * @brief Total notes spawned.
     */
    public float totalNotes = 0;

    /**
     * @brief Normal hits by the player.
     */
    public float normalHits = 0;

    /**
     * @brief Good hits by the player.
     */
    public float goodHits = 0;

    /**
     * @brief Perfect hits by the player.
     */
    public float perfectHits = 0;

    /**
     * @brief Missed hits by the player.
     */
    public float missedHits = 0;

    /**
     * @brief Net hit accuracy, in percent.
     */
    public float accuracy = 0;

    /**
     * @brief Baseline score to be awarded per note hit, before multipliers and accuracy bonuses.
     */
    public int scorePerNote = 100;

    /**
     * @brief The complete sequence of notes to spawn for the selected song.
     * @detail Notes from left to right are number from 0 through 4. Long notes are additionally denoted by a decimal following this number.\n
     *         Simultaneous notes are separated by a slash (/). For example, 0.2 gives a long leftmost note of length 2.
     */
    public string[] noteList;
    
    /**
     * @brief Display text for score.
     */
    public TextMeshProUGUI scoreText;

    /**
     * @brief Display text for multiplier.
     */
    public TextMeshProUGUI multiText;

    /*
    * @brief Default volume of the audio
    */
    private float defaultVolume;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentScore = 0;
        currentMultiplier = 1;
        noteList = FileIO.instance.ReadFile("./Maps/demo.txt", ',');
        AudioListener.volume = PlayerPrefs.GetFloat("volume", defaultVolume);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.Paused && !song.isPlaying && songStarted) // Not paused, song ended, song had played before
        {
            GameComplete();
        }
    }

    /**
     * @brief Start playing music.
     */
    public void StartMusic()
    {
        song.Play();
        guitar.Play();
        guitar.mute = true; // If player misses the very first note
    }

    void NoteHit()
    {
        multiText.text = "Multiplier: x" + currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    /**
     * @brief Called during a normal hit.
     */
    public void NormalHit ()
    {
        if (guitar.mute)
            guitar.mute = false;
        normalHits += ScoreCalculator.instance.NormalHit(currentScore, currentMultiplier);
        Debug.Log("Normal Hit");
        NoteHit();
    }

    /**
     * @brief Called during a good hit.
     */
    public void GoodHit ()
    {
        if (guitar.mute)
            guitar.mute = false;
        goodHits += ScoreCalculator.instance.GoodHit(currentScore, currentMultiplier);
        NoteHit();
        Debug.Log("Good Hit");
    }

    /**
     * @brief Called during a perfect hit.
     */
    public void PerfectHit ()
    {
        if (guitar.mute)
            guitar.mute = false;
        perfectHits += ScoreCalculator.instance.PerfectHit(currentScore, currentMultiplier);
        NoteHit();
        Debug.Log("Perfect Hit");
    }

    /**
     * @brief Called after a long note is completed.
     */
    public void LongHit()
    {
        normalHits += ScoreCalculator.instance.LongHit(currentScore, currentMultiplier);
        NoteHit();
        Debug.Log("Long Note Hit");
    }

    /**
     * @brief Called when a note is missed.
     */
    public void NoteMissed ()
    {
        if (!guitar.mute)
            guitar.mute = true;
        missedHits += ScoreCalculator.instance.NoteMissed();
        NoteHit();
        Debug.Log("Missed");
    }

    /**
     * @brief Called when a long note has been hit.
     */
    public void LongClicked()
    {
        if (guitar.mute)
            guitar.mute = false;
    }

    /**
     * @brief Setter method for multiplier.
     * @param mult The new multiplier.
     */
    public void SetMultiplier(int mult)
    {
        currentMultiplier = mult;
    }

    /**
     * @brief Setter method for score.
     * @param score The new score.
     */
    public void SetScore(int score)
    {
        currentScore = score;
    }

    private void GameComplete() // Called at the end of the song
    {
        accuracy = ScoreCalculator.instance.AccuracyCalculation(normalHits, goodHits, perfectHits, totalNotes);
        CompleteScreen.instance.DisplayCompleteScreen(normalHits, goodHits, perfectHits, missedHits, accuracy, currentScore);
    }
}
