using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private TimerScript timerScript;
    public float Timer;
    void Start()
    {
        
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        timerScript = FindObjectOfType<TimerScript>();

        Timer = timerScript.TimeLeft;
    }
}
