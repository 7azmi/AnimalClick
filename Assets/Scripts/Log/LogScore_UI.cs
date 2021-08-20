using TMPro;
using UnityEngine;

public class LogScore_UI : MonoBehaviour
{
    private void OnEnable() => GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Log_UI>().log.score.ToString();
}
