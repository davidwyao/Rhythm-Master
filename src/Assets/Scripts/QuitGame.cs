using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name QuitGame
 * @brief Exit game.
 * @date April 12, 2021
 */
public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Quit Game Initiated");
        Application.Quit();
    }
}
