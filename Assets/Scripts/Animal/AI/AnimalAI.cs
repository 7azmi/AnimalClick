using UnityEngine;

public abstract class AnimalAI : MonoBehaviour
{
    [SerializeField] protected float speed = 2;

    protected void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
}
