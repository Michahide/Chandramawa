using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunicationManager: MonoBehaviour
{
    [HideInInspector] public int Comm;

    private bool Reset = true;
    public DialogueControls dControl;
    public int Coms;
    static CommunicationManager communicationManager;
    // Start is called before the first frame update
    void Awake(){

        if (communicationManager != null){
            //jika ganti scene, gameobject bakal ke duplicate, maka lakukan destroy
            Destroy(this.gameObject);
        }
        else{
            communicationManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         dControl = FindObjectOfType<DialogueControls>();

        if (dControl != null)
        {
            Comm = dControl.npc;

            if (Comm == 1)
            {
                Coms = 1;
            }
        }
        else
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        if (scene.name == "ChangeDay" || scene.name == "Death" || scene.name == "HappyEnding")
        {
            if (Reset)
            {
                Comm = 0;
                Coms = 0;
                Reset = false;
            }
        }

    }
}
