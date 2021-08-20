using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [ContextMenu("haha")]
    void Delete()
    {
        PlayerPrefs.DeleteAll();
    }

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

         //highScoreTable = tempHighScoreTaple;

        string tempJson = JsonUtility.ToJson(tempHighScoreTaple);


        PlayerPrefs.SetString(name, tempJson);
        //print(PlayerPrefs.GetString("leader board"));
        PlayerPrefs.Save();

        //return tempJson;
    }

    
    HighScoreTable highScoreTable { get { return JsonUtility.FromJson<HighScoreTable>(JsonLeaderBoard); } }

    PlayerData playerData { get; set; }


    private void Awake()
    {
        playerData = FindObjectOfType<PlayerData>();

        GameManager.OnGameOver += CheckNewHighScore;

        //PlayerPrefs.DeleteAll();

    }

    private void OnEnable()
    {

        Display();
    }

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

            string NewJson = JsonUtility.ToJson(NewHighScoreTable);

            PlayerPrefs.SetString("leader board", NewJson);
            PlayerPrefs.Save();
        }


        #region shit
        //try
        //{




        //for (int k = 0; k < 5 ; k++) //starting from last value
        //{



        //    if (playerData.currentScore > GetLogScore(0))
        //    {
        //        //Add
        //        HighScoreTable NewHighScoreTable = new HighScoreTable { highScoreList = highScoreTable.highScoreList };
        //        NewHighScoreTable.highScoreList.Add(playerData.NewScore());

        //        //print(NewHighScoreTable.highScoreList[NewHighScoreTable.highScoreList.Count-1].score);



        //        //resort
        //        for (int i = 0; i < NewHighScoreTable.highScoreList.Count; i++)
        //        {
        //            for (int j = i + 1; j < NewHighScoreTable.highScoreList.Count; j++)
        //            {
        //                Log temp = NewHighScoreTable.highScoreList[i];
        //                NewHighScoreTable.highScoreList[i] = NewHighScoreTable.highScoreList[j];
        //                NewHighScoreTable.highScoreList[j] = temp;
        //            }
        //        }
        //        //remove
        //        int lastItem = NewHighScoreTable.highScoreList.Count - 1;
        //        NewHighScoreTable.highScoreList.Remove(highScoreTable.highScoreList[lastItem]);

        //        string NewJson = JsonUtility.ToJson(NewHighScoreTable);

        //        PlayerPrefs.SetString("leader board", NewJson);
        //        PlayerPrefs.Save();

        //        print(JsonLeaderBoard);
        //        //PlayerPrefs.Save();
        //        return;
        //    }
        //}
        //}
        //catch (Exception)
        //{

        //    throw;
        //} 
        #endregion
    }

    private int GetLastLogScore() => highScoreTable.highScoreList[highScoreTable.highScoreList.Count-1].score;

    void Display()
    {
        for (int i = 0; i < highScoreTable.highScoreList.Count; i++)
        {
            logs[i].log = highScoreTable.highScoreList[i];
        }
    }

    class HighScoreTable
    {
        public List<Log> highScoreList;
    }

}
