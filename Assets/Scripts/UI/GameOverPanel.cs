using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameOver += () => { gameObject.SetActive(true); };
        GameManager.OnGameStarted += () => { gameObject.SetActive(false); };
        gameObject.SetActive(false);
    }


    public void Restart()
    {
        GameManager.OnGameStarted?.Invoke();
    }
}
