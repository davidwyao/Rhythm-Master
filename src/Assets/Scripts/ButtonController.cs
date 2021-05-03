using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name ButtonController
 * @brief Parses user inputs, applies effects to buttons, and checks validity of presses.
 * @date April 12, 2021
 */
public class ButtonController : MonoBehaviour
{
    /**
     * @brief The key that this controller checks for.
     */
    public KeyCode keyToPress;

    /**
     * @brief True if the key is intersecting a note.
     */
    public bool canBePressed;

    /**
     * @brief True if the key is intersecting a long note.
     */
    public bool canBePressedLong;

    /**
     * @brief True if the key intersecting a long note is being pressed.
     */
    public bool longBeingPressed;

    /**
     * @brief The colour of the specified key.
     */
    public string colour;

    /**
     * @brief The code of the specified key.
     */
    public int code;

    private bool finishedLong;

    // Start is called before the first frame update
    void Start()
    {
        keyToPress = (KeyCode)PlayerPrefs.GetInt(colour, code);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(keyToPress))
        {
            transform.Translate(Vector3.back * 0.02f); // Move the key down

            if (canBePressed)
            {
                this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION"); // Light up key
                this.GetComponent<CollisionDetector>().NoteHit(); // Pass to Collision Detector to check accuracy
            }
            else if (canBePressedLong)
            {
                this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                this.GetComponent<CollisionDetector>().LongNoteClicked();
                longBeingPressed = true;
            } 
            else if (!canBePressed && !canBePressedLong) // Key isn't intersecting anything
            {
                this.GetComponent<CollisionDetector>().NoteMissed();
            }


        }
        if (Input.GetKeyUp(keyToPress))
        {
            if (longBeingPressed)
            {
                canBePressed = false;
                longBeingPressed = false;
                if (!finishedLong)
                {
                    this.GetComponent<CollisionDetector>().NoteMissed(); // Premature release of long note
                }
                    
                finishedLong = false;
            }
            transform.Translate(Vector3.forward * 0.02f); // Move the key back forward
            this.GetComponent<Renderer>().material.DisableKeyword("_EMISSION"); // Dim key
        }
    }

    /**
     * @brief Called when a long note intersects the key.
     */
    public void CanPressLong()
    {
        canBePressedLong = true;
    }

    /**
     * @brief Called when a long note passes the key.
     * @detail Gives credit for a complete long note, if it has been hit.
     */
    public void CantPressLong()
    {

        if (longBeingPressed)
        {
            finishedLong = true;
            this.GetComponent<CollisionDetector>().LongNoteHit();
        }
        canBePressedLong = false;
    }

    /**
     * @brief Called when a short note intersects the key.
     */
    public void CanPress()
    {
        canBePressed = true;
    }

    /**
     * @brief Called when a short note passes the key.
     */
    public void CantPress()
    {
        canBePressed = false;
    }
    
}