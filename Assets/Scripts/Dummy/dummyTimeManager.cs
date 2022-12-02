using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class dummyTimeManager : MonoBehaviour
{
    [SerializeField] private bool TimerOn = false;

    private TMP_Text Timer;
    private int npc;
    public float TimeLeft;
    private string sceneName;

    void Start()
    {
        TimerOn = true;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        Timer = GameObject.Find("TimerTxt").GetComponent<TMP_Text>();

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }

            else if (TimeLeft == 0 || TimeLeft < 0)
            {

                if (npc == 0)
                {
                    Debug.Log("death");
                    sceneName = "Death";
                    SceneLoaderManager.ProgressLoad(sceneName);
                }

                else
                {
                    Debug.Log("You survived");
                }

                TimeLeft = 0;
                TimerOn = false;
            }
        }

    }
    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = MathF.Floor(currentTime / 60);
        float seconds = MathF.Floor(currentTime % 60);

        Timer.text = String.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
