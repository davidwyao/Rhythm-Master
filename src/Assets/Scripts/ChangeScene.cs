using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * @name ChangeScene
 * @brief Changes the scene being displayed on the output screen.
 * @date April 12, 2021
 */
public class ChangeScene : MonoBehaviour
{

    /**
     * @brief Changes the scene being displayed.
     * @param scene_name
     *              The name of the scene to display.
     */
    public void BtnChangeScene(string scene_name) {
        SceneManager.LoadScene(scene_name);
    }
}
