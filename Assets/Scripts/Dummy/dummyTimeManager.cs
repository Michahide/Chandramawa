using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dummyTimeManager : MonoBehaviour
{
    [SerializeField] private bool TimerOn = false;
    [SerializeField] private CommunicationManager communicationManager;
    [SerializeField] private int npc;
    [SerializeField] private string NextDayScene;

    private TMP_Text Timer;
    public float TimeLeft;
    private string sceneName;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TimerOn = true;    
    }
    private void Update()
    {
        FindText();
        CountDown();
        npc = communicationManager.GetComponent<CommunicationManager>().Coms;
    }
    public void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = MathF.Floor(currentTime / 60);
        float seconds = MathF.Floor(currentTime % 60);

        Timer.text = String.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void FindText()
    {
            Timer = GameObject.Find("TimerTxt").GetComponent<TMP_Text>();
    }

    public void CountDown()
    {
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
                    
                }

                else
                {
                    SceneLoaderManager.ProgressLoad(NextDayScene);
                    Debug.Log("You survived");
                }

                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }
}
