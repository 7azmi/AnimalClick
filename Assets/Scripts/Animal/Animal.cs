using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Animal : MonoBehaviour, IPointerDownHandler
{
    public static event Action<Animal> OnAnimalPointerDown;

    [SerializeField] protected int score = 1;


    private void Awake() => GameManager.OnGameOver += Destroy;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnAnimalPointerDown?.Invoke(this); //for counting score details

        ScoreText.OnAddScore?.Invoke(score);

        Destroy(gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            GameManager.OnGameOver?.Invoke();

            Destroy(gameObject);

        }
    }

    protected void Destroy() => Destroy(gameObject);

    protected void OnDestroy()
    {
        GameManager.OnGameOver -= Destroy;
    }


}
