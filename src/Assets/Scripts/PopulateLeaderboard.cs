using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * @name PopulateLeaderboard
 * @brief Populate the onscreen leaderboard with stored values.
 * @date April 12, 2021
 */
public class PopulateLeaderboard : MonoBehaviour
{
    /**
     * @brief The text on the leaderboard screen.
     */
    public Text textTemplate;
    // Start is called before the first frame update
    void Start()
    {

        // List<LeaderboardEntry> entryList = new List<LeaderboardEntry> {

        //    new LeaderboardEntry{ name="Veerash", score = 10000, date = "2021/03/05"},
        //    new LeaderboardEntry{ name="Almen", score = 10, date = "2021/03/03"},
        //    new LeaderboardEntry{ name="David", score = 123456567, date = "2021/03/02"},
        //    new LeaderboardEntry{ name="Veerash", score = 0, date = "2021/03/05"},

        // };

        List<LeaderboardEntry> entryList = FileIO.GetLeaderboardList();
        //Debug.Log(entryList);

        entryList.Sort((a, b) => b.score.CompareTo(a.score));

        //HighScore hs = new HighScore { entryList  = entryList };
        //string entryListString = JsonUtility.ToJson(hs);
        //PlayerPrefs.SetString("leaderboard", entryListString);
        //PlayerPrefs.Save();

        for (int i = 0; i < entryList.Count; i++)
        {
            Text nameText = Instantiate(textTemplate, transform);
            nameText.text = entryList[i].name;

            Text scoreText = Instantiate(textTemplate, transform);
            scoreText.text = ""+entryList[i].score;

            Text dateText = Instantiate(textTemplate, transform);
            dateText.text = entryList[i].date;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
