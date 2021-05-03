using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name PauseMenu
 * @brief The menu to be displayed when gameplay is paused.
 * @date April 12, 2021
 */
public class PauseMenu : MonoBehaviour
{
    /**
     * @brief True if the game is paused.
     */
    public static bool Paused = false;

    /**
     * @brief True if settings are being shwon.
     */
    public static bool SettingsShown = false;

    /**
     * @brief The pause menu display.
     */
    public GameObject PauseMenuUI;

    /**
     * @brief The settings menu display.
     */
    public GameObject settingsMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Press escape to pause
        {
            if (SettingsShown) // escape to exit settings when already being displayed
            {
                SettingsShown = false;
                settingsMenuUI.SetActive(false);
            }
            else if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }   
    }

    /**
     * @brief Resume gameplay after it has been paused.
     */
    public void Resume()
    {
        if(GameManager.instance.songStarted)
        {
            GameManager.instance.song.Play();
            GameManager.instance.guitar.Play();
        }
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    /**
     * @brief Pause gameplay in progress. Stops note spawning, movement, and music playing.
     */
    public void Pause()
    {
        GameManager.instance.song.Pause();
        GameManager.instance.guitar.Pause();
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    /**
     * @brief Displays settings menu UI.
     */
    public void Settings()
    {
        SettingsShown = true;
        settingsMenuUI.SetActive(true);
    }
}
