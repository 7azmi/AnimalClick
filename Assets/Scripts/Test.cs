using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public object tedelete;

    public string day;
    private void Awake()
    {
        day = System.DateTime.Now.ToString("MM/dd");

        //print(PlayerPrefs.GetString("nobody"));

        day = SystemInfo.deviceName;
        //PlayerPrefs.Save();


    }
}
