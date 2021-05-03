using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name NoteObject
 * @brief Stores information tied to each note that is spawned.
 * @date April 12, 2021
 */
public class NoteObject : MonoBehaviour
{
    /**
     * @brief The key that the user must press to hit this note.
     */
    public KeyCode keyToPress;

    /**
     * @brief The in-game key associated with keyToPress.
     */
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
