using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal GameSettings gameSettings;

    public static GameManager instance;

    public static Action OnGameStarted;

    public static Action OnGameOver;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OnGameStarted?.Invoke();
    }



    #region Unused Code

    //public static GameManager instance;



    //[HideInInspector]
    //public List<GameObject> animalList = new List<GameObject>();

    //private int playerScore;

    //private bool gameOver = false;

    //public TextMeshProUGUI scoreText;

    //public AnimalSpawnner spawner;

    //public GameObject gameOverPanel;

    //public Button restartButton;

    //public int PlayerScore
    //{
    //    get
    //    {
    //        return playerScore;
    //    }

    //    set
    //    {
    //        playerScore = value;
    //        scoreText.SetText("Score: " + playerScore);
    //    }
    //}

    //public bool GameOver
    //{
    //    get
    //    {
    //        return gameOver;
    //    }
    //    set
    //    {
    //        gameOver = value;

    //        if (gameOver)
    //        {
    //            gameOverPanel.SetActive(true);

    //            spawner.enabled = false;

    //            for (int i = 0; i < animalList.Count; i++)
    //            {
    //                Destroy(animalList[i]);
    //            }
    //        }
    //        else
    //        {
    //            gameOverPanel.SetActive(false);
    //            spawner.enabled = true;
    //        }
    //    }
    //}

    //void Awake()
    //{
    //    if (instance != null)
    //    {
    //        return;
    //    }

    //    instance = this;
    //    scoreText.SetText("Score: " + playerScore);
    //    restartButton.onClick.AddListener(OnClickRestart);
    //}

    //private void OnClickRestart()
    //{
    //    GameOver = false;
    //} 
    #endregion



}
