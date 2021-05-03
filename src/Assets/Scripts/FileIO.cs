using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/**
 * @name FileIO
 * @brief Handles all file I/O for map loading and high score storage
 * @date April 12, 2021
 */
public class FileIO : MonoBehaviour
{
    /**
     * @brief The one instance of FileIO to be referenced globally.
     */
    public static FileIO instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    /**
     * @brief Reads and returns the contents of the specified text file, splitting by the specified delimiter.
     * @detail Note maps are specified by a set of individual entries each representing a set of notes to spawn simultaneously.
     *         Each entry's notes are separated by a slash (/) and are numbered from 0 to 4 from left to right. Long notes can
     *         additionally be identified by a decimal point, with the number after the decimal giving the long note's length.
     * @param pathName The text file's full path, in UNIX format.
     * @param separator The character to split the file by.
     * @return An array of strings containing the file's contents after being split.
     */
    public string[] ReadFile(string pathName, char separator)
    {
        StreamReader reader = new StreamReader(pathName);
        return reader.ReadToEnd().Split(separator);
    }

    /**
     * @brief Reads the high scores from storage.
     * @return A list of the entries in the high score list.
     */
    public static List<LeaderboardEntry> GetLeaderboardList()
    {
        HighScore hs = JsonUtility.FromJson<HighScore>(PlayerPrefs.GetString("leaderboard", "{\"entryList\":[]}"));
        Debug.Log(PlayerPrefs.GetString("leaderboard"));
        return hs.entryList;
    }

    /**
     * @brief Write a new entry to the high score storage.
     * @param The entry to be written.
     */
    public static void AddEntryToLeaderboard(LeaderboardEntry entry)
    {
        HighScore hs = JsonUtility.FromJson<HighScore>(PlayerPrefs.GetString("leaderboard", "{\"entryList\":[]}"));
        Debug.Log(PlayerPrefs.GetString("leaderboard"));
        hs.entryList.Add(entry);
        string entryListString = JsonUtility.ToJson(hs);
        PlayerPrefs.SetString("leaderboard", entryListString);
        PlayerPrefs.Save();

    }

    private class HighScore
    {
        public List<LeaderboardEntry> entryList;
    }
}
