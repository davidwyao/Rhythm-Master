using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @name NoteSpawner
 * @brief Parses the list of notes and spawns to the game screen accordingly.
 * @date April 12, 2021
 */
public class NoteSpawner : MonoBehaviour
{

    private const int numNotes = 5;
    private const float spawnDelay = 2f;
    private const float minute = 60f;
    /**
     * @brief The five possible short notes that can be spawned at once.
     */
    public GameObject[] notes = new GameObject[numNotes];

    /**
     * @brief The five possible long notes that can be spawned at once.
     */
    public GameObject[] longNotes = new GameObject[numNotes];

    /**
     * @brief The five possible keys to hit.
     */
    public GameObject[] keys = new GameObject[numNotes];

    /**
     * @brief The tempo of the song, in beats per minute.
     */
    public float BPM;

    /**
     * @brief The list of notes to spawn.
     * @detail Notes from left to right are number from 0 through 4. Long notes are additionally denoted by a decimal following this number.\n
     *         Simultaneous notes are separated by a slash (/). For example, 0.2 gives a long leftmost note of length 2. An entry in noteList
     *         is spawned once every beat.
     */
    public string[] noteList;

    private int nextIndex, index;

    private float floatIndex;

    // Start is called before the first frame update
    void Start()
    {
        BPM = 175f;
        nextIndex = 0; // the next index in the note list to spawn

        InvokeRepeating("SpawnNote", spawnDelay, minute/BPM); // call SpawnNote() repeatedly
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void SpawnNote()
    {
        if (!(nextIndex == GameManager.instance.noteList.Length)) // If not at the end of the noteList
        {
            // different notes to be played at the same time are delineated by a / character
            string[] nextNotes = GameManager.instance.noteList[nextIndex].Split('/');
            for (int i = 0; i < nextNotes.Length; i++)
            {
                bool canParse = float.TryParse(nextNotes[i], out floatIndex);
                if (canParse)
                {
                    GameManager.instance.totalNotes++; // a note has been spawned
                    index = (int) floatIndex;
                    if (floatIndex - index < 0.00001f) // there is no intentional decimal, so place a normal note
                    {
                        GameObject note = Instantiate(notes[index]);
                        note.GetComponent<NoteObject>().key = keys[index];
                    }
                    else // place a long note
                    {
                        float longNoteLength = ((floatIndex % 1) * 10);
                        SpawnLongNote(longNoteLength, index);
                    }
                }
            }
            nextIndex += 1;
        }
    }

    // len gives the length of the note, in Unity squares. index gives the colour of note to spawn.
    void SpawnLongNote(float len, int index)
    {

        GameObject note = Instantiate(longNotes[index]);
        note.GetComponent<NoteObject>().key = keys[index];


        GameObject flat = note.transform.GetChild(1).gameObject; // The "tail" of the long note

        flat.transform.localScale = new Vector3(flat.transform.localScale.x, flat.transform.localScale.y, len); // positioning the tail correctly
        flat.transform.localPosition = new Vector3(flat.transform.localPosition.x, flat.transform.localPosition.y, flat.transform.localPosition.z*len);

        BoxCollider collider = note.GetComponent<BoxCollider>();
        collider.size = new Vector3(collider.size.x, collider.size.y, len + 0.13125f);
        collider.center = new Vector3(collider.center.x, collider.center.y, collider.center.z * len + 0.13125f);


    }
}