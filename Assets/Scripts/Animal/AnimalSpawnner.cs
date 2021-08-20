using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnner : MonoBehaviour
{
    [SerializeField] List<GameObject> animalsToSpawn;

    private float interval { get { return GameManager.instance.gameSettings.interval; } }

    private float timeElapsed = 0;

    //List<GameObject> animalList;

    private void Awake()
    {
        GameManager.OnGameStarted += () => { gameObject.SetActive(true); };
        GameManager.OnGameOver += () => { gameObject.SetActive(false); };

        gameObject.SetActive(false);
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= interval)
        {
            SpawnRandomAnimalRandomly();

            timeElapsed = 0;
        }
    }

    private void SpawnRandomAnimalRandomly()
    {
        var ramdomValueX = Random.Range(-2f, 2f);

        if (animalsToSpawn.Count < 1) return; // to prevent errors
        int randomAnimalIndex = Random.Range(0, animalsToSpawn.Count);

        if (animalsToSpawn[randomAnimalIndex] == null) return;
        {
            var animal = Instantiate(animalsToSpawn[randomAnimalIndex], new Vector2(ramdomValueX, transform.position.y), Quaternion.identity);
        }
    }
}



