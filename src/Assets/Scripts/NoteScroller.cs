using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name NoteScroller
 * @brief Handles each note's motion down the gameplay screen.
 * @date April 12, 2021
 */
public class NoteScroller : MonoBehaviour
{
    /**
     * @brief The speed at which the note moves down the screen.
     */
    public float beatTempo;

    /**
     * @brief True if notes have started spawning.
     */
    public bool hasStarted;


    // Start is called before the first frame update
    void Start()
    {
        float size = this.GetComponent<BoxCollider>().size.z;
        Destroy(this.gameObject, (5.5f+size) / beatTempo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime); // Move down
    }
}
