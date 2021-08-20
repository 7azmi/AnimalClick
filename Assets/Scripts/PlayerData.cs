using UnityEngine;

public class PlayerData : MonoBehaviour
{
    string PlayerName { get { return PlayerPrefs.GetString("PlayerName", SystemInfo.deviceName); } }
    string Date { get { return System.DateTime.Now.ToString("MM/dd"); } }
    internal int currentScore { get { return FindObjectOfType<ScoreText>().scoreCounter; } }

    public Log NewScore()
    {
        return new Log(PlayerName, Date, currentScore);
    }
    
}

[System.Serializable]
public class Log
{
    public Log(string name, string date, int score)
    {
        this.name = name; 
        this.date = date;
        this.score = score;
    }

    public string name;
    public string date;
    public int score;
}
