using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name CollisionDetector
 * @brief Handles note-key collisions and the accuracy of the collision's timing.
 * @date April 12, 2021
 */
public class CollisionDetector : MonoBehaviour
{
    private Collider collider;
    private bool hitLast; // True if the instance of note this script is tied to has been hit.

    // Start is called before the first frame update
    void Start()
    {
        hitLast = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * @brief Called when a note is hit. Calculates the accuracy of the hit.
     * @detail Finds the distance from the note's centre and the key's centre at the time of hit.
     */
    public void NoteHit()
    {
        if (collider == null) return;
        hitLast = true;
        if (Mathf.Abs(transform.position.z - collider.transform.position.z) > 0.1) // distance between note, key greater than 0.1
        {
            EffectsManager.SpawnNormalEffect(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.NormalHit();
        }
        else if (Mathf.Abs(transform.position.z - collider.transform.position.z) > 0.04f) // distance between note, key greater than 0.04
        {
            EffectsManager.SpawnGoodEffect(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.GoodHit();
        }
        else 
        {
            EffectsManager.SpawnPerfectEffect(transform.position.x, transform.position.y, transform.position.z);
            GameManager.instance.PerfectHit();
        }
    }

    /**
     * @brief Called when a note is not hit.
     */
    public void NoteMissed()
    {
        EffectsManager.SpawnMissedEffect(transform.position.x, transform.position.y, transform.position.z);
        GameManager.instance.NoteMissed();
    }

    /**
     * @brief Called when a long note is completed.
     */
    public void LongNoteHit()
    {
        GameManager.instance.LongHit();
    }

    /**
     * @brief Called when a long note is hit.
     */
    public void LongNoteClicked()
    {
        GameManager.instance.LongClicked();
        hitLast = true;
    }


    // When anything intersects with the key.
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator" || other.tag == "ActivatorLong")
        {
            if (!GameManager.instance.song.isPlaying) // No music is playing at the beginning of the game
            {
                GameManager.instance.songStarted = true;
                GameManager.instance.StartMusic();
            }
            
            collider = other;
            if (other.tag == "Activator")
            {
                this.GetComponent<ButtonController>().CanPress(); // Note can now be hit
            }
            else
            {
                this.GetComponent<ButtonController>().CanPressLong();
            }
            
        }
    }

    // When something that has intersected with the key no longer does so.
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator" || other.tag == "ActivatorLong")
        {
            if (!hitLast)
            {
                NoteMissed(); // Note was never hit, it is missed
            }
            else
            {
                hitLast = false;
            }

            collider = null;

            if (other.tag == "Activator")
            {
                this.GetComponent<ButtonController>().CantPress(); // Note can no longer be hit
            }
            else
            {
                this.GetComponent<ButtonController>().CantPressLong();
            }

        }
    }
}