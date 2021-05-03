using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @name LoadSettings
 * @brief Loads the player's preferences for key bindings.
 * @date April 12, 2021
 */
public class LoadSettings : MonoBehaviour
{
    /**
     * @brief Player setting for green button key binding
     */
    public Text greenButtonSettings;

    /**
     * @brief Player setting for red button key binding
     */
    public Text redButtonSettings;

    /**
     * @brief Player setting for yellow button key binding
     */
    public Text yellowButtonSettings;

    /**
     * @brief Player setting for blue button key binding
     */
    public Text blueButtonSettings;

    /**
     * @brief Player setting for pink button key binding
     */
    public Text pinkButtonSettings;

    private const int greenCode = 97;
    private const int redCode = 115;
    private const int yellowCode = 100;
    private const int blueCode = 102;
    private const int pinkCode = 118;

    // Start is called before the first frame update
    void Start()
    {
        greenButtonSettings.text = ((char)PlayerPrefs.GetInt("Green", greenCode)).ToString().ToUpper();
        redButtonSettings.text = ((char)PlayerPrefs.GetInt("Red", redCode)).ToString().ToUpper();
        yellowButtonSettings.text = ((char)PlayerPrefs.GetInt("Yellow", yellowCode)).ToString().ToUpper();
        blueButtonSettings.text = ((char)PlayerPrefs.GetInt("Blue", blueCode)).ToString().ToUpper();
        pinkButtonSettings.text = ((char)PlayerPrefs.GetInt("Pink", pinkCode)).ToString().ToUpper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
