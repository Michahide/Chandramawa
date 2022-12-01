using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesKom : MonoBehaviour
{
    public DialogueControls dControl;
    public int Comm;
    public int Coms;
    static TesKom a;
    // Start is called before the first frame update
    void Awake(){
        if(a != null){
            //jika ganti scene, gameobject bakal ke duplicate, maka lakukan destroy
            Destroy(this.gameObject);
        }
        else{
            a = this;
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
        Comm = dControl.npc;

        if(Comm == 1){
            Coms =1;
        }
    }
}
