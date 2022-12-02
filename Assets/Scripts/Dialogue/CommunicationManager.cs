using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommunicationManager: MonoBehaviour
{
    public DialogueControls dControl;
    [HideInInspector]public int Comm;
    public int Coms;
    static CommunicationManager communicationManager;
    // Start is called before the first frame update
    void Awake(){
        if(communicationManager != null){
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
    }
}
