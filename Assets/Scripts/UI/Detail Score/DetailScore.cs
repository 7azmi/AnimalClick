using UnityEngine;

public class DetailScore : MonoBehaviour
{
    private void Start() => gameObject.SetActive(false);


    public void Freeze(bool value)
    {
        Time.timeScale = value ? 0 : 1;
    }
}
