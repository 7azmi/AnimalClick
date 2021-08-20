using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    public enum Background{ Blue = 0, Red, Yellow }

    public Background background;

    public Sprite getBackground { get { return backgrounds[(int)background]; } }

    [SerializeField] Sprite[] backgrounds;

    [Range(0.1f,3f)]
    public float interval = 1.5f;



    #region Trash
    //static string Json { get { return File.ReadAllText(Application.dataPath + "/Resources/Config File"); } } 

    //static Config config { get { return JsonUtility.FromJson<Config>(Json); } } //to read json file as a Config class 


    //public static int background { get { return config.backround; } } 
    //public static float interval { get { return config.interval; } }


    //private class Config
    //{
    //    public int backround;
    //    public float interval;
    //} 
    #endregion
}
