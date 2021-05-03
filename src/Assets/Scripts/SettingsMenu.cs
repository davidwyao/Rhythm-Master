using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * @name SettingsMenu
 * @brief The game settings menu.
 * @date April 12, 2021
 */
public class SettingsMenu : MonoBehaviour
{
    public GameObject uiGreen;
    public GameObject uiRed;
    public GameObject uiBlue;
    public GameObject uiYellow;
    public GameObject uiPink;

    /**
     * @brief Volume slider
     */
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume", 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "SettingsScene")
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    /**
     * @brief Sets game volume based on the current slider value.
     */
    public void SetVolume()
    {
        AudioListener.volume =  slider.value;
        PlayerPrefs.SetFloat("volume", slider.value);
    }

    /**
     * @brief Green button to be rebound.
     */
    public void GreenPressed()
    {
        uiGreen.SetActive(true);
    }

    /**
     * @brief Red button to be rebound.
     */
    public void RedPressed()
    {
        uiRed.SetActive(true);
    }

    /**
     * @brief Yellow button to be rebound.
     */
    public void YellowPressed()
    {
        uiYellow.SetActive(true);
    }

    /**
     * @brief Blue button to be rebound.
     */
    public void BluePressed()
    {
        uiBlue.SetActive(true);
    }

    /**
     * @brief Pink button to be rebound.
     */
    public void PinkPressed()
    {
        uiPink.SetActive(true);
    }
}
