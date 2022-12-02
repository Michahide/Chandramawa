using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;
using Unity.VisualScripting;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private bool TimerOn = false;
    [SerializeField] private CommunicationManager communicationManager;
    [SerializeField] private int npc;
    [SerializeField] private string NextDayScene;

    public bool setTime = true;
    public TMP_Text Timer;
    public float TimeLeft;
    private string sceneName;

    private void Awake()
    {
        
        TimerOn = true;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject); 
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void Update()
    {
        FindText();
        CountDown();
        npc = FindObjectOfType<CommunicationManager>().Coms;
    }
     void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "HappyEnding" || scene.name == "ChangeDay" || scene.name == "Death")
        {
            
            if (this.gameObject == null){
               
            Destroy(this);
            }
            else{
               
                Destroy(this);
            }
        }

        else if(scene.name == "Chandra'sHouse1" || scene.name == "Chandra'sHouse2")
        {
            
            if (setTime)
            {
                TimeLeft = 90;
                setTime = false;
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
                    SceneLoaderManager.ProgressLoad(sceneName);
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
