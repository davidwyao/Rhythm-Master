using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * @name MainMenu
 * @brief Class handling the game's main menu.
 * @date April 12, 2021
 */
public class MainMenu : MonoBehaviour
{
    /**
     * @brief Called when the user starts a new game.
     */
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
