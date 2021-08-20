using TMPro;
using UnityEngine;

public class LogName_UI : MonoBehaviour
{
    private void OnEnable() => GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Log_UI>().log.name;
}
