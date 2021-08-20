using TMPro;
using UnityEngine;

public abstract class AnimalCounter : MonoBehaviour
{
    protected TextMeshProUGUI score;

    protected int counter = 0;

    protected void Awake()
    {
        score = GetComponentInChildren<TextMeshProUGUI>();

        counter = 0;

        Animal.OnAnimalPointerDown += UpdateScore;

        GameManager.OnGameOver += () => { counter = 0; score.text = "0"; };

    }

    protected abstract void UpdateScore(Animal type);
}
