using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private TimerScript timerScript;
    public float Timer;
    void Start()
    {   
        timerScript = FindObjectOfType<TimerScript>();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        Timer = timerScript.TimeLeft;
    }
}
