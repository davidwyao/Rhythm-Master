using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @name DetectKey
 * @brief Detects the alphanumeric key the player chooses for a given input.
 * @date April 12, 2021
 */
public class DetectKey : MonoBehaviour
{
    /**
     * @brief The key the player selected.
     */
    public string keyPressed;

    /**
     * @brief The object related to the key.
     */
    public GameObject key;

    /**
     * @brief The colour of the key the player selected.
     */
    public string keyColour;

    /**
     * @brief The text reflecting the key the player chose.
     */
    public Text settingsButtonText;

    /**
     * @brief The prompt for a key displayed to the user.
     */
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            keyPressed = Input.inputString;

            KeyCode keycode = (KeyCode)Enum.Parse(typeof(KeyCode), keyPressed.ToUpper()); // Parse alphanumeric input into key
            settingsButtonText.text = keyPressed.ToUpper();
            key.GetComponent<ButtonController>().keyToPress = keycode;
            PlayerPrefs.SetInt(keyColour, (int)keycode);
            PlayerPrefs.Save(); // Save selected key
            Debug.Log(keyColour + keyPressed);
            ui.SetActive(false); // Dismiss UI
        }
    }
}
