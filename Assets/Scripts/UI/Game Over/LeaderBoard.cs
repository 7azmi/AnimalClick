using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{

    [SerializeField] List<Log_UI> logs;

    string JsonLeaderBoard
    {
        get
        {
            if (PlayerPrefs.GetString("leader board") == "") CreateJsonLeaderBoard("leader board");
            return PlayerPrefs.GetString("leader board");
        }
    }


    //executes only once
    private void CreateJsonLeaderBoard(string name)
    {
        HighScoreTable tempHighScoreTaple = new HighScoreTable();
        tempHighScoreTaple.highScoreList = new List<Log>();

        for (int i = 0; i < 5; i++)
        {
            tempHighScoreTaple.highScoreList.Add(new Log("", "", 0));
        }

        string tempJson = JsonUtility.ToJson(tempHighScoreTaple);

        PlayerPrefs.SetString(name, tempJson);
        //print(PlayerPrefs.GetString("leader board"));
        PlayerPrefs.Save();
    }

    
    HighScoreTable highScoreTable { get { return JsonUtility.FromJson<HighScoreTable>(JsonLeaderBoard); } }

    PlayerData playerData { get; set; }


    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();

        GameManager.OnGameOver += CheckNewHighScore;
    }

    private void OnEnable() => Display();

    private void CheckNewHighScore()
    {
        if(playerData.currentScore > GetLastLogScore())
        {
            //Replace
            HighScoreTable NewHighScoreTable = new HighScoreTable { highScoreList = highScoreTable.highScoreList };

            int lastIndex = highScoreTable.highScoreList.Count - 1;
            NewHighScoreTable.highScoreList[lastIndex] = playerData.NewScore();

            //resort
            for (int i = 0; i < NewHighScoreTable.highScoreList.Count; i++)
            {
                for (int j = i + 1; j < NewHighScoreTable.highScoreList.Count; j++)
                {
                    if (NewHighScoreTable.highScoreList[j].score > NewHighScoreTable.highScoreList[i].score)
                    {
                        Log temp = NewHighScoreTable.highScoreList[i];
                        NewHighScoreTable.highScoreList[i] = NewHighScoreTable.highScoreList[j];
                        NewHighScoreTable.highScoreList[j] = temp;
                    }
                }
            }

            //save
            string NewJson = JsonUtility.ToJson(NewHighScoreTable);

            PlayerPrefs.SetString("leader board", NewJson);
            PlayerPrefs.Save();
        }
    }

    private int GetLastLogScore() => highScoreTable.highScoreList[highScoreTable.highScoreList.Count-1].score;

    void Display()
    {
        for (int i = 0; i < highScoreTable.highScoreList.Count; i++)
        {
            logs[i].log = highScoreTable.highScoreList[i];
        }
    }

    #if UNITY_EDITOR
    [ContextMenu("Delete All Prefs")]
    void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
    #endif

    class HighScoreTable
    {
        public List<Log> highScoreList;
    }
}
