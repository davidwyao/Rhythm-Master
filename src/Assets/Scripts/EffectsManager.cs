using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name EffectsManager
 * @brief Manages visual effects displayed to the screen.
 * @date April 12, 2021
 */
public class EffectsManager : MonoBehaviour
{
    /**
     * @brief Game objects to represent the prefabs for the effects: normal, good, perfect, and missed hit.
     */
    public GameObject normalEffect, goodEffect, perfectEffect, missedEffect;

    /**
    * @brief Instance used for singleton pattern
    */
    public static EffectsManager instance;

    void Start()
    {
        instance = this;
    }

    /**
     * @brief Called to instantiate a normal effect when a normal hit has been made.
     * @param x x coordinate of effect
     * @param y y coordinate of effect
     * @param z z coordinate of effect
     */
    public static void SpawnNormalEffect(float x, float y, float z) 
    {
        Instantiate(instance.normalEffect, new Vector3(x, y, z), Quaternion.identity);
    }

    /**
     * @brief Called to instantiate a good effect when a good hit has been made.
     * @param x x coordinate of effect
     * @param y y coordinate of effect
     * @param z z coordinate of effect
     */
    public static void SpawnGoodEffect(float x, float y, float z)
    {
        Instantiate(instance.goodEffect, new Vector3(x, y, z), Quaternion.identity);
    }

    /**
     * @brief Called to instantiate a perfect effect when a perfect hit has been made.
     * @param x x coordinate of effect
     * @param y y coordinate of effect
     * @param z z coordinate of effect
     */
    public static void SpawnPerfectEffect(float x, float y, float z)
    {
        Instantiate(instance.perfectEffect, new Vector3(x, y, z), Quaternion.identity);
    }

    /**
     * @brief Called to instantiate a missed effect when a hit waas missed.
     * @param x x coordinate of effect
     * @param y y coordinate of effect
     * @param z z coordinate of effect
     */
    public static void SpawnMissedEffect(float x, float y, float z)
    {
        Instantiate(instance.missedEffect, new Vector3(x, y, z), Quaternion.identity);
    }
}
