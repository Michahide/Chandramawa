using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Transactions;

public class TimerScriptContinue : MonoBehaviour
{
    public float TimeLeft;
    [SerializeField] private bool TimerOn = false;
    [SerializeField] private string objectName;
    [SerializeField] private GameObject Options;
    private TimeManager timeManager;

    public TMP_Text TimerText;
    private int npc;
    private string sceneName;

    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        TimeLeft = timeManager.Timer;
        TimerOn = true;
    }

    void Update()
    {
        if (objectName != null)
        {
            npc = Options.GetComponent<DialogueControls>().npc;
        }

        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }

            else if(TimeLeft == 0 || TimeLeft < 0)
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

    void UpdateTimer (float currentTime)
    {
        currentTime += 1;

        float minutes = MathF.Floor(currentTime / 60);
        float seconds = MathF.Floor(currentTime % 60);

        TimerText.text = String.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
