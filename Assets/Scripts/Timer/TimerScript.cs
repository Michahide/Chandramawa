using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private float TimeLeft;
    [SerializeField] private bool TimerOn = false;

    public TMP_Text TimerText;
    public readonly NPC npcCom;
    private string sceneName;

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }

            else if(TimeLeft == 0 || TimeLeft < 0)
            {
                Debug.Log("death");
                //if (npcCom.communication == 0)
                //{
                //    sceneName = "Death";
                    
                //    SceneLoaderManager.ProgressLoad(sceneName);
                //}

                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer (float currentTime)
    {
        currentTime += 1;

        float minutes = MathF.Floor(currentTime / 60);
        float seconds = MathF.Floor(currentTime % 60);

        TimerText.text = String.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
