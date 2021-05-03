using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name Effects
 * @brief Effects to be displayed to the screen.
 * @date April 12, 2021
 */
public class Effects : MonoBehaviour
{
    
    /**
     * @brief Time before effect is despawned, in seconds
     */
    private const float lifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
