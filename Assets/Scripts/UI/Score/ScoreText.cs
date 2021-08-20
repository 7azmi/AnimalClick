using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{

    public static Action<int> OnAddScore;

    internal int scoreCounter;

    public int GetScore { get { return scoreCounter; } }

    TextMeshProUGUI txt;

    private void Awake()
    {
        txt = GetComponent<TextMeshProUGUI>();

        GameManager.OnGameStarted += ResetCounter;

        OnAddScore += AddScore;
    }

    private void ResetCounter()
    {
        scoreCounter = 0;

        txt.text = "Score: " + scoreCounter;
    }
    
    private void AddScore(int value)
    {
        scoreCounter += value;

        txt.text = "Score: " + scoreCounter;
    }
}
