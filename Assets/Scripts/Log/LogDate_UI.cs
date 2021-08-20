using TMPro;
using UnityEngine;

public class LogDate_UI : MonoBehaviour
{
    private void OnEnable() => GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Log_UI>().log.date;

}
